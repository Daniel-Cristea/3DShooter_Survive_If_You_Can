using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyGunInfo", menuName = "ScriptableObjects/EnemyGunInfoScriptableObject", order = 3)]
public class EnemyGunInfo : ScriptableObject
{
    public float gunDamage = 1.0f;
    public float gunRange = 10.0f;
    public int allBullets = 1000;
    public int gunMagazineCapacity = 15;
    public float gunReloadingTime = 2.0f;
    public float gunDelay = 0.5f;
    public LayerMask colleagues;
    public LayerMask obstruction;

}
