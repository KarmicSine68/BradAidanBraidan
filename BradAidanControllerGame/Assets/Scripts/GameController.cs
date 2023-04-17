using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int EnemyCounter;
    EnemyBehavior Enemyspawn;
    public GameObject enemy;
    public TMP_Text EnemyCountText;

    // Start is called before the first frame update
    void Start()
    {
        Enemyspawn = FindObjectOfType<EnemyBehavior>();
        //Enemyspawn.spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCountText.text = "Enemies : " + " /10" + EnemyCounter.ToString();


        if (EnemyCounter == 10)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
