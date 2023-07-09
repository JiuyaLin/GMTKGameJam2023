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
    Vector2 offset;
    Canvas canvas;
    void Start() {
        tf = descriptionBox.GetComponent<RectTransform>();
        screen = new Vector2(Screen.width, Screen.height);
        canvas = transform.parent.parent.GetComponent<Canvas>();
        offset = new Vector2(0, -1.5f * tf.rect.height);

    }
    public void openDisplay(int itemIndex) {
        if (itemIndex >= ItemList.itemList.Count) return;
        descriptionBox.SetActive(true);
        // Vector2 mousePosition = Input.mousePosition;
        // Vector2 pos;
        // RectTransformUtility.ScreenPointToLocalPointInRectangle(
        //     canvas.transform as RectTransform,
        //     mousePosition,
        //     canvas.worldCamera,
        //     out pos
        // );
        // pos += offset;
        
        // mousePosition = mousePosition / canvas.scaleFactor;
        
        // Debug.Log(Input.mousePosition + " " + mousePosition);
        
        //tf.anchoredPosition = pos;
        text.text = ItemList.itemList[itemIndex].GetDescription();
        // Debug.Log("This is good");
        Debug.Log(ItemList.itemList[itemIndex].GetName());
    }

    public void closeDisplay() {
        descriptionBox.SetActive(false);
    }
}
