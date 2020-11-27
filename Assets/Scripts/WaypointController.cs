using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public GameObject waypointPrefab;
    public GameObject waypointParent;
    public static Queue<Transform> waypointsQueue;
    public LineDrawer lineDrawer;

    private void Start()
    {
        waypointsQueue = new Queue<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit && hit.transform.tag != "UI")
            {
                SetWaypoint(hit.point);
                lineDrawer.DrawLines();
            }
        }
    }

    void SetWaypoint(Vector3 position)
    {
        GameObject waypoint = Instantiate(waypointPrefab, position, Quaternion.identity);
        waypoint.transform.parent = waypointParent.transform;
        waypointsQueue.Enqueue(waypoint.transform);
    }
}