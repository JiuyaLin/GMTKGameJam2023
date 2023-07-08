using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOfHeroes : Item
{

    public string itemName = "Shield of Heroes";
    public Sprite sprite = null;
    // Start is called before the first frame update
    public override void OnMeleeHit(GameObject enemy) {
        PlayerStats.hp += 1;
        enemy.GetComponent<Stats>().hp += 1;
    }

    public override void OnRangeHit(GameObject enemy) {

    }

    public override void OnMeleeUse(GameObject attack) {
        
    }

    public override void OnRangeUse(GameObject attack) {
        PlayerStats.hp -= 1;
    }

    public override void OnGain() {
        base.OnGain();
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
}
