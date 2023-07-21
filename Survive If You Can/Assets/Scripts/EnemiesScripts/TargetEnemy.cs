using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour
{
    [SerializeField] private EnemyInfo enemyInfo;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float health;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private AdaptiveBehavior adaptiveBehavior;
    private float maxHealth;
    private GameObject Player;
    private int bonusPoints;

    // Start is called before the first frame update
    void Start()
    {
        InitializeVariables();
        SetLifeCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        healthBar.setHealth(health);

    }

    private void Die()
    {
        Player.GetComponent<ScoreCalculator>().enemyKilled(bonusPoints);

        int currentRoomNumber = getRoomNumber();
        
        spawnManager.SpawnRequest(adaptiveBehavior.getEnemyType(), currentRoomNumber);

        Destroy(transform.parent.gameObject);
    }

    private int getRoomNumber()
    {
        string roomName = transform.parent.parent.parent.name;
        return ((int)(roomName[roomName.Length - 1]) - 48);
    }

    private void InitializeVariables()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        health = enemyInfo.maxHealth;
        maxHealth = enemyInfo.maxHealth;
        Player = GameObject.FindGameObjectWithTag("Player");
        bonusPoints = enemyInfo.killingBonusPoints;
    }

    private void SetLifeCanvas()
    {
        healthBar.SetMaxHealth(health);
    }
}
