using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptUI : MonoBehaviour
{
    public Stats enemyStats;
    private float prevHP;
    public float amount;
    public float prevAmount;

    public int curColor;
    public Color[] healthColors;

    private GameObject healthBar;

    void Update()
    {
        curColor = (int)(4*((float)enemyStats.hp/(float)enemyStats.maxHp));
        if (curColor > 4) curColor = 4;
        if (curColor < 0) curColor = 0;

        transform.GetChild(0).GetComponent<SpriteRenderer>().color = healthColors[curColor];
        if(prevHP != enemyStats.hp)
        {
            prevHP = enemyStats.hp;
            updateUI();
        }
    }

    public void Awake() {
        healthBar = transform.GetChild(0).gameObject;
    }

    private void updateUI() {
        
        prevAmount = amount;
        amount = ((float)enemyStats.hp/(float)enemyStats.maxHp);

        // if (amount < 1) {
        healthBar.SetActive(true);
        LeanTween.value(gameObject, prevAmount, amount, 0.7f).setOnUpdate((float val)=> {
            this.transform.localScale = new Vector3 (val, transform.localScale.y, transform.localScale.z);
        }).setEase(LeanTweenType.easeInOutQuint);
        // } else {
        //     healthBar.SetActive(false);
        // }

        

    }
}
