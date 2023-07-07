using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject edgeChk;

    public float speed = 6f; 
    public bool onEdge;
    
    void Start() {
        controller = gameObject.GetComponent<CharacterController>();
        edgeChk = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // whenever input changes, do this 
        // get key down/up ?
       
            

        // move player
        if (!onEdge && direction.magnitude >= 0.1f) {
            controller.Move(direction * speed * Time.deltaTime);
            // rotate edgechk
            float angle = -1 * Mathf.Rad2Deg * Mathf.Atan2(vertical, horizontal);
            Debug.Log(angle);
            edgeChk.transform.eulerAngles = new Vector3(0f, angle, 0f);
        }

    }

    // stop player movement in that direction when stop collide 
    
    // new script on edgecheck
    // on collision exit 2d, set on edge to true 
    // on collision enter, set to false 

    float getCheckAngle() {
        return edgeChk.transform.rotation.y;
    }

}
