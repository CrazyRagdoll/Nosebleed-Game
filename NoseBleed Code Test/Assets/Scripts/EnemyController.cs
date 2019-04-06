using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameController gameController;

    public GameObject enemy;

    List<Vector3> spawnlocations = new List<Vector3>();

    public int enemiesRemaining = 0;

    private void Awake()
    {
        //Tell the enemy prefab this is it's controller.
        enemy.GetComponent<Enemy>().enemyController = this;

        //Calculate the spawn points in the map
        for (int i = 0; i < transform.Find("SpawnPoints").childCount; i++)
        {
            spawnlocations.Add(transform.Find("SpawnPoints").GetChild(i).transform.position);
        }
    }

    public void SpawnEnemiesInLevel(int numEnemies)
    {
        if(numEnemies <= 10)
        {
            InstantSpawnEnemies(numEnemies);
        }
        else
        {
            //Spawn in lots and then after a delay!
            InstantSpawnEnemies(10);
            StartCoroutine(DelayedSpawnEnemies(numEnemies - 10, 2.5f));
        }
    }

    //Instantly spawn a bunch of peoples
    public void InstantSpawnEnemies(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        { 
            //Grab a random spawn point in the map
            int spawnPoint = Random.Range(0, spawnlocations.Count); 

            //Spawn an enemy there!
            Instantiate(enemy, spawnlocations[spawnPoint], Quaternion.identity);

            enemiesRemaining++;
        }
    }

    //Spawn on a timer
    public IEnumerator DelayedSpawnEnemies(int numEnemies, float delay)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            //Grab a random spawn point in the map
            int spawnPoint = Random.Range(0, spawnlocations.Count);

            //Spawn an enemy there!
            Instantiate(enemy, spawnlocations[spawnPoint], Quaternion.identity);

            enemiesRemaining++;

            //Delay
            yield return new WaitForSeconds(delay);
        }
    }
}
