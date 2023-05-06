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

    //Array used to damage the players in the range of the enemy
    private GameObject[] attacking = new GameObject[2] { null, null };

    private bool inRange;

    private bool facingLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        AssignTarget();
        StartCoroutine(TargetClosest());
    }

    //Enemies move towards players until one of them is range
    void FixedUpdate()
    {
        if (!inRange)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                target.transform.position, 2f * Time.deltaTime);
        }

        Orientation();
    }

    /// <summary>
    /// Sees if the player is facing left or right
    /// </summary>
    private void Orientation()
    {
        if (facingLeft)
        {
            if (transform.position.x < target.transform.position.x)
            {
                transform.Rotate(0f, 180f, 0f);
                facingLeft = false;
            }
            else if (transform.position.x > target.transform.position.x)
            {
                transform.Rotate(Vector3.zero);
            }
        }
        else
        {
            if (transform.position.x > target.transform.position.x)
            {
                transform.Rotate(0f, 180f, 0f);
                facingLeft = true;
            }
            else if (transform.position.x < target.transform.position.x)
            {
                transform.Rotate(Vector3.zero);
            }
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

            //Adds the players to the array to be attacked
            if(attacking[0] == null)
            {
                //attacking[0] would be null if no players have
                //entered range yet
                attacking[0] = collision.gameObject;
                //Having the coroutine here makes it so that the enemy
                //doesn't attack twice
                StartCoroutine(Attack());
            }
            else
            {
                //This means a second player is in range while the first player is also in range
                attacking[1] = collision.gameObject;
            }
            //StartCoroutine(Attack());
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

            //If the second player leaves the range, it is no longer
            //able to be attacked
            if(attacking[1] != null)
            {
                attacking[1] = null;
            }
            //If the first player leaves the range, it is no longer
            //able to be attacked
            else
            {
                attacking[0] = null;
            }
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

        foreach (GameObject ctx in attacking)
        {
            if (ctx != null)
            {
                Debug.Log("Successfully attacked");
            }
            else
            {
                Debug.Log("Missed");
            }
        }

        if(inRange)
        {
            StartCoroutine(Attack());
            Debug.Log("Attacking again");
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
