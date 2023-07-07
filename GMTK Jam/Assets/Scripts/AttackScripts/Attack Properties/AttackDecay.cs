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
        Debug.Log(duration);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Time.time - time);
        // Debug.Log(Time.time - time < duration);
        if (Time.time - time < duration) return;
        Debug.Log("Destroyed");
        Destroy(gameObject);
    }
}
