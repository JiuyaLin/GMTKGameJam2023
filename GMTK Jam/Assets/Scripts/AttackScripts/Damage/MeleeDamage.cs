using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    public int damage = 0;
    public bool isPlayer = false;

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision) {
        int totalDamage = damage;
        
        if (isPlayer){
            if (collision.tag != "Enemy") return;

            GameObject enemy = collision.gameObject;
            int playerHeal = 0;
            foreach (Item item in ItemList.itemList) {
                item.OnMeleeHit(enemy);
                
                if (item.GetName().Contains("Shield")) {
                    playerHeal += 5;
                }
            }
            totalDamage += PlayerStats.meleeDamage;
            // Debug.Log("Player Heal: " + playerHeal.ToString());
            if (playerHeal > 0) {
                if (PlayerStats.hp > PlayerStats.maxHp) {
                    playerHeal -= PlayerStats.hp - PlayerStats.maxHp;
                    PlayerStats.hp = PlayerStats.maxHp;
                }
                DamagePopup.Create(transform.position + Vector3.up, -playerHeal, 1f, false);
            }
            
            Stats enemyStats = enemy.GetComponent<Stats>();
            enemyStats.hp -= totalDamage;
            if (enemyStats.hp > enemyStats.maxHp) {
                if (totalDamage > 0) totalDamage -= enemyStats.hp - enemyStats.maxHp;
                enemyStats.hp = enemyStats.maxHp;
            }
        } else {
            if (collision.tag != "Player") return;
            PlayerStats.hp -= totalDamage;
        }

        DamagePopup.Create(collision.transform.position + Vector3.up, totalDamage, 1f, isPlayer);
    }
}
