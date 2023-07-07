using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCheck : MonoBehaviour
{
    ThirdPersonMovement movescript;
    
    void Start() {
        movescript = transform.GetComponentInParent<ThirdPersonMovement>();
    }
    
    void OnTriggerEnter(Collider col) {
        Debug.Log("on ground");
        movescript.onEdge = false;
        if (col.gameObject.tag == "Ground") {
            
            
        }
    }

    void OnTriggerExit(Collider col) {
        Debug.Log("on edge");
        movescript.onEdge = true;
        if (col.gameObject.tag == "Ground") {
            
            
        }
    }
}
