using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject edgeChk;

    public float speed = 6f; 
    public bool onEdge;
    
    float oldhoriz;
    float oldvert;
    
    void Start() {
        controller = gameObject.GetComponent<CharacterController>();
        edgeChk = transform.GetChild(1).gameObject;

        oldhoriz = 3;
        oldvert = 3;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // move player
        if (!onEdge && direction.magnitude >= 0.1f) {
            controller.Move(direction * speed * Time.deltaTime);
        }


        // whenever input changes, do this 
        // rotate edgechk
        if (oldhoriz != horizontal || oldvert != vertical) {
            float angle = -1 * Mathf.Rad2Deg * Mathf.Atan2(vertical, horizontal);
            // Debug.Log(angle);
            edgeChk.transform.eulerAngles = new Vector3(0f, angle, 0f);
        }
        
        oldhoriz = horizontal;
        oldvert = vertical;

        

    }

    // stop player movement in that direction when stop collide 
    
    // new script on edgecheck
    // on collision exit 2d, set on edge to true 
    // on collision enter, set to false 

    public float getCheckAngle() {
        return edgeChk.transform.eulerAngles.y;
    }

}
