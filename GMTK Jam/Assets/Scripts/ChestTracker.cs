using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTracker : MonoBehaviour
{
    int numChestsFilled;

    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChestFilled() {
        numChestsFilled++;
        Debug.Log("woo!");
    }
}