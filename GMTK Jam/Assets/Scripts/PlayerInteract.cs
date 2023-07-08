using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    
    bool nearChest;
    bool chestOpen;
    ChestUI chest;
    
    // Start is called before the first frame update
    void Start()
    {
        chest = GameObject.FindGameObjectWithTag("ChestUI").GetComponent<ChestUI>();
        chestOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        // left click near chest to pull up UI 
        // right click to close, left click to select 
        if (nearChest && Input.GetMouseButtonDown(0)) 
        {
            chest.openChest();
            chestOpen = true;
        }
        if (nearChest && Input.GetMouseButtonDown(1)) 
        {
            chest.closeChest();
            chestOpen = false;
        }
       
    }

    // will need to change if we raycast 
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Chest") {
            // player is now near chest 
            nearChest = true;
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Chest") {
            nearChest = false;
        }
    }
}
