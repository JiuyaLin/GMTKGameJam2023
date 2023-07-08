using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDamage : MonoBehaviour
{
    public int damage = 1;
    public bool isPlayer = false;

    // Update is called once per frame
    void onCollisionEnter(Collision collision) {
        
        foreach (Item item in ItemList.itemList) {
            item.onRangeHit(collision.gameObject);
        }

        if (isPlayer){
            int totalDamage = PlayerStats.rangeDamage + damage;
            collision.gameObject.GetComponent<Stats>().hp -= totalDamage;
        } else {
            PlayerStats.hp -= damage;
        }
    }
}
