using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement2 : MonoBehaviour
{
    public string animationName;
    public float footHeight = 0.5f;
    public float feather = 1f;
    public float movementSpeed = 25f;
    public float wallCheckDistance = 0.2f;
    public float stairHeight = 0.3f;
    public LayerMask groundLayer;
    public Camera trackedCamera;
    public bool onGround = false;
    public Transform trackedGround;
    public Vector3 groundOffset;
    public Vector3 requestedMovement;
    public Vector3 movingPlatformCompensation = Vector3.zero;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trackedGround != null) {
            movingPlatformCompensation = trackedGround.transform.position + trackedGround.transform.rotation * groundOffset - transform.position;
            transform.position = trackedGround.transform.position + trackedGround.transform.rotation * groundOffset;
        }
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, footHeight + feather, groundLayer))
        {
            transform.position = hit.point + Vector3.up * footHeight;
            onGround = true;
            trackedGround = hit.collider.transform;
        }
        else
        {
            onGround = false;
            trackedGround = null;
        }
        animator.transform.rotation = trackedCamera.transform.rotation;
        requestedMovement = Quaternion.Euler(0, trackedCamera.transform.rotation.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * movementSpeed * Time.deltaTime;
        if (Input.GetAxis("Horizontal") < 0) {
            animator.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            animator.transform.localScale = new Vector3(1, 1, 1);
        }
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
        Vector3 normal = CheckMovement(requestedMovement);
        if (normal.sqrMagnitude == 0)
        {
            Vector3 redoneMovement = requestedMovement - normal * Vector3.Dot(normal, requestedMovement);
            if (CheckMovement(redoneMovement).sqrMagnitude == 0)
            {
                transform.position += redoneMovement * 0.5f; // this is dumb but it works so * shrug *
            }
        }
    }

    Vector3 CheckMovement(Vector3 movement)
    {
        if (Physics.CapsuleCast(transform.position + Vector3.up * footHeight / 2, transform.position - Vector3.up * (footHeight / 2 - stairHeight),
            wallCheckDistance, movement.normalized, out RaycastHit wallHit, movement.magnitude - Vector3.Dot(movingPlatformCompensation, movement.normalized), groundLayer)) {
            return wallHit.normal;
        }
        else
        {
            if (Physics.Raycast(transform.position + movement.normalized * (movement.magnitude - Vector3.Dot(movingPlatformCompensation, movement.normalized)), Vector3.down, out RaycastHit _, footHeight + feather, groundLayer))
            {
                return Vector3.zero;
            }
            else
            {
                if (Physics.Raycast(transform.position + movement + Vector3.down * (footHeight + feather), -movement.normalized, out RaycastHit groundHit, movement.magnitude + feather  - Vector3.Dot(movingPlatformCompensation, movement.normalized), groundLayer))
                {
                    return -groundHit.normal;
                }
                else
                {
                    return -movement.normalized;
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (trackedGround != null)
        {
            groundOffset = Quaternion.Inverse(trackedGround.transform.rotation) * (transform.position - trackedGround.transform.position);
        }
    }
}
