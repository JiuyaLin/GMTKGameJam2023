using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag != "Player") return;
        ItemList.AddItem(new SniperEye());
        Destroy(gameObject);
    }
}
