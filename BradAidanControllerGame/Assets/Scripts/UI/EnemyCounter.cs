using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class EnemyCounter : MonoBehaviour
{
    [SerializeField] TMP_Text enemyCounter;

    private int enemiesSlayed, enemiesTotal;

    private bool tutorial;

    private bool gameStart = false;

    /// <summary>
    /// Updates the enemy counter when an enemy is defeated
    /// </summary>
    void Update()
    {
        enemyCounter.text = "Enemies: " + enemiesSlayed + "/" + enemiesTotal;

        if (gameStart)
        {
            if (enemiesSlayed >= enemiesTotal)
            {
                if (tutorial)
                {
                    gameObject.GetComponent<BradGameController>().BeginLevel();
                }
                else
                {
                    SceneManager.LoadScene("WinScreen");
                }
            }
        }
    }

    public void EnemyKilled()
    {
        enemiesSlayed++;
    }

    public void Tutorial()
    {
        tutorial = true;
        enemiesSlayed = 0;
        enemiesTotal = 10;
        gameStart = true;
    }

    public void Level1()
    {
        tutorial = false;
        enemiesSlayed = 0;
        enemiesTotal = 30;
        gameStart = true;
    }
}
