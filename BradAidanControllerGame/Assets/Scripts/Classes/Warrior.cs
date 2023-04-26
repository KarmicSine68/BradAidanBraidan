/*****************************************************************************
// File Name :         Warrior.cs
// Author :            Brad Dixon
// Creation Date :     March 28th, 2023
// Brief Description : Data for the warrior
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : ClassChanger
{
    PlayerControls controls;

    [SerializeField] GameObject weapon;

    //Time variables used for coroutines
    private float attackDelayTime;
    private float comboCancelTime = 2f;

    //Bool to make sure players can't attack until the previous attack
    //has finished
    private bool canAttack = true;

    //Used to store what attack and where it is in the combo
    private string firstHit = "";
    private string secondHit = "";

    //Using an int varaible to determine which combo is being done
    //1 = L,L    2 = L,M    3 = L,H    4 = M,L
    //5 = M,M    6 = H,M    7 = H,H    
    private int comboNum;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.PlayerActions.Light.performed += ctx => Light();
        controls.PlayerActions.Medium.performed += ctx => Medium();
        controls.PlayerActions.Heavy.performed += ctx => Heavy();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //After the first hit is thrown, activates a timer that ends the combo
        //early if an attack isn't used fast enough
        if(firstHit != "")
        {
            comboCancelTime -= Time.deltaTime;

            //Cancels the combo early
            if (comboCancelTime <= 0)
            {
                firstHit = "";
                secondHit = "";
                Debug.Log("Combo canceled");
            }
        }
    }

    /// <summary>
    /// Executes the light version of the chain attack
    /// </summary>
    private void Light()
    {
        if (canAttack)
        {
            ComboOrder("Light");
        }
    }

    /// <summary>
    /// Executes the medium version of the chain attack
    /// </summary>
    private void Medium()
    {
        if (canAttack)
        {
            ComboOrder("Medium");
        }
    }

    /// <summary>
    /// Executes the heavy version of the chain attack
    /// </summary>
    private void Heavy()
    {
        if (canAttack)
        {
            ComboOrder("Heavy");
        }
    }

    /// <summary>
    /// Checks where in the combo a player is
    /// </summary>
    /// <param name="type"></param>
    private void ComboOrder(string type)
    {
        //If a variable doesn't have a value, then it means that that's where
        //a player is in the combo. The first hit not having a value means
        //a combo hasn't started yet.

        //Checks to see if it is the first hit in the combo by seeing if
        //the variable has a value
        if (firstHit == "")
        {
            firstHit = type;
            comboCancelTime = 2f;
        }
        //If the first variable has a value, it then checks to see if
        //the second hit has a value
        else if (secondHit == "")
        {
            //Checks to see if the first hit in the combo was a light, medium,
            //or heavy attack
            if(firstHit == "Light")
            {
                switch(type)
                {
                    case "Light":
                        comboNum = 1;
                        secondHit = type;
                        comboCancelTime = 2f;
                        break;

                    case "Medium":
                        comboNum = 2;
                        secondHit = type;
                        comboCancelTime = 2f;
                        break;

                    case "Heavy":
                        comboNum = 3;
                        secondHit = type;
                        comboCancelTime = 2f;
                        break;

                    default:
                        break;
                }
            }
            else if(firstHit == "Medium")
            {
                switch (type)
                {
                    case "Light":
                        comboNum = 4;
                        secondHit = type;
                        comboCancelTime = 2f;
                        break;

                    case "Medium":
                        comboNum = 5;
                        secondHit = type;
                        comboCancelTime = 2f;
                        break;

                    default:
                        break;
                }
            }
            else if(firstHit == "Heavy")
            {
                switch (type)
                {
                    case "Medium":
                        comboNum = 6;
                        secondHit = type;
                        comboCancelTime = 2f;
                        break;

                    case "Heavy":
                        comboNum = 7;
                        secondHit = type;
                        comboCancelTime = 2f;
                        break;

                    default:
                        break;
                }
            }
        }
        //We only have three hits max in our combos, so if it reaches the end,
        //the values get reset to blank
        else
        {
            //The first switch statement is used to see what the first two
            //hits are
            switch(comboNum)
            {
                case 1:
                    switch(type)
                    {
                        case "Light":
                            Debug.Log("Combo: L,L,L");
                            firstHit = "";
                            secondHit = "";
                            break;

                        case "Medium":
                            Debug.Log("Combo: L,L,M");
                            firstHit = "";
                            secondHit = "";
                            break;

                        case "Heavy":
                            Debug.Log("Combo: L,L,H");
                            firstHit = "";
                            secondHit = "";
                            break;

                        default:
                            break;
                    }
                    break;

                case 2:
                    switch (type)
                    {
                        case "Medium":
                            Debug.Log("Combo: L,M,M");
                            firstHit = "";
                            secondHit = "";
                            break;

                        case "Heavy":
                            Debug.Log("Combo: L,M,H");
                            firstHit = "";
                            secondHit = "";
                            break;

                        default:
                            break;
                    }
                    break;

                case 3:
                    switch (type)
                    {
                        case "Heavy":
                            Debug.Log("Combo: L,H,H");
                            firstHit = "";
                            secondHit = "";
                            break;

                        default:
                            break;
                    }
                    break;

                case 4:
                    switch (type)
                    {
                        case "Light":
                            Debug.Log("Combo: M,L,L");
                            firstHit = "";
                            secondHit = "";
                            break;

                        case "Medium":
                            Debug.Log("Combo: M,L,M");
                            firstHit = "";
                            secondHit = "";
                            break;

                        case "Heavy":
                            Debug.Log("Combo: M,L,H");
                            firstHit = "";
                            secondHit = "";
                            break;

                        default:
                            break;
                    }
                    break;

                case 5:
                    switch (type)
                    {
                        case "Medium":
                            Debug.Log("Combo: M,H,M");
                            firstHit = "";
                            secondHit = "";
                            break;

                        case "Heavy":
                            Debug.Log("Combo: M,H,H");
                            firstHit = "";
                            secondHit = "";
                            break;

                        default:
                            break;
                    }
                    break;

                case 6:
                    switch (type)
                    {
                        case "Medium":
                            Debug.Log("Combo: H,M,M");
                            firstHit = "";
                            secondHit = "";
                            break;

                        case "Heavy":
                            Debug.Log("Combo: H,M,H");
                            firstHit = "";
                            secondHit = "";
                            break;

                        default:
                            break;
                    }
                    break;

                case 7:
                    switch (type)
                    {
                        case "Medium":
                            Debug.Log("Combo: H,H,M");
                            firstHit = "";
                            secondHit = "";
                            break;

                        case "Heavy":
                            Debug.Log("Combo: H,H,H");
                            firstHit = "";
                            secondHit = "";
                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Makes it so players can't spam attacks, they have to wait a bit between
    /// attacks before sending another one
    /// </summary>
    /// <returns></returns>
    IEnumerator AttackDelay()
    {
        canAttack = false;
        Debug.Log("Can't attack");
        yield return new WaitForSeconds(attackDelayTime);
        canAttack = true;
        Debug.Log("Can attack");
    }

    /// <summary>
    /// Ends a combo early if a player doesn't attack in time
    /// </summary>
    /// <returns></returns>
    IEnumerator ComboCancel()
    {
        yield return new WaitForSeconds(comboCancelTime);
        firstHit = "";
        secondHit = "";
        Debug.Log("Combo ended");
    }

    private void OnEnable()
    {
        controls.PlayerActions.Enable();
    }

    private void OnDisable()
    {
        controls.PlayerActions.Disable();
    }
}
