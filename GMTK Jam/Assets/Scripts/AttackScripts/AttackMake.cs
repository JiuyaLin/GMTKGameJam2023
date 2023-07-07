using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMake : MonoBehaviour
{   
    public float angle = 0;
    public float delay = 1f;
    public GameObject attackPrefab; 

    private Transform tf;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.transform;
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {   
        // Set the correct attack angle
        tf.eulerAngles = new Vector3(0, angle, 0);

        // Create the attack instance
        
        if (Time.time - time < delay || attackPrefab == null || !Input.GetButtonDown("Fire1")) return;
        time = Time.time;
        
        GameObject attack = Instantiate(attackPrefab, tf);
        
        
    }
}
