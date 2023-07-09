using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOfHeroes : Item
{
    public string itemName = "Shield of Heroes";
    public Sprite sprite = null;

    [TextArea(15,20)]
    public string description;
    
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
        PlayerStats.hp -= 3;
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
