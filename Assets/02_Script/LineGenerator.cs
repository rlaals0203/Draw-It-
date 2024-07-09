using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(EdgeCollider2D))]
public class LineGenerator : MonoBehaviour
{
    [SerializeField] private GameObject linePrefab;
    private GameObject newLine;

    private int count = 0;

    private float lineLength = 0;
    private bool deleteCool = false;

    private List<float> lineLengthList = new List<float>();
    private Line activeLine;

    private void Update()
    {
        lineLength = Player.inkLimit;
         
        if (Input.GetMouseButtonDown(0) && !Setting.isSettingOpen && Player.Instance.isEnoughInk && !Player.Instance.isStart)
        {
            DrawLine();
        }

        if (Input.GetMouseButtonUp(0) && !Player.Instance.isStart)
        {
            GenerateLine();
        }

        if (activeLine != null)
        {
            UpdateLine();
        }

        if (Player.Instance.isReset)
        {
            ResetLine();
        }

        if (Input.GetKeyDown(KeyCode.R) && !Player.Instance.isStart)
        {
            DeleteLine();
        }
    }

    private void DrawLine()
    {
        if (!StageManager.Instance.isAntiDraw)
        {
            deleteCool = true;
            newLine = Instantiate(linePrefab);
            newLine.name = $"LineDrawed{count}";
            activeLine = newLine.GetComponent<Line>();
        }
    }

    private void GenerateLine()
    {
        deleteCool = true;
        lineLength = 0;
        activeLine = null;

        if (newLine == null)
            return;

        LineRenderer line = newLine.GetComponent<LineRenderer>();
        count++;

        if (line.positionCount < 2)
        {
            Destroy(line.gameObject);
            count--;
            return;
        }

        GenerateCollider(newLine.GetComponent<LineRenderer>());

        if (line.positionCount > 1)
        {
            for (int i = 0; i < line.positionCount - 1; i++)
            {
                lineLength += (line.GetPosition(i + 1) - line.GetPosition(i)).magnitude;
            }
        }

        lineLengthList.Add(lineLength);
        StartCoroutine(DeleteLineRoutine());
    }

    private void UpdateLine()
    {
        if (!StageManager.Instance.isAntiDraw)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);

            if (activeLine != null)
                activeLine.UpdateLine(mousePos);
        }
    }

    public void DeleteLine()
    {
        Debug.Log(lineLengthList.Count);

        if (deleteCool || Player.Instance.isStart)
            return;

        if (count < 1)
            return;

        Destroy(GameObject.Find($"LineDrawed{count - 1}"));

        Player.inkLimit += lineLengthList[^1];
        lineLengthList.Remove(lineLengthList[^1]);
        deleteCool = true;

        if (Player.inkLimit > 10)
        {
            Player.inkLimit = 10;
        }

        if (count > 0)
            count--;

        StartCoroutine(DeleteLineRoutine());
    }

    private void ResetLine()
    {
        for (int i = 0; i < count; i++)
        {
            Destroy(GameObject.Find($"LineDrawed{i}"));
        }

        count = 0;
        StartCoroutine(ResetRoutine());
    }

    private void GenerateCollider(LineRenderer line)
    {
        List<Vector2> edges = new List<Vector2>();

        for (int i = 0; i < line.positionCount; i++)
        {
            Vector3 linePoint = line.GetPosition(i);
            edges.Add(new Vector2(linePoint.x, linePoint.y));
        }

        newLine.GetComponent<EdgeCollider2D>().SetPoints(edges);
    }

    IEnumerator ResetRoutine()
    {
        yield return new WaitForSeconds(0.05f);
        Player.Instance.isReset = false;
    }

    IEnumerator DeleteLineRoutine()
    {
        yield return new WaitForSeconds(0.15f);
        deleteCool = false;
    }
}
