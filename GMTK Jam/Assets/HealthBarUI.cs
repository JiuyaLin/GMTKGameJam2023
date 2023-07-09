using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image healthFill;
    private float prevHP;
    public float amount;

    void Update()
    {
        if(prevHP != PlayerStats.hp)
        {
            prevHP = PlayerStats.hp;
            updateUI();
        }
    }

    private void updateUI() {
        amount = ((float)PlayerStats.hp/(float)PlayerStats.maxHp);
        healthFill.fillAmount = amount;

    }
}
