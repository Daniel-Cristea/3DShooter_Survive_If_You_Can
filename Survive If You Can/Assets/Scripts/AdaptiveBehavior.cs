using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyTYPE { Ranged, Melee }

public class AdaptiveBehavior : BehaviorTree.Tree
{

    public UnityEngine.Transform[] waypoints;
    [SerializeField] private EnemyInfo enemyInfo;
    [SerializeField] private EnemyGunInfo enemyGunInfo;
    [SerializeField] private GameObject weapon;
    [SerializeField] private EnemyTYPE enemyType;
    [SerializeField] private NavMeshAgent agent;
    

    protected override Node SetupTree()
    {

        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckEnemyInAttackRange(transform, enemyGunInfo, weapon, enemyType),
                new TaskAttack(transform, weapon, enemyType, agent, enemyInfo),
            }), 
            new Sequence(new List<Node>
            {
                new CheckEnemyInFOVRange(transform, enemyInfo, enemyGunInfo),
                new TaskGoToTarget(transform, agent, enemyGunInfo, enemyInfo),
            }), 
           new TaskPatrol(waypoints, transform, enemyInfo, agent),
        });

        return root;
    }

    public EnemyTYPE getEnemyType()
    {
        return enemyType;
    }
}
