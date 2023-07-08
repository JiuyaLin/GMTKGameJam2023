using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedPaperSprite : PaperSprite
{
    public float footHeight = 0.5f;
    public float feather = 0.4f;
    public float wallCheckDistance = 0.5f;
    public float stairHeight = 0.4f;
    public LayerMask groundLayer;
    public bool onGround = false;
    public Transform trackedGround;
    public Vector3 groundOffset;
    public Vector3 requestedMovement;
    public Vector3 movingPlatformCompensation = Vector3.zero;

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (trackedGround != null)
        {
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
        if (Vector3.Dot(requestedMovement, Quaternion.Euler(0, trackedCamera.transform.rotation.eulerAngles.y, 0) * transform.right) < 0)
        {
            animator.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Vector3.Dot(requestedMovement, Quaternion.Euler(0, trackedCamera.transform.rotation.eulerAngles.y, 0) * transform.right) > 0)
        {
            animator.transform.localScale = new Vector3(1, 1, 1);
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
            wallCheckDistance, movement.normalized, out RaycastHit wallHit, movement.magnitude - Vector3.Dot(movingPlatformCompensation, movement.normalized), groundLayer))
        {
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
                if (Physics.Raycast(transform.position + movement + Vector3.down * (footHeight + feather), -movement.normalized, out RaycastHit groundHit, movement.magnitude + feather - Vector3.Dot(movingPlatformCompensation, movement.normalized), groundLayer))
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
