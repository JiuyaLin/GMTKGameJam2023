using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffOfVillainy : MonoBehaviour
{
    public string itemName = "Staff of Villainy";
    public Sprite sprite = null;
    public override void OnMeleeHit(GameObject enemy) {
        PlayerStats.hp -= 1;
    }

    public override void OnRangeHit(GameObject enemy) {
        PlayerStats.hp += 1;
        enemy.GetComponent<Stats>.hp += 1;
    }

    public override void OnMeleeUse(ThirdPersonMovement2 player, GameObject attack) {
        
    }

    public override void OnRangeUse(ThirdPersonMovement2 player, GameObject attack) {
        
    }

    public override void OnGain(ThirdPersonMovement2 player) {
        base.OnGain();
    }

    public override void OnDrop(ThirdPersonMovement2 player) {
        base.OnDrop();
    }

    public override void OnHurt(ThirdPersonMovement2 player) {
        
    }

    public override string GetName() {
        return itemName;
    }
    public override Sprite GetSprite() {
        return sprite;
    }
}
