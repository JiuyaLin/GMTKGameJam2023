using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 1;
    public float speed = 10;
    public int bounces = 0;
    // Start is called before the first frame update
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

    private void OnCollisionEnter(Collision collision)
    {
        lifetime *= 2;
        GetComponent<Rigidbody>().velocity *= 1.5f;
        bounces++;
    }
}
