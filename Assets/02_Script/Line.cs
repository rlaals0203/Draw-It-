using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private float inkDrawed;

    List<Vector2> points;

    [SerializeField] private EdgeCollider2D _collider;
    private readonly List<Vector2> _points = new List<Vector2>();

    private void Start()
    {
        _collider.transform.position -= transform.position;
    }
    public void UpdateLine(Vector2 position)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(position);
            return;
        }

        if (Vector2.Distance(points.Last(), position) > 0.05f)
        {
            SetPoint(position);
        }
    }
    private void SetPoint(Vector2 point)
    {
        if (!Player.Instance.isEnoughInk || Player.Instance.isStart)
            return;

        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        _collider.points = _points.ToArray();

        if (points.Count > 1)
        {
            inkDrawed = ((points[^1] - points[^2]).magnitude);
            Player.Instance.inkLimit -= inkDrawed;
        }
    }
}
