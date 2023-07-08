using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEye : Item
{
   public void onMeleeHit(GameObject enemy) {

   }

    public void onRangeHit(GameObject enemy) {

    }

    public void onMeleeUse(GameObject player, GameObject attack) {
        attack.GetComponent<MeleeDamage>().dmg /= 2;
    }

    public void onRangeUse(GameObject player, GameObject attack) {
        attack.GetComponent<RangeDamage>().dmg *= 2;
    }

    public void onGain(GameObject player) {

    }

    public void onDrop(GameObject player) {

    }
}
