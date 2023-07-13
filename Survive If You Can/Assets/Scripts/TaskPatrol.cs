using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskPatrol : Node
{
    private Transform transform;
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;

   // private float waitingTime = 0.4f; // in seconds
    private float waitingCounter = 0f;
    private bool waiting = false;

    private EnemyInfo enemyInfo;

    public TaskPatrol(Transform[] waypoints, Transform transform, EnemyInfo enemyInfo) {
        this.waypoints = waypoints;
        this.transform = transform;
        this.enemyInfo = enemyInfo;
    }

    public override NodeState Evaluate()
    {
        if (waiting)
        {
            waitingCounter += Time.deltaTime;
            if(waitingCounter >= enemyInfo.patrolWaitingTime)
            {
                waiting = false;
            }
        }
        else
        {
            Transform waypoint = waypoints[currentWaypointIndex];
            if( Vector3.Distance(transform.position, waypoint.position) <= 0.01f)
            {
                transform.position= waypoint.position;
                waiting = true;
                waitingCounter= 0f;

                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoint.position, enemyInfo.patrolSpeed * Time.deltaTime);
                transform.LookAt(waypoint.position);
            }
        }

        state = NodeState.RUNNING;
        return state;

    }
}
