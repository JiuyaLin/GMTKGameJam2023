using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement2 : GroundedPaperSprite
{
    protected float rollTime = 0.5f;
    protected float rollSpeed = 6f;
    protected float rollCooldown = 1.0f;
    public float movementSpeed = 1.5f;
    public float rollTimeTracker = 0f;
    public float rollColldownTracker = 0f;
    public Vector3 rollDirection;
    public string animationName;
    

    public override void Start()
    {
        base.Start();
        automaticallyUpdateFacingDirection = false;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (rollColldownTracker > 0)
        {
            facingDirection = rollDirection.normalized;
        }
        else
        {
            facingDirection = Quaternion.Euler(0, trackedCamera.transform.eulerAngles.y, 0) * new Vector3(Input.mousePosition.x - trackedCamera.WorldToScreenPoint(transform.position).x, 0,
                    Input.mousePosition.y - trackedCamera.WorldToScreenPoint(transform.position).y);
        }
        requestedMovement = Quaternion.Euler(0, trackedCamera.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * movementSpeed * Time.deltaTime;
        if (Input.GetButtonDown("Roll") && rollColldownTracker <= 0)
        {
            rollTimeTracker = rollTime;
            rollColldownTracker = rollCooldown;
            rollDirection = requestedMovement.sqrMagnitude != 0 ? requestedMovement.normalized : facingDirection.normalized;
        }
        if (rollTimeTracker > 0)
        {
            rollTimeTracker -= Time.deltaTime;
            requestedMovement = rollDirection * rollSpeed * Time.deltaTime;
        }
        if (rollColldownTracker > 0)
        {
            rollColldownTracker -= Time.deltaTime;
        }

        base.Update();
        if (rollTimeTracker > 0 && animationName != "Roll")
        {
            animationName = "Roll";
            animator.Play(animationName);
        }
        else if (requestedMovement.sqrMagnitude != 0 && animationName != "Walk")
        {
            animationName = "Walk";
            animator.Play(animationName);
        }
        else if (requestedMovement.sqrMagnitude == 0 && animationName != "Idle")
        {
            animationName = "Idle";
            animator.Play(animationName);
        }
        if (rollTimeTracker <= 0 && rollColldownTracker > 0)
        {
            animator.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f);
        }
        else
        {
            animator.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
