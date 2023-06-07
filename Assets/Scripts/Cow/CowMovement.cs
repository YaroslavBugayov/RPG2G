using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints for the cow to move to
    public float stopTime = 2f; // Time to stop at each waypoint

    private int currentWaypointIndex; // Index of the current waypoint
    private bool isMoving; // Flag to determine if the cow is moving
    private float stopTimer; // Timer to track the stop time

    private void Start()
    {
        currentWaypointIndex = 0;
        isMoving = false;
        stopTimer = stopTime;
    }

    private void Update()
    {
        if (!isMoving)
        {
            // If the cow is not moving, wait at the current waypoint
            stopTimer -= Time.deltaTime;
            if (stopTimer <= 0)
            {
                // If the stop time is over, start moving to the next waypoint
                MoveToNextWaypoint();
                stopTimer = stopTime;
            }
        }
        else
        {
            // If the cow is moving, move towards the current waypoint
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);
            transform.localScale = 
                transform.position.x < targetPosition.x 
                    ? new Vector3(1, 1, 1) 
                    : new Vector3(-1, 1, 1);

            // Check if the cow has reached the current waypoint
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    private void MoveToNextWaypoint()
    {
        // Increase the index of the current waypoint
        currentWaypointIndex++;

        // If the end of the waypoint array is reached, wrap around to the beginning
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }

        isMoving = true;
    }
}
