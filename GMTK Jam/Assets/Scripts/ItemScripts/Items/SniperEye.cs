using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEye : Item
{
    public override void OnMeleeHit(GameObject enemy) {
         
    }

    public override void OnRangeHit(GameObject enemy) {

    }

    public override void OnMeleeUse(ThirdPersonMovement2 player, GameObject attack) {
        
    }

    public override void OnRangeUse(ThirdPersonMovement2 player, GameObject attack) {

    }

    public override void OnGain(ThirdPersonMovement2 player) {
        PlayerStats.rangeDamage += 5;
        PlayerStats.meleeDamage -= 5;
    }

    public override void OnDrop(ThirdPersonMovement2 player) {
        PlayerStats.rangeDamage -= 5;
        PlayerStats.meleeDamage += 5;
    }

    public override void OnHurt(ThirdPersonMovement2 player) {

    }
}
