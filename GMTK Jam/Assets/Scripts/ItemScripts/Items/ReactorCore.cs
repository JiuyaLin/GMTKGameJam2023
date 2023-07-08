using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorCore : Item
{
    public string itemName = "Reactor Core";
    public Sprite sprite = null;
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
        HasItems.droppedReactorCore = false;

    }

    public override void OnDrop()
    {
        base.OnDrop();
        HasItems.droppedReactorCore = true;
        
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
