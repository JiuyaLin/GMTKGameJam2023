using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDamage : MonoBehaviour
{
    public int damage = 1;
    public bool isPlayer = false;

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision) {
        
        foreach (Item item in ItemList.itemList) {
            item.OnRangeHit(collision.gameObject);
        }
        
        if (isPlayer){
            if (collision.tag != "Enemy") return;
            int totalDamage = PlayerStats.rangeDamage + damage;
            totalDamage = totalDamage > 0 ? totalDamage : 0;
            collision.gameObject.GetComponent<Stats>().hp -= totalDamage;
        } else {
            if (collision.tag != "Player") return;
            PlayerStats.hp -= damage;
        }
    }
}
