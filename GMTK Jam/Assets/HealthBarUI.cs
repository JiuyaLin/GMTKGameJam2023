using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image healthFill;
    private float prevHP;
    public float amount;
    public float prevAmount;

    void Update()
    {
        if(prevHP != PlayerStats.hp)
        {
            prevHP = PlayerStats.hp;
            updateUI();
        }
    }

    private void updateUI() {
        prevAmount = amount;
        amount = ((float)PlayerStats.hp/(float)PlayerStats.maxHp);

        LeanTween.value(gameObject, prevAmount, amount, 0.3f).setOnUpdate((float val)=> {
            healthFill.fillAmount = val;
        }).setEase(LeanTweenType.easeInOutQuint);

    }
}
