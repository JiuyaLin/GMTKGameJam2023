using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasherSword : Item
{
    public string itemName = "Basher Sword";
    [TextArea(15,20)]
    public string description = "Your melee attacks do much more damage! Your ranged attacks, however, do less. (+5 Melee, -5 Range)";
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
        PlayerStats.rangeDamage -= 5;
        PlayerStats.meleeDamage += 5;
    }

    public override void OnDrop() {
        base.OnDrop();
        PlayerStats.rangeDamage += 5;
        PlayerStats.meleeDamage -= 5;
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
