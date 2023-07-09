using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    public int damage = 1;
    public bool isPlayer = false;

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision) {
        int totalDamage = damage;
        foreach (Item item in ItemList.itemList) {
            item.OnMeleeHit(collision.gameObject);
        }
        
        if (isPlayer){
            if (collision.tag != "Enemy") return;
            totalDamage += PlayerStats.meleeDamage;
            totalDamage = totalDamage > 0 ? totalDamage : 0;
            collision.gameObject.GetComponent<Stats>().hp -= totalDamage;
        } else {
            if (collision.tag != "Player") return;
            PlayerStats.hp -= totalDamage;
        }

        if (totalDamage > 0) {
            DamagePopup.Create(collision.transform.position + Vector3.up, damage, .5, isPlayer);
        }
    }
}
