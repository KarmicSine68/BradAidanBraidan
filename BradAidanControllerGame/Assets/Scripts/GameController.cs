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
            SceneManager.LoadScene("WinScreen");
        }
    }

    void deletetext()
    {
        Destroy(StartText);
    }
}
