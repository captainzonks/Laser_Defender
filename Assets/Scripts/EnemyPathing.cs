using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] private WaveConfig waveConfig;
    private List<Transform> waypoints;
    [SerializeField] private float moveSpeed = 2f;

    private int _waypointIndex = 0;

    private void Start()
    {
        waypoints = waveConfig.GetWaypoints();

        transform.position = waypoints[_waypointIndex].transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[_waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                _waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
