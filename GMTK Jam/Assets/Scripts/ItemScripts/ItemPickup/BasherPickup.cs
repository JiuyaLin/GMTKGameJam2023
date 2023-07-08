using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasherPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag != "Player") return;
        ItemList.addItem(other.gameObject, new BasherSword());
        Destroy(gameObject);
    }
}
