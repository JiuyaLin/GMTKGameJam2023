using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonDescription : MonoBehaviour
{
    public GameObject descriptionBox; 
    public TMP_Text text;

    RectTransform tf;
    void Start() {
        tf = descriptionBox.GetComponent<RectTransform>();
    }
    public void openDisplay(int itemIndex) {
        
        descriptionBox.SetActive(true);
        Vector2 mousePosition = Input.mousePosition;
        mousePosition.y -= tf.rect.height / 2;
        
        tf.anchoredPosition = mousePosition;
        text.text = ItemList.itemList[itemIndex].GetDescription();
        // Debug.Log("This is good");
        Debug.Log(ItemList.itemList[itemIndex].GetName());
    }

    public void closeDisplay() {
        descriptionBox.SetActive(false);
    }
}
