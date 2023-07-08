using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    
    public AttackMake playerAttackMake;
    // Update is called once per frame
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
