using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] public HealthBar healthBar;
    private float health;
    public static bool playerDied = false;

    

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
        healthBar.setHealth(health);
        if (health <= 0)
        {
            Die();
        }
        
    }

    private void Die()
    {
        playerDied = true;

    }

    private void InitializeVariables()
    {
        health = playerInfo.maxHealth;
    }

    private void SetLifeCanvas()
    {
        healthBar.SetMaxHealth(health);
    }

}
