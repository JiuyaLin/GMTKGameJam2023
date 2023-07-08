using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement2 : GroundedPaperSprite
{
    public float rollTime = 0.5f;
    public float rollSpeed = 6f;
    public float rollCooldown = 1.0f;
    public float interactableRange = 1.5f;
    public float movementSpeed = 3f;

    private float rollTimeTracker = 0f;
    private float rollColldownTracker = 0f;
    private Vector3 rollDirection;

    public override void Start()
    {
        base.Start();
        automaticallyUpdateFacingDirection = false;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (rollColldownTracker > 0) {
            facingDirection = rollDirection.normalized;
        } else {
            facingDirection = Quaternion.Euler(0, trackedCamera.transform.eulerAngles.y, 0) * new Vector3(Input.mousePosition.x - trackedCamera.WorldToScreenPoint(transform.position).x, 0,
                    Input.mousePosition.y - trackedCamera.WorldToScreenPoint(transform.position).y).normalized;
        }

        requestedMovement = Quaternion.Euler(0, trackedCamera.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * movementSpeed * Time.deltaTime;
        if (Input.GetButtonDown("Roll") && rollColldownTracker <= 0) {
            rollTimeTracker = rollTime;
            rollColldownTracker = rollCooldown;
            rollDirection = requestedMovement.sqrMagnitude != 0 ? requestedMovement.normalized : facingDirection.normalized;
        }
        
        if (rollTimeTracker > 0) {
            rollTimeTracker -= Time.deltaTime;
            requestedMovement = rollDirection * rollSpeed * Time.deltaTime;
        }

        if (rollColldownTracker > 0) {
            rollColldownTracker -= Time.deltaTime;
        }

        base.Update();
        if (rollTimeTracker > 0) {
            ActivateAnimation("Roll");
        } else if (requestedMovement.sqrMagnitude != 0) {
            ActivateAnimation("Walk");
        } else if (requestedMovement.sqrMagnitude == 0) {
            ActivateAnimation("Idle");
        }

        if (rollTimeTracker <= 0 && rollColldownTracker > 0) {
            animator.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f);
        } else {
            animator.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (Input.GetButtonDown("Interact")) {
            List<Object> objects = new List<Object>(FindObjectsByType(typeof(Interactable), FindObjectsInactive.Exclude, FindObjectsSortMode.None));
            objects.Sort(Comparer<Object>.Create((o1, o2) => ((o1 as Interactable).transform.position - transform.position).sqrMagnitude
                .CompareTo(((o2 as Interactable).transform.position - transform.position).sqrMagnitude)));
            if (objects.Count != 0 && ((objects[0] as Interactable).transform.position - transform.position).sqrMagnitude < (interactableRange * interactableRange))
            {
                (objects[0] as Interactable).OnInteract();
            }
        }

        if (Input.GetButtonDown("Melee") && rollTimeTracker <= 0) {
            GetComponent<AttackMake>().MeleeAttack();
        }

        if (Input.GetButtonDown("Ranged") && rollTimeTracker <= 0) {
            GetComponent<AttackMake>().RangedAttack();
        }
    }
}
