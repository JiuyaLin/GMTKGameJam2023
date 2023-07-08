using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement2 : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (trackedGround != null) {
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
        GetComponentInChildren<SpriteRenderer>().transform.rotation = trackedCamera.transform.rotation;
        requestedMovement = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * movementSpeed * Time.deltaTime;
        Vector3 normal = CheckMovement(requestedMovement);
        if (normal.sqrMagnitude == 0)
        {
            transform.position += requestedMovement;
        }
        else
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
            wallCheckDistance, movement.normalized, out RaycastHit wallHit, movement.magnitude, groundLayer)) {
            return wallHit.normal;
        }
        else
        {
            if (Physics.Raycast(transform.position + movement, Vector3.down, out RaycastHit _, footHeight + feather, groundLayer))
            {
                return Vector3.zero;
            }
            else
            {
                if (Physics.Raycast(transform.position + movement + Vector3.down * (footHeight + feather), -movement.normalized, out RaycastHit groundHit, movement.magnitude + feather, groundLayer))
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
