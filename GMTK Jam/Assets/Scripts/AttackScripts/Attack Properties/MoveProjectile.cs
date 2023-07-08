using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float speed = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
