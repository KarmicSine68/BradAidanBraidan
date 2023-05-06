/*****************************************************************************
// File Name :         BradEnemyBehavior.cs
// Author :            Brad Dixon
// Creation Date :     April 26th, 2023
//
// Brief Description : Enemy AI and spawning
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BradEnemyBehaviour : MonoBehaviour
{
    //Gets an array of the players and assigns one of them as the target
    private GameObject[] player = new GameObject[2];
    private GameObject target;

    private bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        AssignTarget();
        StartCoroutine(TargetClosest());
    }

    //Enemies move towards players until one of them is range
    void Update()
    {
        if (!inRange)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                target.transform.position, 2f * Time.deltaTime);
        }
    }

    private void AssignTarget()
    {
        //Used to record the distance of the players from the enemy
        float distance = 0;

        foreach(GameObject ctx in player)
        {
            //The x and y positions of the player and enemy
            //x1 and y1 are the enemy, x2 and y2 are the player
            float x1 = gameObject.transform.position.x;
            float x2 = ctx.transform.position.x;
            float y1 = gameObject.transform.position.y;
            float y2 = ctx.transform.position.y;

            //The sum that will be squarerooted to find distance
            float sum;

            //Fun math time. Using the distance formulat to find the 
            sum = (Mathf.Pow(x2 - x1, 2) + Mathf.Pow(y2 - y1, 2));

            sum = Mathf.Sqrt(sum);

            if(distance == 0)
            {
                distance = sum;
                target = ctx;
            }
            //If the new distance is closer, assign that as the target instead
            else if(distance >= sum)
            {
                distance = sum;
                target = ctx;
            }
        }
    }

    /// <summary>
    /// Stops the enemies from moving into the player
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            inRange = true;
            StartCoroutine(Attack());
        }
    }

    /// <summary>
    /// If a player moves out of range, the enemy moves closer
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    /// <summary>
    /// Checks to see if the enemy successfully hits a player at the end 
    /// of their attack period
    /// </summary>
    /// <returns></returns>
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.5f);
        if(inRange)
        {
            Debug.Log("Successfully attacked");
            StartCoroutine(Attack());
        }
        else
        {
            Debug.Log("Missed");
        }
    }

    /// <summary>
    /// After x seconds, enemy targets the closest player
    /// </summary>
    /// <returns></returns>
    IEnumerator TargetClosest()
    {
        int x = Random.Range(10, 16);

        yield return new WaitForSeconds(x);

        Debug.Log("Attacking closest");
        AssignTarget();
        StartCoroutine(TargetClosest());
    }
}
