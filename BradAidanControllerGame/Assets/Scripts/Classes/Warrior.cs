/*****************************************************************************
// File Name :         Warrior.cs
// Author :            Brad Dixon
// Creation Date :     March 28th, 2023
// Brief Description : Data for the warrior
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Warrior : MonoBehaviour
{
    //Input variables to make sure both players don't attack when one
    //person presses an input.
    InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction lightAttack;
    InputAction mediumAttack;
    InputAction heavyAttack;

    //Prefabs of the light, medium, and heavy attacks.
    //Used to play the attack animations.
    [SerializeField] private GameObject lightWeapon;
    [SerializeField] private GameObject mediumWeapon;
    [SerializeField] private GameObject heavyWeapon;

    //Time variables used for coroutines.
    private float comboCancelTime = 2f;

    //Bool to make sure players can't attack until the previous attack
    //has finished.
    private bool canAttack = true;

    //Checks to make sure the enemy is in the range of the attack
    private bool inRange;

    private GameObject target;

    //Used to store what attack and where it is in the combo.
    private string firstHit = "";
    private string secondHit = "";

    //Using an int varaible to determine which combo is being done
    //1 = L,L    2 = L,M    3 = L,H    4 = M,L
    //5 = M,M    6 = H,M    7 = H,H    
    private int comboNum;

    private void Awake()
    {
        //player = new PlayerBehaviour();

        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActions");
        lightAttack = inputMap.FindAction("Light");
        mediumAttack = inputMap.FindAction("Medium");
        heavyAttack = inputMap.FindAction("Heavy");

        lightAttack.performed += ctx => Light();
        mediumAttack.performed += ctx => Medium();
        heavyAttack.performed += ctx => Heavy();
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

    /*private void AttackAnimation(GameObject attack)
    {
        Vector3 leftRotate = new Vector3(0, 180, 0);
        Vector3 weaponPos = new Vector3(transform.position.x + .4f, 
            transform.position.y - .2f, transform.position.z);
        GameObject weapon = Instantiate(attack, weaponPos, Quaternion.identity);
        if(player.facingLeft == false)
        {
            //weapon.transform.rotation = Quaternion.EulerAngles(0, 180, 0);
        }
    }*/

    /// <summary>
    /// Executes the light version of the chain attack
    /// </summary>
    private void Light()
    {
        if (canAttack)
        {
            ComboOrder("Light");
            //AttackAnimation(lightWeapon);
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
        //Checks to make sure the Warrior script is enabled
        if (gameObject.GetComponent<Warrior>().enabled)
        {
            //If a variable doesn't have a value, then it means that that's where
            //a player is in the combo. The first hit not having a value means
            //a combo hasn't started yet.

            //Checks to see if it is the first hit in the combo by seeing if
            //the variable has a value
            if (firstHit == "")
            {
                firstHit = type;

                switch(type)
                {
                    case "Light":
                        StartCoroutine(AttackDelay(0.3f, lightWeapon, 2));
                        comboCancelTime = 1.2f;
                        break;

                    case "Medium":
                        StartCoroutine(AttackDelay(0.5f, mediumWeapon, 4));
                        comboCancelTime = 1.4f;
                        break;

                    case "Heavy":
                        StartCoroutine(AttackDelay(0.8f, heavyWeapon, 6));
                        comboCancelTime = 1.7f;
                        break;

                    default:
                        break;
                }

                //comboCancelTime = 2f;
            }
            //If the first variable has a value, it then checks to see if
            //the second hit has a value
            else if (secondHit == "")
            {
                //Checks to see if the first hit in the combo was a light, medium,
                //or heavy attack
                if (firstHit == "Light")
                {
                    switch (type)
                    {
                        case "Light":
                            comboNum = 1;
                            secondHit = type;
                            StartCoroutine(AttackDelay(0.3f, lightWeapon, 2));
                            comboCancelTime = 1.2f;
                            break;

                        case "Medium":
                            comboNum = 2;
                            secondHit = type;
                            StartCoroutine(AttackDelay(0.5f, mediumWeapon, 4));
                            comboCancelTime = 1.4f;
                            break;

                        case "Heavy":
                            comboNum = 3;
                            secondHit = type;
                            StartCoroutine(AttackDelay(0.8f, heavyWeapon, 6));
                            comboCancelTime = 1.7f;
                            break;

                        default:
                            break;
                    }
                }
                else if (firstHit == "Medium")
                {
                    switch (type)
                    {
                        case "Light":
                            comboNum = 4;
                            secondHit = type;
                            StartCoroutine(AttackDelay(0.3f, lightWeapon, 2));
                            comboCancelTime = 1.2f;
                            break;

                        case "Medium":
                            comboNum = 5;
                            secondHit = type;
                            StartCoroutine(AttackDelay(0.5f, mediumWeapon, 4));
                            comboCancelTime = 1.4f;
                            break;

                        default:
                            break;
                    }
                }
                else if (firstHit == "Heavy")
                {
                    switch (type)
                    {
                        case "Medium":
                            comboNum = 6;
                            secondHit = type;
                            StartCoroutine(AttackDelay(0.5f, mediumWeapon, 4));
                            comboCancelTime = 1.4f;
                            break;

                        case "Heavy":
                            comboNum = 7;
                            secondHit = type;
                            StartCoroutine(AttackDelay(0.8f, heavyWeapon, 6));
                            comboCancelTime = 1.7f;
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
                switch (comboNum)
                {
                    case 1:
                        switch (type)
                        {
                            case "Light":
                                Debug.Log("Combo: L,L,L");
                                firstHit = "";
                                secondHit = "";
                                StartCoroutine(AttackDelay(0.3f, lightWeapon, 2));
                                break;

                            case "Medium":
                                Debug.Log("Combo: L,L,M");
                                firstHit = "";
                                secondHit = "";
                                StartCoroutine(AttackDelay(0.5f, mediumWeapon, 4));
                                break;

                            case "Heavy":
                                Debug.Log("Combo: L,L,H");
                                firstHit = "";
                                secondHit = "";
                                StartCoroutine(AttackDelay(0.8f, heavyWeapon, 6));
                                comboCancelTime = 1.7f;
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
                                StartCoroutine(AttackDelay(0.5f, mediumWeapon, 4));
                                break;

                            case "Heavy":
                                Debug.Log("Combo: L,M,H");
                                firstHit = "";
                                secondHit = "";
                                StartCoroutine(AttackDelay(0.8f, heavyWeapon, 6));
                                comboCancelTime = 1.7f;
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
                                StartCoroutine(AttackDelay(0.8f, heavyWeapon, 6));
                                comboCancelTime = 1.7f;
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
                                StartCoroutine(AttackDelay(0.3f, lightWeapon, 2));
                                break;

                            case "Medium":
                                Debug.Log("Combo: M,L,M");
                                firstHit = "";
                                secondHit = "";
                                StartCoroutine(AttackDelay(0.5f, mediumWeapon, 4));
                                break;

                            case "Heavy":
                                Debug.Log("Combo: M,L,H");
                                firstHit = "";
                                secondHit = "";
                                StartCoroutine(AttackDelay(0.8f, heavyWeapon, 6));
                                comboCancelTime = 1.7f;
                                break;

                            default:
                                break;
                        }
                        break;

                    case 5:
                        switch (type)
                        {
                            case "Medium":
                                Debug.Log("Combo: M,M,M");
                                firstHit = "";
                                secondHit = "";
                                StartCoroutine(AttackDelay(0.5f, mediumWeapon, 4));
                                break;

                            case "Heavy":
                                Debug.Log("Combo: M,M,H");
                                firstHit = "";
                                secondHit = "";
                                StartCoroutine(AttackDelay(0.8f, heavyWeapon, 6));
                                comboCancelTime = 1.7f;
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
                                StartCoroutine(AttackDelay(0.5f, mediumWeapon, 4));
                                break;

                            case "Heavy":
                                Debug.Log("Combo: H,M,H");
                                firstHit = "";
                                secondHit = "";
                                StartCoroutine(AttackDelay(0.8f, heavyWeapon, 6));
                                comboCancelTime = 1.7f;
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
                                StartCoroutine(AttackDelay(0.5f, mediumWeapon, 4));
                                break;

                            case "Heavy":
                                Debug.Log("Combo: H,H,H");
                                firstHit = "";
                                secondHit = "";
                                StartCoroutine(AttackDelay(0.8f, heavyWeapon, 6));
                                comboCancelTime = 1.7f;
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
    }

    /// <summary>
    /// Makes it so players can't spam attacks, they have to wait a bit between
    /// attacks before sending another one
    /// </summary>
    /// <returns></returns>
    IEnumerator AttackDelay(float attackDelayTime, GameObject weapon, int damage)
    {
        canAttack = false;
        weapon.SetActive(true);
        yield return new WaitForSeconds(attackDelayTime);

        if(inRange)
        {
            target.SendMessage("Attacked", damage);
            Debug.Log("Attacking");
        }
        weapon.SetActive(false);
        canAttack = true;
        Debug.Log("Can attack");
    }

    private void OnEnable()
    {
        inputMap.Enable();
    }

    private void OnDisable()
    {
        inputMap.Disable();
    }

    /// <summary>
    /// Enables the check when an enemy is in range of an attack
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            inRange = true;
            target = collision.gameObject;
        }
    }

    /// <summary>
    /// Disables check when enemy is out of range
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }
}
