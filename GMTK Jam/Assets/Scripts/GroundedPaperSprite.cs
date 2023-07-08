using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedPaperSprite : PaperSprite
{
    public float footHeight = 0.5f;
    public float wallCheckDistance = 0.5f;
    protected float stairHeight = 0.6f;
    protected float stayAwayFromEdge = 0.2f;
    public LayerMask groundLayer;
    public bool onGround = false;
    public Transform trackedGround;
    public Vector3 groundOffset;
    public Vector3 requestedMovement;
    public Vector3 movingPlatformCompensation = Vector3.zero;
    public Vector3 facingDirection = Vector3.right;
    protected bool automaticallyUpdateFacingDirection = true;

    public override void Start()
    {
        base.Start();
        groundLayer = LayerMask.GetMask(new string[] { "Ground" });
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        requestedMovement -= Vector3.up * requestedMovement.y;
        if (trackedGround != null)
        {
            movingPlatformCompensation = trackedGround.transform.position + trackedGround.transform.rotation * groundOffset - transform.position;
            transform.position = trackedGround.transform.position + trackedGround.transform.rotation * groundOffset;
        }
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, footHeight + stairHeight, groundLayer))
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
        if (automaticallyUpdateFacingDirection && requestedMovement.sqrMagnitude != 0)
        {
            facingDirection = requestedMovement.normalized;
        }
        double horiz = (Quaternion.Euler(0, -trackedCamera.transform.eulerAngles.y, 0) * facingDirection).x;
        if (horiz < 0)
        {
            animator.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horiz > 0)
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
        if (requestedMovement.sqrMagnitude != 0)
        {
            facingDirection = requestedMovement.normalized;
        }
        if (trackedGround != null)
        {
            groundOffset = Quaternion.Inverse(trackedGround.transform.rotation) * (transform.position - trackedGround.transform.position);
        }
    }

    Vector3 CheckMovement(Vector3 movement)
    {
        if (Physics.CapsuleCast(transform.position + movingPlatformCompensation + Vector3.up * footHeight / 2,
            transform.position + movingPlatformCompensation - Vector3.up * (footHeight / 2 - stairHeight),
            wallCheckDistance, movement.normalized, out RaycastHit wallHit, movement.magnitude, groundLayer))
        {
            return wallHit.normal;
        }
        else
        {
            if (Physics.Raycast(transform.position + movingPlatformCompensation + movement.normalized * (movement.magnitude + stayAwayFromEdge),
                Vector3.down, out RaycastHit _, footHeight + stairHeight, groundLayer))
            {
                return Vector3.zero;
            }
            else
            {
                if (Physics.Raycast(transform.position + movingPlatformCompensation + movement.normalized * (movement.magnitude + stayAwayFromEdge) + Vector3.down * (footHeight + stairHeight), -movement.normalized, out RaycastHit groundHit, movement.magnitude + stairHeight - Vector3.Dot(movingPlatformCompensation, movement.normalized), groundLayer))
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
}
