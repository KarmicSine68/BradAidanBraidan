/*****************************************************************************
// File Name :         PlayerBehaviour.cs
// Author :            Brad Dixon
// Creation Date :     March 21st, 2023
//
// Brief Description : Movement for the player
// Help video:         https://www.bing.com/videos/search?q=how+to+add+multiple+controllers+in+Unity&docid=603500616588278220&mid=DFAEA9522B82241EB683DFAEA9522B82241EB683&view=detail&FORM=VIRE
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction move;

    Vector2 movement;
    Rigidbody2D rb2D;
    [SerializeField] float speed = 150;
    [SerializeField] string className;
    string type;
    public bool facingLeft;

    /// <summary>
    /// Finds the name of a gameObject that the player is colliding with
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        type = collision.name;
        MyName();
    }

    /// <summary>
    /// Takes the name of the gameObject and changes the class accordingly
    /// </summary>
    private void MyName()
    {
        switch(type)
        {
            case "Fighter":
                gameObject.GetComponent<Ranger>().enabled = false;
                gameObject.GetComponent<Warrior>().enabled = true;
                break;
            case "Mage":
                gameObject.GetComponent<Warrior>().enabled = false;
                gameObject.GetComponent<Ranger>().enabled = true;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Detects input and executes code
    /// </summary>
    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActions");
        move = inputMap.FindAction("Movement");

        move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        move.performed += ctx => Orientation();
        move.canceled += ctx => movement = Vector2.zero;

        rb2D = GetComponent<Rigidbody2D>();

        facingLeft = false;
    }

    private void Orientation()
    {
        if (facingLeft)
        {
            if (movement.x > 0)
            {
                transform.Rotate(0f, 180f, 0f);
                facingLeft = false;
            }
            else if (movement.x < 0)
            {
                transform.Rotate(Vector3.zero);
            }
        }
        else
        {
            if (movement.x < 0)
            {
                transform.Rotate(0f, 180f, 0f);
                facingLeft = true;
            }
            else if (movement.x > 0)
            {
                transform.Rotate(Vector3.zero);
            }
        }
    }

    /// <summary>
    /// Moves the player
    /// </summary>
    private void FixedUpdate()
    {
        Vector2 moveVelocity = new Vector2(movement.x, movement.y) * 5f
            * Time.deltaTime;
        transform.Translate(moveVelocity, Space.World);
    }

    /// <summary>
    /// Allows for the code to recieve player inputs
    /// </summary>
    private void OnEnable()
    {
        inputMap.Enable();
    }

    /// <summary>
    /// Stops the code from recieving player input
    /// </summary>
    private void OnDisable()
    {
        inputMap.Disable();
    }
}
