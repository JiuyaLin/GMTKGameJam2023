using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasherSword : Item, GameObject
{
    public BasherSword() {

    }

   public void onMeleeHit(GameObject enemy) {

   }

    public void onRangeHit(GameObject enemy) {

    }

    public void onMeleeUse(GameObject player, GameObject attack) {
        
    }

    public void onRangeUse(GameObject player, GameObject attack) {

    }

    public void onGain(GameObject player) {
        PlayerStats.rangeDamage -= 5;
        PlayerStats.meleeDamage += 5;
    }

    public void onDrop(GameObject player) {
        PlayerStats.rangeDamage += 5;
        PlayerStats.meleeDamage -= 5;
    }

    public void onHurt(GameObject player) {

    }
}
