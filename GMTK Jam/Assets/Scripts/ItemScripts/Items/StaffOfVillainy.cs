using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffOfVillainy : Item
{
    public string itemName = "Staff of Villainy";
    [TextArea(15,20)]
    public string description = "Does it make you a villain? Use ranged attacks to absorb energy from your enemies! Melee attacks inflict damage to you but have higher damage. (+5 Healing on Range, +5 Melee but -5 Healing)";
    public Sprite sprite = null;
    public override void OnMeleeHit(GameObject enemy) {
        PlayerStats.hp -= 5;
    }

    public override void OnRangeHit(GameObject enemy) {
        PlayerStats.hp += 5;
        Stats enemyStats = enemy.GetComponent<Stats>();
        if (enemyStats != null) {
            enemyStats.hp += 5;
            if (enemyStats.hp > enemyStats.maxHp) enemyStats.hp = enemyStats.maxHp;
        }
    }

    public override void OnMeleeUse(GameObject attack) {
        
    }

    public override void OnRangeUse(GameObject attack) {
        
    }

    public override void OnGain() {
        base.OnGain();
        PlayerStats.meleeDamage += 5;
    }

    public override void OnDrop() {
        base.OnDrop();
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
