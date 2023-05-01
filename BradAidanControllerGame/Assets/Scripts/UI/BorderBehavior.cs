/*****************************************************************************
// File Name :         BorderBehavior.cs
// Author :            Aidan Ratcliffe
// Creation Date :     April 30th, 2023
//
// Brief Description : Spawns a border/bounding box whenever enemies approach
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBehavior : MonoBehaviour
{
    public GameObject CameraBorder;
    public EnemyBehavior Enemy;
    public PlayerBehaviour Player;
    public int speed;
    public GameObject CameraPos;

    // Start is called before the first frame update
    void Start()
    {
        CameraBorder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBehavior rb = GetComponent<EnemyBehavior>();

        if (collision.gameObject.tag == "Enemy")
        {
            CameraBorder.SetActive(true);
        }
    }

    public void CameraPosition()
    {
        float yMove = Input.GetAxis("Vertical");
        float xMove = Input.GetAxis("Horizontal");
        Vector3 newPos = Player.transform.position; //attaches the camera to the player position without attaching it to the rotation
        //newPos.x += (1.5f + (xMove * Time.deltaTime * speed)); //1.5f because the beginning position of the spaceship is at -2, and the camera's preset position is -0.5
        newPos.y += yMove * Time.deltaTime * speed;
        newPos.z = -10f; //permanent zoom out camera (calling newPos sets to z = 0)
        newPos.y = Mathf.Clamp(newPos.y, -5.4f, 5.4f);
        newPos.x = Mathf.Clamp(newPos.x, -10.8f, 10.8f);
        transform.position = newPos;
    }

}
