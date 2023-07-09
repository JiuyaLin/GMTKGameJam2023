using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMsg : MonoBehaviour
{
    public GameObject Message;
    public GameObject DialogBoxBackground;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("what");
        if(other.gameObject.tag == "Player")
        {
            Message.SetActive(true);
            DialogBoxBackground.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Message.SetActive(false);
            DialogBoxBackground.SetActive(false);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
