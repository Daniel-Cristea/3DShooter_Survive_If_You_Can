using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public enum EnemyTYPE { Ranged, Melee }

public class AdaptiveBehavior : BehaviorTree.Tree
{

    public UnityEngine.Transform[] waypoints;
    [SerializeField] private EnemyInfo enemyInfo;
    [SerializeField] private EnemyGunInfo enemyGunInfo;
    [SerializeField] private GameObject weapon;
    [SerializeField] private EnemyTYPE enemyType;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckEnemyInAttackRange(transform, enemyGunInfo, weapon, enemyType),
                new TaskAttack(transform, weapon, enemyType),
            }),
            new Sequence(new List<Node>
            {
                new CheckEnemyInFOVRange(transform, enemyInfo),
                new TaskGoToTarget(transform),
            }), 
           new TaskPatrol(waypoints, transform, enemyInfo),
        });

        return root;
    }
}
