using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffOfVillainy : Item
{
    public string itemName = "Staff of Villainy";
    [TextArea(15,20)]
    public string description;
    public Sprite sprite = null;
    public override void OnMeleeHit(GameObject enemy) {
        
    }

    public override void OnRangeHit(GameObject enemy) {
        PlayerStats.hp += 5;
        Stats enemyStats = enemy.GetComponent<Stats>();
        // if (enemyStats != null) {
        //     enemyStats.hp += 5;
        //     if (enemyStats.hp > enemyStats.maxHp) enemyStats.hp = enemyStats.maxHp;
        // }
    }

    public override void OnMeleeUse(GameObject attack) {
        PlayerStats.hp -= 3;
    }

    public override void OnRangeUse(GameObject attack) {
        
    }

    public override void OnGain() {
        base.OnGain();
        PlayerStats.meleeDamage += 5;
        PlayerStats.rangeDamage -= 5;
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
