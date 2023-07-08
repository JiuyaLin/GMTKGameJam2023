using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperSprite : MonoBehaviour
{

    protected Camera trackedCamera;

    protected Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        trackedCamera = FindAnyObjectByType<Camera>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        animator.transform.rotation = trackedCamera.transform.rotation;
    }
}
