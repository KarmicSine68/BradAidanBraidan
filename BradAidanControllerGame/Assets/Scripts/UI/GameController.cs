/*****************************************************************************
// File Name :         GameController.cs
// Author :            Aidan Ratcliffe
// Creation Date :     April 17th, 2023
//
// Brief Description : Where all the magic happens 
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public int EnemyCounter;
    EnemyBehavior Enemyspawn;
    public GameObject enemy;
    public TMP_Text EnemyCountText;
    public GameObject StartText;
    public GameObject Ranger;
    public PlayerInputManager pim;
    public GameObject CameraBorder;
    //public GameObject MovementText;
    //public GameObject LightAttackText;
    //public GameObject MediumAttackText;
    //public GameObject HeavyAttackText;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("deletetext", 2f);
        Enemyspawn = FindObjectOfType<EnemyBehavior>();
        //Enemyspawn.spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCountText.text = "Enemies : " + EnemyCounter.ToString() + " /10";

        if(GameObject.Find("Mage(Clone)") != null)
        {
            pim.playerPrefab = Ranger;
        }

        if (EnemyCounter >= 10)
        {
            if(GameObject.Find("CameraBorder") != null)
            {
                GameObject.Find("CameraBorder").SetActive(false);
            }
            
        }
    }

    void deletetext()
    {
        Destroy(StartText);
    }

    public void MovementText()
    {

    }

    public void LightAttackText()
    {

    }

    public void MediumAttackText()
    {

    }

    public void HeavyAttack()
    {

    }
}
