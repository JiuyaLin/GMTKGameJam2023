using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockpick : Item
{
    public string itemName = "Lockpick";
    [TextArea(15,20)]
    public string description = "";
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
        HasItems.droppedLockpick = false;
    }

    public override void OnDrop() {
        base.OnDrop();
        HasItems.droppedLockpick = true;
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
