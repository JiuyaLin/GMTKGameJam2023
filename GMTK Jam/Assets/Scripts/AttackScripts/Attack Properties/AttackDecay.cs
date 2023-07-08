using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDecay : MonoBehaviour
{
    public float duration = 1f;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - time < duration) return;
        Destroy(gameObject);
    }
}
