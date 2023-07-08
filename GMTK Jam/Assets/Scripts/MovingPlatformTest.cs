using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformTest : MonoBehaviour
{
    public float cycle = 2;
    public float timeTracker = 0;
    public Vector3 originalPosition;
    public int xMove = -1;
    public int yMove = 1;
    public int zMove = 1;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeTracker += Time.deltaTime;
        if (timeTracker > cycle * 6) timeTracker -= cycle * 6;
        if (timeTracker < cycle)
        {
            transform.position = originalPosition + new Vector3(xMove * timeTracker, 0, 0);
        }
        else if (timeTracker < cycle * 2)
        {
            transform.position = originalPosition + new Vector3(xMove * (cycle * 2 - timeTracker), 0, 0);
        }
        else if (timeTracker < cycle * 3)
        {
            transform.position = originalPosition + new Vector3(0, yMove * (timeTracker - cycle * 2), 0);
        }
        else if (timeTracker < cycle * 4)
        {
            transform.position = originalPosition + new Vector3(0, yMove * (cycle * 4 - timeTracker), 0);
        }
        else if (timeTracker < cycle * 5)
        {
            transform.position = originalPosition + new Vector3(0, 0, zMove * (timeTracker - cycle * 4));
        }
        else
        {
            transform.position = originalPosition + new Vector3(0, 0, zMove * (cycle * 6 - timeTracker));
        }
    }
}
