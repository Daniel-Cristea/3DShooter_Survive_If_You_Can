using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInfo", menuName = "ScriptableObjects/EnemyInfoScriptableObject", order = 2)]

public class EnemyInfo : ScriptableObject
{
    public float patrolSpeed = 5.0f;
    public float patrolWaitingTime = 0.4f;
    public float fovRange = 30.0f;
    public LayerMask player;
    public float maxHealth = 220.0f;
    public int killingBonusPoints = 25;
}
