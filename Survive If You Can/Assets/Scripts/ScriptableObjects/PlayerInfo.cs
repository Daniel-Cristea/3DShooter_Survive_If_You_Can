using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "ScriptableObjects/PlayerInfoScriptableObject", order = 1)]
public class PlayerInfo : ScriptableObject
{
    public float slowMovementSpeed = 5.0f;
    public float fastMovementSpeed = 7.0f;
    public float maxHealth = 100.0f;
    public float cameraRotationSpeed = 720.0f;
    public float gunRange = 40.0f;
    public float gunDamage = 4.0f;
    public int gunMagazineCapacity = 30;
    public float gunReloadingTime = 3.0f;
    public float gunDelay;
    public int allBullets = 600;
    public float bulletSpeed = 10;
    public float bulletLife = 3;
}
