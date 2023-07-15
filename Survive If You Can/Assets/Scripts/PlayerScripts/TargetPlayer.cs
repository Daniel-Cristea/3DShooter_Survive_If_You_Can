using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] public HealthBar healthBar;
    [SerializeField] private PauseControl pauseControl;
    private float health;
    private float maxHealth;
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
        if (Input.GetKeyDown(KeyCode.L))
        {
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }
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
       // pauseControl.playerDied();
    }

    private void InitializeVariables()
    {
        health = playerInfo.maxHealth;
        maxHealth= playerInfo.maxHealth;
    }

    private void SetLifeCanvas()
    {
        healthBar.SetMaxHealth(health);
    }

}
