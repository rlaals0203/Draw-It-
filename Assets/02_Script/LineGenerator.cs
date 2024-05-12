using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(EdgeCollider2D))]
public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    GameObject newLine;

    private int count = 0;
    private float lineLength = 0;

    List<float> lineLengthList = new List<float>();
    Line activeLine;

    private void Update()
    {
        lineLength = Player.Instance.inkLimit;
         
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

        if (Input.GetKeyDown(KeyCode.R) && count > 0 && !Player.Instance.isStart)
        {
            DeleteLine();
        }

        if (Player.Instance.isReset)
        {
            ResetLine();
        }
    }
    
    private void DrawLine()
    {
        newLine = Instantiate(linePrefab);
        newLine.name = $"Line{count}";
        activeLine = newLine.GetComponent<Line>();
        count++;
    }
    private void GenerateLine()
    {
        lineLength = 0;
        activeLine = null;

        if (newLine == null)
            return;

        LineRenderer line = newLine.GetComponent<LineRenderer>();

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
    }

    private void UpdateLine()
    {
        if (!AntiDrawArea.isAntiArea)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);

            if (activeLine != null)
                activeLine.UpdateLine(mousePos);
        }
    }

    private void DeleteLine()
    {
        Destroy(GameObject.Find($"Line{count - 1}"));
        count--;

        if (lineLengthList.Count > 0)
        {
            Player.Instance.inkLimit += lineLengthList[^1];
            lineLengthList.Remove(lineLengthList[^1]);
        }
    }

    private void ResetLine()
    {
        for (int i = 0; i < count; i++)
        {
            Destroy(GameObject.Find($"Line{i}"));
        }

        count = 0;
        Player.Instance.isReset = false;
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
}
