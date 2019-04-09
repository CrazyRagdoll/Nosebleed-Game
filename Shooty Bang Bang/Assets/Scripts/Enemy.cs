using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public CharacterController2D controller;

    public EnemyController enemyController;

    public int health = 100;
    public int power = 25;
    private int moveSpeed = 40;

    private int jumpDelay = 0;

    public GameObject deathEffect;

    public GameObject heartObject;

    public void Awake()
    {
        player = enemyController.gameController.player.GetComponent<Transform>();
    }

    public void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Vector3 dirToPlayer = player.position - transform.position;

        int move;
        if (dirToPlayer.x < 0) move = -1; else move = 1;

        //Some insanely bad AI
        bool jump = false;
        if (dirToPlayer.y > 0.25)
        {
            jumpDelay++;
            if (jumpDelay > 25)
            {
                jump = true;
                jumpDelay = 0;
            }
        }

        //Lets move the enemies!
        controller.Move(move * Time.fixedDeltaTime * moveSpeed, false, jump);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Chance to spawn health
        if (Random.Range(0, 100) >= 80)
        {
            Instantiate(heartObject, transform.position, Quaternion.identity);
        }
        
        //Death EXPLOSIONS
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        
        //Remove itself from the list
        enemyController.DespawnEnemy(gameObject);

        //Destroy the enemy 
        Destroy(gameObject);
    }
}
