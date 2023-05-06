/*****************************************************************************
// File Name :         BradGameController.cs
// Author :            Brad Dixon
// Creation Date :     May 4th, 2023
//
// Brief Description : Manages UI related to enemies, and deals 
//                     with enemy spawining
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BradGameController : MonoBehaviour
{
    //Checks to see if the tutorial is being skipped
    private bool tutorial;

    //How long it takes before more enemies spawn
    private float spawnTime;

    //How many enemies are in the wave
    private int enemyCount;

    //The different spawn points for the enemies
    [SerializeField] private GameObject spawn1;
    [SerializeField] private GameObject spawn2;
    [SerializeField] private GameObject spawn3;
    [SerializeField] private GameObject spawn4;
    [SerializeField] private GameObject spawn5;
    [SerializeField] private GameObject spawn6;
    [SerializeField] private GameObject spawn7;
    [SerializeField] private GameObject spawn8;

    [SerializeField] private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 2;
    }

    /// <summary>
    /// Spawns enemies after x time
    /// </summary>
    private void FixedUpdate()
    {
        /*if(gameStart)
        {
            if(tutorial)
            {
                if(enemyCount > 0)
                {
                    while(spawnTime > 0)
                    {
                        spawnTime -= 1 * Time.deltaTime;
                    }
                    SpawnEnemy();
                    spawnTime = Random.Range(0, 5) + 1;
                    Debug.Log(spawnTime);
                    enemyCount--;
                }
                else
                {
                    //Once all tutorial enemies are defeated, the tutorial
                    //ends and the enemy count is set to that of wave 1
                    tutorial = false;
                    enemyCount = 30;
                }
            }
            else
            {
                if (enemyCount > 0)
                {
                    while (spawnTime > 0)
                    {
                        spawnTime -= 1 * Time.deltaTime;
                    }
                    SpawnEnemy();
                    spawnTime = (int) Random.Range(0, 5) + 1;
                    Debug.Log(spawnTime);
                    enemyCount--;
                }
                else
                {
                    Debug.Log("Game Over");
                }
            }
        }*/
    }

    //Spawns an enemy at one of 8 spots
    private void SpawnEnemy()
    {
        //Randomizes the spawn location
        int x;
        x = Random.Range(0, 8);

        Vector3 spawn = new Vector3();

        switch(x)
        {
            case 0:
                spawn = spawn1.transform.position;
            break;

            case 1:
                spawn = spawn2.transform.position;
                break;

            case 2:
                spawn = spawn3.transform.position;
                break;

            case 3:
                spawn = spawn4.transform.position;
                break;

            case 4:
                spawn = spawn5.transform.position;
                break;

            case 5:
                spawn = spawn6.transform.position;
                break;

            case 6:
                spawn = spawn7.transform.position;
                break;

            case 7:
                spawn = spawn8.transform.position;
                break;

            default:
                break;
        }

        Instantiate(enemy, spawn, Quaternion.identity);
    }

    /// <summary>
    /// Spawns tutorial enemies if players choose to play the tutorial
    /// </summary>
    public void EnableTutorial()
    {
        enemyCount = 10;
        tutorial = true;
        StartCoroutine(SpawnEnemies());
    }

    /// <summary>
    /// Spawns wave 1 enemies if players choose to skip the tutorial
    /// </summary>
    public void SkipTutorial()
    {
        enemyCount = 30;
        tutorial = false;
        StartCoroutine(SpawnEnemies());
    }

    /// <summary>
    /// Starts spawning enemies
    /// </summary>
    IEnumerator SpawnEnemies()
    {
        if(tutorial)
        {
            while(enemyCount > 0)
            {
                spawnTime = (int)Random.Range(0, 5) + 1;
                while(spawnTime > 0)
                {
                    spawnTime--;
                    yield return new WaitForSeconds(1);
                }
                SpawnEnemy();
                enemyCount--;
            }

            //Once all tutorial enemies are defeated, the tutorial
            //ends and the enemy count is set to that of wave 1
            tutorial = false;
            enemyCount = 30;

            StartCoroutine(SpawnEnemies());
        }
        else
        {
            while (enemyCount > 0)
            {
                spawnTime = (int)Random.Range(0, 5) + 1;
                while (spawnTime > 0)
                {
                    spawnTime--;
                    yield return new WaitForSeconds(1);
                }
                SpawnEnemy();
                enemyCount--;
            }
            Debug.Log("Game Over");
        }
    }
}
