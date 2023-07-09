using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEye : Item
{
    public string itemName = "Sniper Eye";
    [TextArea(15,20)]
    public string description = "Your range attacks do much more damage! Your melee attacks, however, do less. (+5 Range, -5 Melee)";
    public Sprite sprite = null;
    public override void OnMeleeHit(GameObject enemy) {
         
    }

    public override void OnRangeHit(GameObject enemy) {

    }

    public override void OnMeleeUse(GameObject attack) {
        
    }

    public override void OnRangeUse(GameObject attack) {

    }

    public override void OnGain() {
        base.OnGain();
        PlayerStats.rangeDamage += 5;
        PlayerStats.meleeDamage -= 5;
    }

    public override void OnDrop() {
        base.OnDrop();
        PlayerStats.rangeDamage -= 5;
        PlayerStats.meleeDamage += 5;
    }

    public override void OnHurt() {

    }

    public override string GetName() {
        return itemName;
    }
    public override Sprite GetSprite() {
        return sprite;
    }
    public override string GetDescription() {
        return description;
    }
}
