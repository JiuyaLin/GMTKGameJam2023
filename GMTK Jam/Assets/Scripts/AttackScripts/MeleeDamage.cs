using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    public int damage = 1;

    // Update is called once per frame
    void onCollisionEnter(Collision collision) {
        
        foreach (Item item in ItemList.itemList) 
            item.onMeleeHit(collision.gameObject);

        collision.gameObject.GetComponent<Stats>().hp -= damage;
    }
}
