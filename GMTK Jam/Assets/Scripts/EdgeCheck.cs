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
        
        if (col.gameObject.tag == "Ground") {
            Debug.Log("on ground");
            movescript.onEdge = false;
            
        }
    }

    void OnTriggerExit(Collider col) {
        
        if (col.gameObject.tag == "Ground") {
            Debug.Log("on edge");
            movescript.onEdge = true;
        }
    }
}
