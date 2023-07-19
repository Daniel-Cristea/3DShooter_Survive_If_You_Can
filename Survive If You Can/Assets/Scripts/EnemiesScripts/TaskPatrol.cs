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
            Vector3 nextPos = new Vector3(waypoint.position.x, transform.position.y, waypoint.position.z);
            if( Vector3.Distance(transform.position, nextPos) <= 0.1f)
            {
                transform.position= nextPos;
                waiting = true;
                waitingCounter= 0f;

                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
            else
            {
                // If the enemy got to far away from the waypoints in the process of chasing the player, it will use navmash to get back to the patrol site
                if(Vector3.Distance(transform.position, nextPos) > 10.0f) {
                    agent.isStopped = false;
                    agent.SetDestination(nextPos);
                }
                else {
                   
                transform.position = Vector3.MoveTowards(transform.position, nextPos, enemyInfo.patrolSpeed * Time.deltaTime);
                transform.LookAt(nextPos);
                }
            }
        }

        state = NodeState.RUNNING;
        return state;

    }
}
