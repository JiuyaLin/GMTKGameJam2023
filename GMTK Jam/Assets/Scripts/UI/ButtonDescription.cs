using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonDescription : MonoBehaviour
{
    public GameObject descriptionBox; 
    public TMP_Text text;

    Vector2 screen;
    RectTransform tf;
    void Start() {
        tf = descriptionBox.GetComponent<RectTransform>();
        screen = new Vector2(Screen.width, Screen.height);
    }
    public void openDisplay(int itemIndex) {
        
        descriptionBox.SetActive(true);
        Vector2 mousePosition = Input.mousePosition;
        mousePosition.y -= tf.rect.height / 2;
        mousePosition = Vector2.Scale(mousePosition.normalized, screen);
        tf.anchoredPosition = mousePosition;
        text.text = ItemList.itemList[itemIndex].GetDescription();
        // Debug.Log("This is good");
        Debug.Log(ItemList.itemList[itemIndex].GetName());
    }

    public void closeDisplay() {
        descriptionBox.SetActive(false);
    }
}
