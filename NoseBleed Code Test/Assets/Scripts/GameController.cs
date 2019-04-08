﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public EnemyController enemyController;

    public int level;
    public int score;
    public float difficultyMod = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        enemyController.SpawnEnemiesInLevel(Mathf.CeilToInt(level * difficultyMod));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(0);
        }

        if (player.GetComponent<PlayerController>().health <= 0)
        {
            SceneManager.LoadScene(0);
        }

        if(enemyController.enemiesRemaining <= 0)
        {
            StartNextLevel();
        }
    }

    void StartNextLevel()
    {
        level++;
        score += (int)(level * difficultyMod);
        enemyController.SpawnEnemiesInLevel(Mathf.CeilToInt(level * difficultyMod));
    }
}
