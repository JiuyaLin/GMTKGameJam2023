using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingedShoes : Item
{
    public string itemName = "Winged Shoes";
    [TextArea(15,20)]
    public string description = "";
    public Sprite sprite = null;
    // Start is called before the first frame update
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
        HasItems.droppedWingedShoes = false;
    }

    public override void OnDrop() {
        base.OnDrop();
        HasItems.droppedWingedShoes = true;
    }

    public override void OnHurt() {
        PlayerStats.hp -= 1;
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
