using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDamage : MonoBehaviour
{
    public int damage = 1;

    // Update is called once per frame
    void onCollisionEnter(Collision collision) {
        collision.gameObject.GetComponent<Stats>().hp -= damage;
        foreach (Item item in ItemList.itemList) 
            item.onRangeHit(collision.gameObject);
    }
}
