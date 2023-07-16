using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;

public class TaskPatrol : Node
{
    private Transform transform;
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;

   // private float waitingTime = 0.4f; // in seconds
    private float waitingCounter = 0f;
    private bool waiting = false;

    private EnemyInfo enemyInfo;
    private NavMeshAgent agent;

    public TaskPatrol(Transform[] waypoints, Transform transform, EnemyInfo enemyInfo, NavMeshAgent agent) {
        this.waypoints = waypoints;
        this.transform = transform;
        this.enemyInfo = enemyInfo;
        this.agent= agent;
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
                // If the enemy got to far away from the waypoints in the process of chasing the player, it will use navmash to get back to the patrol site
                if(Vector3.Distance(transform.position, waypoint.position) > 10.0f) {
                    agent.isStopped = false;
                    agent.SetDestination(waypoint.position);
                }
                else { 
                transform.position = Vector3.MoveTowards(transform.position, waypoint.position, enemyInfo.patrolSpeed * Time.deltaTime);
                transform.LookAt(waypoint.position);
                }
            }
        }

        state = NodeState.RUNNING;
        return state;

    }
}
