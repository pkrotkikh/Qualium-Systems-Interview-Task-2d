using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{

    LineRenderer lineRenderer;
    public Color lineColor;
    public GameObject player;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void DrawLines()
    {
        int index = 0;
        lineRenderer.positionCount = WaypointController.waypointsQueue.Count + 1;
        lineRenderer.sortingLayerName = "UI";
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.SetPosition(index, player.transform.position);
        index++;

        foreach (Transform waypoint in WaypointController.waypointsQueue)
        {
            lineRenderer.SetPosition(index, waypoint.position);
            index++;
        }
    }
}
