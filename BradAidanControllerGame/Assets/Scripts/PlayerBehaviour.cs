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
    Vector2 movement;
    Rigidbody2D rb2D;

    /// <summary>
    /// Listens to the entire action map to see when the player uses an action.
    /// Allows for indivudal input for different controllers.
    /// </summary>
    /// <param name="ctx"></param>
    public void Move(InputAction.CallbackContext ctx) 
        => movement = ctx.ReadValue<Vector2>();

    /// <summary>
    /// Detects input and executes code
    /// </summary>
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.freezeRotation = true;
    }

    /// <summary>
    /// Moves the player
    /// </summary>
    private void FixedUpdate()
    {
            Vector2 moveVelocity = new Vector2(movement.x, movement.y) * 150f
                * Time.deltaTime;
            rb2D.velocity = moveVelocity;
    }
}
