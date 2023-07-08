using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestUI : MonoBehaviour
{
    GameObject selectUI; 
    GameObject player;

    GameObject itemselect1;
    GameObject itemselect2;
    GameObject itemselect3;
    GameObject itemselect4;
    GameObject itemselect5;

    GameObject invUI;

    GameObject item1;
    GameObject item2;
    GameObject item3;
    GameObject item4;
    GameObject item5;

    List<GameObject> itemObjList;

    GameObject gameHandler;

    public ChestObj chestref;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        selectUI = transform.GetChild(1).gameObject;

        itemselect1 = selectUI.transform.GetChild(0).gameObject;
        itemselect2 = selectUI.transform.GetChild(1).gameObject;
        itemselect3 = selectUI.transform.GetChild(2).gameObject;
        itemselect4 = selectUI.transform.GetChild(3).gameObject;
        itemselect5 = selectUI.transform.GetChild(4).gameObject;

        invUI = transform.GetChild(0).gameObject;

        item1 = invUI.transform.GetChild(0).gameObject;
        item2 = invUI.transform.GetChild(1).gameObject;
        item3 = invUI.transform.GetChild(2).gameObject;
        item4 = invUI.transform.GetChild(3).gameObject;
        item5 = invUI.transform.GetChild(4).gameObject;
        
        itemObjList = new List<GameObject> {item1, item2, item3, item4, item5};
        
        gameHandler = GameObject.FindGameObjectWithTag("GameHandler");
        Debug.Log(gameHandler);

        unhighlight();
        updateItems();
        //edit selectUI from there (what is highlighted) 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void highlightItems() 
    {   
        // highlight the right number items
        selectUI.SetActive(true);

        if (ItemList.itemList.Count >= 1)  {
            itemselect1.SetActive(true);
        } 
        if (ItemList.itemList.Count >= 2) {
            itemselect2.SetActive(true);
        }
        if (ItemList.itemList.Count >= 3) {
            itemselect3.SetActive(true);
        }
        if (ItemList.itemList.Count >= 4) {
            itemselect4.SetActive(true);
        }
        if (ItemList.itemList.Count >= 5) {
            itemselect5.SetActive(true);
        }

    }

    public void unhighlight() 
    {  
        selectUI.SetActive(false);
        
        itemselect1.SetActive(false);
        itemselect2.SetActive(false);
        itemselect3.SetActive(false);
        itemselect4.SetActive(false);
        itemselect5.SetActive(false);
    }

    // TODO: put in items 
    public void updateItems() 
    {
        // update item placement 
        for (int i = 0; i < ItemList.itemList.Count; i++) {
            string itemname = ItemList.itemList[i].getName();
            if (itemname == "") {
                itemObjList[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("");
            }
        }

        // Debug.Log(ItemList.itemList.Count);

        // for (int i = 4; i > ItemList.itemList.Count; i--) {
            
        //     itemObjList[i].SetActive(false);
        // }
        
    }

    public void setChestRef(ChestObj refc) {
        chestref = refc;
    }

    public void selectItem(int i)
    {
        Debug.Log(i + "!");
        //gameHandler = GameObject.FindGameObjectWithTag("GameHandler");

        ItemList.removeItem(player, i);
        // adds to gamehandler counter
        gameHandler.GetComponent<ChestTracker>().ChestFilled();

        Debug.Log(chestref);

        chestref.chestFilled = true;
        chestref.closeChest();
    }

    

}
