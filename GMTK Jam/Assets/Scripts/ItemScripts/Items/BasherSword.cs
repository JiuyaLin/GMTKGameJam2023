using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasherSword : Item
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
        base.OnGain(player);
        PlayerStats.rangeDamage -= 5;
        PlayerStats.meleeDamage += 5;
    }

    public override void OnDrop(ThirdPersonMovement2 player) {
        base.OnDrop(player);
        PlayerStats.rangeDamage += 5;
        PlayerStats.meleeDamage -= 5;
    }

    public override void OnHurt(ThirdPersonMovement2 player) {

    }

    public override string getName() {
        return "BasherSword";
    }
}
