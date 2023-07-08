using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasherPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag != "Player") return;
        ItemList.AddItem(other.GetComponent<ThirdPersonMovement2>(), new BasherSword());
        Destroy(gameObject);
    }
}
