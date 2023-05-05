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
    private bool gameStart;
    //Checks to see if the tutorial is being skipped
    private bool tutorial;

    //How long it takes before more enemies spawn
    private float spawnTime;

    //How many enemies are in the wave
    private int enemyCount;

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
        if(gameStart)
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
                    spawnTime = (int) Random.Range(0, 5) + 1;
                    Debug.Log(spawnTime);
                }
                else
                {
                    //Once all tutorial enemies are defeated, the tutorial
                    //ends and the enemy count is set to that of wave 1
                    tutorial = false;
                    enemyCount = 30;
                }
            }
        }
    }

    //Spawns an enemy at one of 8 spots
    private void SpawnEnemy()
    {

    }

    /// <summary>
    /// Spawns tutorial enemies if players choose to play the tutorial
    /// </summary>
    public void EnableTutorial()
    {
        tutorial = true;
        enemyCount = 10;
    }

    /// <summary>
    /// Spawns wave 1 enemies if players choose to skip the tutorial
    /// </summary>
    public void SkipTutorial()
    {
        tutorial = false;
        enemyCount = 30;
    }
}
