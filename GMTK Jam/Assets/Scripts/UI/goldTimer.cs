using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class goldTimer : MonoBehaviour
{
    public GameObject timer;
    private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = this.GetComponentInChildren<TextMeshProUGUI>();
        timer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (HasItems.droppedGold) {
            timer.SetActive(true);
            int timeLeft = (int)(HasItems.duration + HasItems.timer - Time.time + .5);
            textMesh.SetText(timeLeft + " seconds left!");
        }
    }
}
