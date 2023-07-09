using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOfHeroes : Item
{

    public string itemName = "Shield of Heroes";
    [TextArea(15,20)]
    public string description = "Heal all by using your heroic Melee Hits (even your enemies)! Ranged attacks inflict damage to you but have higher damage. (+5 Healing on Melee, +5 Range but -5 Healing)";
    public Sprite sprite = null;
    // Start is called before the first frame update
    public override void OnMeleeHit(GameObject enemy) {
        PlayerStats.hp += 5;
        Stats enemyStats = enemy.GetComponent<Stats>();
        if (enemyStats != null) {
            enemyStats.hp += 5;
            if (enemyStats.hp > enemyStats.maxHp) enemyStats.hp = enemyStats.maxHp;
        }
    }

    public override void OnRangeHit(GameObject enemy) {
        
    }

    public override void OnMeleeUse(GameObject attack) {
        
    }

    public override void OnRangeUse(GameObject attack) {
        PlayerStats.hp -= 5;
    }

    public override void OnGain() {
        base.OnGain();
        PlayerStats.rangeDamage += 5;
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
