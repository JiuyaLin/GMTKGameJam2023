using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAppear : MonoBehaviour
{
    public Vector3 actualPosition;
    protected float appearTime = 0.3f;
    protected float appearFrom = 2f;
    public float appearingTracker = 0f;
    public bool active = false;
    public bool doneWithAnimation = true;

    // Start is called before the first frame update
    void Start()
    {
        actualPosition = transform.position;
        transform.position = actualPosition - Vector3.up * appearFrom;
        appearingTracker = appearTime;
        foreach (MeshRenderer mr in GetComponentsInChildren<MeshRenderer>())
        {
            mr.enabled = false;
        }
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.enabled = false;
        }
        foreach (GroundedPaperSprite gspr in GetComponentsInChildren<GroundedPaperSprite>())
        {
            gspr.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active && appearingTracker > 0)
        {
            appearingTracker = Mathf.Max(appearingTracker - Time.deltaTime, 0);
            transform.position = actualPosition - Vector3.up * appearingTracker / appearTime * appearFrom;
            foreach (MeshRenderer mr in GetComponentsInChildren<MeshRenderer>())
            {
                mr.enabled = true;
            }
            foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
            {
                sr.enabled = true;
            }
            foreach (GroundedPaperSprite gspr in GetComponentsInChildren<GroundedPaperSprite>())
            {
                gspr.enabled = appearingTracker == 0;
            }
        }
        else if (!active && appearingTracker < appearTime)
        {
            appearingTracker = Mathf.Min(appearingTracker + Time.deltaTime, appearTime);
            transform.position = actualPosition - Vector3.up * appearingTracker / appearTime * appearFrom;
            foreach (MeshRenderer mr in GetComponentsInChildren<MeshRenderer>())
            {
                mr.enabled = appearingTracker < appearTime;
            }
            foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
            {
                sr.enabled = appearingTracker < appearTime;
            }
            foreach (GroundedPaperSprite gspr in GetComponentsInChildren<GroundedPaperSprite>())
            {
                gspr.enabled = false;
            }
        }

        
    }

    public void OnSignalActivate()
    {
        active = true;
    }

    public void OnSignalDeactivate()
    {
        active = false;
    }
}
