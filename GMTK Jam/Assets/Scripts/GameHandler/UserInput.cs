using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    
    public GameObject player;
    // Update is called once per frame
    private AttackMake playerAttackMake;

    void Start() {
        playerAttackMake = player.GetComponentInChildren<AttackMake>()[0];
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            playerAttackMake.meleeAttack();
        }
        if (Input.GetButtonDown("Fire2")) {
            playerAttackMake.rangedAttack();
        }
    }
}
