using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    public int speed = 270;
    public float lifetime = 1;

    void Start()
    {
        transform.RotateAround(transform.parent.position, Vector3.up, -speed * lifetime / 2);    
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.parent.position, Vector3.up, speed * Time.deltaTime);
        lifetime -= Time.deltaTime;
        if (lifetime <= 0) Destroy(gameObject);
    }
}
