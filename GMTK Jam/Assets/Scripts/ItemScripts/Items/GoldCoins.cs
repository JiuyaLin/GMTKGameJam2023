using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoins : Item
{
    public string itemName = "Gold Coins";
    [TextArea(15,20)]
    public string description = "Players have caught wind of your restocking. You are now placed on a time limit to finish restocking the dungeon. (100 seconds to clear level or death!)";
    public Sprite sprite = null;
    

    public float waitTime = 100;
    float timer = 0;
    bool dropped = false; 

    public override void OnMeleeHit(GameObject enemy) {

    }

    public override void OnRangeHit(GameObject enemy) {

    }

    public override void OnMeleeUse(GameObject attack) {

    }

    public override void OnRangeUse(GameObject attack) {

    }

    public override void OnGain()
    {
        base.OnGain();
        dropped = false;
    }

    public override void OnDrop()
    {
        base.OnDrop();
        timer = Time.time;
        dropped = true;
        
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

    void Update() {
        if (!dropped) return;
        if (Time.time - timer > waitTime) {
            PlayerStats.hp = 0;
            dropped = false;
        }
    }
    
    
    
}
