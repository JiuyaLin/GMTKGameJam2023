using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDamage : MonoBehaviour
{
    public int damage = 1;
    public float lifetime = 1;
    public float speed = 10;
    public bool isPlayer = false;
    public bool canBounce = false;

    void Start()
    {
        transform.parent = null;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0) Destroy(gameObject);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision) {
        if (collision.tag == "Ground") {
            Destroy(gameObject);
        }

        int totalDamage = damage;
        if (isPlayer) {
            if (collision.tag != "Enemy") return;
            foreach (Item item in ItemList.itemList) {
                item.OnRangeHit(collision.gameObject);
            }
            totalDamage += PlayerStats.rangeDamage;
            totalDamage = totalDamage > 0 ? totalDamage : 0;
            collision.gameObject.GetComponent<Stats>().hp -= totalDamage;
        } else {
            if (collision.tag != "Player") return;
            PlayerStats.hp -= totalDamage;
        }

        if (totalDamage > 0) {
            DamagePopup.Create(collision.transform.position + Vector3.up, totalDamage, 1f, isPlayer);
        }

        if (canBounce) {
            lifetime *= 2;
            GetComponent<Rigidbody>().velocity *= 1.5f;
        } else {
            Destroy(gameObject);
        }
    }
}
