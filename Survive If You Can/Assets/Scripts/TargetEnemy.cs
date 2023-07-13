using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour
{
    [SerializeField] private EnemyInfo enemyInfo;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float health;
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
        //Debug.Log("Health: " + health);
        if (health <= 0)
        {
            Die();
        }
        healthBar.setHealth(health);
        //healthBar.setHealth(health);
    }

    private void Die()
    {
        Player.GetComponent<ScoreCalculator>().enemyKilled(bonusPoints);
        Destroy(gameObject);
    }

    private void InitializeVariables()
    {
        health = enemyInfo.maxHealth;
        maxHealth = enemyInfo.maxHealth;
        Player = GameObject.FindGameObjectWithTag("Player");
        bonusPoints = enemyInfo.killingBonusPoints;
           // FindObjectOfType
    }

    private void SetLifeCanvas()
    {
        healthBar.SetMaxHealth(health);
    }
}