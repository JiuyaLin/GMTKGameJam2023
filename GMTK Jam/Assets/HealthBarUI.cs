using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image healthFill;
    private float prevHP;

    void Update()
    {
        if(prevHP != PlayerStats.hp)
        {
            prevHP = PlayerStats.hp;
            updateUI();
        }
    }

    private void updateUI() {
        float amount = (PlayerStats.hp/PlayerStats.maxHp);
        healthFill.fillAmount = amount;
    }
}
