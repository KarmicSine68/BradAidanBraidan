/*****************************************************************************
// File Name :         BradMage.cs
// Author :            Brad Dixon
// Creation Date :     May 7th, 2023
//
// Brief Description : The attack script for the mage class
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BradMage : MonoBehaviour
{
    //The spawnpoint for the spells
    [SerializeField] private GameObject spawn;

    //The spells for the mage
    [SerializeField] private GameObject lightSpell;
    //[SerializeField] private GameObject mediumSpell;
    [SerializeField] private GameObject heavySpell;

    InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction lightAttack;
    InputAction mediumAttack;
    InputAction heavyAttack;

    private bool canAttack;

    PlayerBehaviour aim;

    /// <summary>
    /// The input actions for the mage player
    /// </summary>
    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActions");
        lightAttack = inputMap.FindAction("Light");
        mediumAttack = inputMap.FindAction("Medium");
        heavyAttack = inputMap.FindAction("Heavy");

        lightAttack.performed += ctx => Attack("Light");
        mediumAttack.performed += ctx => Attack("Medium");
        heavyAttack.performed += ctx => Attack("Heavy");

        aim = gameObject.GetComponent<PlayerBehaviour>();

        canAttack = true;
    }

    /// <summary>
    /// Spawns a spell to damage enemies
    /// </summary>
    /// <param name="type"></param>
    private void Attack(string type)
    {
        if(canAttack)
        {
            Vector2 direction1;
            Vector2 direction2;
            Vector2 direction3;

            if (aim.facingLeft)
            {
                direction1 = new Vector2(-10, 0);
                direction2 = new Vector2(-5, 5);
                direction3 = new Vector2(-5, -5);
            }
            else
            {
                direction1 = new Vector2(10, 0);
                direction2 = new Vector2(5, 5);
                direction3 = new Vector2(5, -5);
            }
            switch (type)
            {
                case "Light":
                    GameObject lSpell = Instantiate(lightSpell, 
                        spawn.transform.position, Quaternion.identity);

                    lSpell.GetComponent<Rigidbody2D>().velocity = direction1;

                    StartCoroutine(AttackDelay(0.5f));
                    break;

                case "Medium":
                    GameObject mSpell1 = Instantiate(lightSpell,
                        spawn.transform.position, Quaternion.identity);
                    GameObject mSpell2 = Instantiate(lightSpell,
                        spawn.transform.position, Quaternion.identity);
                    GameObject mSpell3 = Instantiate(lightSpell,
                        spawn.transform.position, Quaternion.identity);

                    mSpell1.GetComponent<Rigidbody2D>().velocity = direction1;
                    mSpell2.GetComponent<Rigidbody2D>().velocity = direction2;
                    mSpell3.GetComponent<Rigidbody2D>().velocity = direction3;

                    StartCoroutine(AttackDelay(0.8f));
                    break;

                case "Heavy":
                    GameObject hSpell = Instantiate(heavySpell, 
                        spawn.transform.position, Quaternion.identity);

                    if(aim.facingLeft)
                    {
                        hSpell.transform.Rotate(0, 180, 0);
                    }

                    StartCoroutine(AttackDelay(1.5f));
                    StartCoroutine(HeavySpell(hSpell));
                    break;

                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Player has to wait x seconds before they can attack again
    /// </summary>
    /// <returns></returns>
    IEnumerator AttackDelay(float seconds)
    {
        canAttack = false;

        yield return new WaitForSeconds(seconds);

        canAttack = true;
    }

    IEnumerator HeavySpell(GameObject spell)
    {
        yield return new WaitForSeconds(1);

        Destroy(spell);
    }

    /// <summary>
    /// Enables the input actions
    /// </summary>
    private void OnEnable()
    {
        inputMap.Enable();
    }

    /// <summary>
    /// Disables the input system
    /// </summary>
    private void OnDisable()
    {
        inputMap.Disable();
    }
}
