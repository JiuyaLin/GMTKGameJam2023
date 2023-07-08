using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAppearParent : MonoBehaviour, SignalActivatable, SignalDeactivatable
{
    public bool activateOnStart;
    public float timeTracker = 0f;
    public List<BlockAppear> toActivate = new List<BlockAppear>();
    public List<BlockAppear> toDeactivate = new List<BlockAppear>();
    protected float delay = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        if (activateOnStart)
        {
            OnSignalActivate();
        }
    }

    void Update()
    {
        if (toActivate.Count > 0)
        {
            timeTracker -= Time.deltaTime;
            if (timeTracker <= 0)
            {
                toActivate[0].OnSignalActivate();
                toActivate.RemoveAt(0);
                timeTracker = delay;
            }
        }
        else if (toDeactivate.Count > 0)
        {
            timeTracker -= Time.deltaTime;
            if (timeTracker <= 0)
            {
                toDeactivate[0].OnSignalDeactivate();
                toDeactivate.RemoveAt(0);
                timeTracker = delay;
            }
        }
    }

    public void OnSignalActivate()
    {
        toActivate = new List<BlockAppear>(transform.GetComponentsInChildren<BlockAppear>());
    }

    public void OnSignalDeactivate()
    {
        toDeactivate = new List<BlockAppear>(transform.GetComponentsInChildren<BlockAppear>());
    }
}
