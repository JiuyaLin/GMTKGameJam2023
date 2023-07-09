using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestTracker : MonoBehaviour
{
    public int totalNumberOfChests = 4;
    public string nextScene = "Credits";
    int numChestsFilled;

    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        numChestsFilled = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    

    public void ChestFilled() {
        numChestsFilled++;
        Debug.Log("woo!");
        if (totalNumberOfChests <= numChestsFilled) {
            Debug.Log("Onward");
            SceneManager.LoadScene(nextScene);
        }
            
    }
}
