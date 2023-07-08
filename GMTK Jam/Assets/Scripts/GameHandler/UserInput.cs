using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    
    public GameObject player;
    // Update is called once per frame
    private AttackMake playerAttackMake;

    void Start() {
        playerAttackMake = player.GetComponentInChildren<AttackMake>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Melee")) {
            playerAttackMake.MeleeAttack();
        }
        if (Input.GetButtonDown("Ranged")) {
            playerAttackMake.RangedAttack();
        }
    }
}
