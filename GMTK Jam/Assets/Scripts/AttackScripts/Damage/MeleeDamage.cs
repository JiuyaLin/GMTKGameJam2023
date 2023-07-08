using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    public int damage = 1;
    public bool isPlayer = false;

    // Update is called once per frame
    private void onTriggerEnter(Collider collision) {
        
        foreach (Item item in ItemList.itemList) {
            item.onMeleeHit(collision.gameObject);
        }
        
        if (isPlayer){
            if (collision.tag != "Enemy") return;
            int totalDamage = PlayerStats.meleeDamage + damage;
            collision.gameObject.GetComponent<Stats>().hp -= totalDamage;
        } else {
            if (collision.tag != "Player") return;
            PlayerStats.hp -= damage;
        }
    }
}
