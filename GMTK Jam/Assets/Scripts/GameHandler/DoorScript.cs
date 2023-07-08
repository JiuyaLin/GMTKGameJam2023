using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    public RoomState roomState;

    private bool isOpen = false;
    void Start()
    {
        openDoor();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen == roomState.isInCombat) return;
        if (isOpen) closeDoor();
        else openDoor();
    }

    void openDoor() {
        door.SetActive(false);
        isOpen = true;
    }
    
    void closeDoor() {
        door.SetActive(true);
        isOpen = false;
    }
}
