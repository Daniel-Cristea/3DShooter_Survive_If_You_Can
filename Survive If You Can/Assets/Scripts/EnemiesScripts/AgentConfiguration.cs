using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentConfiguration : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private EnemyInfo enemyInfo;
    [SerializeField] private EnemyGunInfo enemyGunInfo;
    [SerializeField] private AdaptiveBehavior adaptiveBehavior;
    private EnemyTYPE enemyType;

    // Start is called before the first frame update
    void Start()
    {
        enemyType = adaptiveBehavior.getEnemyType();
        if(enemyType == EnemyTYPE.Ranged) 
        {
            agent.stoppingDistance = enemyGunInfo.agentStoppingDistance_Ranged;
            agent.speed = enemyInfo.chasingSpeed_Ranged;
        }
        else
        {
            agent.stoppingDistance = enemyGunInfo.agentStoppingDistance_Melee;
            agent.speed = enemyInfo.chasingSpeed_Melee;
        }
        
    }

    
}
