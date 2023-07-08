using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestUI : MonoBehaviour
{
    GameObject selectUI; 
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        selectUI = transform.GetChild(1).gameObject;
        //closeChest();
        //edit selectUI from there (what is highlighted) 
    }

    // index in list, use static RemoveItem

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openChest() 
    {
        // display the right number items
        
        selectUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void closeChest() 
    {
        // update item placement 
        
        selectUI.SetActive(false);
        Time.timeScale = 1f;
    }



    public void selectItem(int i)
    {
        Debug.Log(i + "!");
        ItemList.removeItem(player, i);
        closeChest();
    }

}
