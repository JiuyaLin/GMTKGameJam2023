using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperSprite : MonoBehaviour
{

    public Camera trackedCamera;

    public Animator animator;
    public Vector3 savedOffset;
    // Start is called before the first frame update
    public virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
        trackedCamera = FindAnyObjectByType<Camera>();
        savedOffset = animator.transform.localPosition;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        animator.transform.rotation = trackedCamera.transform.rotation;
        animator.transform.localPosition = savedOffset + new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * trackedCamera.transform.eulerAngles.x),
            -Mathf.Cos(Mathf.Deg2Rad * trackedCamera.transform.eulerAngles.x)) * 1f;
    }
}
