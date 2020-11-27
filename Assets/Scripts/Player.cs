using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public WaypointController waypointController;
    public LineDrawer lineDrawer;
    public static bool isMoving;
    public static bool isPlayerPaused;

    void Update()
    {
        if(WaypointController.waypointsQueue.Count != 0 && !isMoving && !isPlayerPaused)
        {
            Transform nextWaypoint = WaypointController.waypointsQueue.Peek();
            StartCoroutine(SmoothMove(nextWaypoint.position));
        }
    }

    public IEnumerator SmoothMove(Vector3 endPoint)
    {
        isMoving = true;
        float smoothMoveTime = 0f;
        float smoothMoveDuration = 2f;
        int changeRotationSpeed = 5;

        Vector3 vectorToTarget = endPoint - transform.position;
        float angle = ( Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg ) - 90;

        while (smoothMoveTime < smoothMoveDuration)
        {
            if(isPlayerPaused == true)
            {
                yield break;
            }
            //Change position
            Vector3 newPosition = Vector3.Lerp(transform.position, endPoint, Time.deltaTime * smoothMoveDuration);
            gameObject.transform.position = newPosition;
            smoothMoveTime += Time.deltaTime;

            //Change rotation
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * changeRotationSpeed);

            yield return null;
        }

        transform.position = endPoint;
        lineDrawer.DrawLines();
        Transform destination = WaypointController.waypointsQueue.Dequeue();
        Destroy(destination.gameObject);
        isMoving = false;
    }
}