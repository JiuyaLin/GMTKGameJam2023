using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement2 : GroundedPaperSprite
{
    public float movementSpeed = 4f;
    public string animationName;

    // Update is called once per frame
    public override void Update()
    {
        requestedMovement = Quaternion.Euler(0, trackedCamera.transform.rotation.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * movementSpeed * Time.deltaTime;
        base.Update();
        if (requestedMovement.sqrMagnitude != 0 && animationName != "Walk")
        {
            animationName = "Walk";
            animator.Play(animationName);
        }
        else if (requestedMovement.sqrMagnitude == 0 && animationName != "Idle")
        {
            animationName = "Idle";
            animator.Play(animationName);
        }
    }
}
