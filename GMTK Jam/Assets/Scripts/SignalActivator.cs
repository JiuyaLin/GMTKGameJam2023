using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalActivator : MonoBehaviour
{
    public Transform signalToActivate;
    public bool activateOnStart;
    public float timeTracker = 0f;
    public List<SignalActivatable> toActivate = new List<SignalActivatable>();
    public List<SignalDeactivatable> toDeactivate = new List<SignalDeactivatable>();
    protected float delay = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        if (activateOnStart)
        {
            ActivateSignal();
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

    void ActivateSignal()
    {
        toActivate = new List<SignalActivatable>(signalToActivate.GetComponentsInChildren<SignalActivatable>());
    }

    void DeactivateSignal()
    {
        toDeactivate = new List<SignalDeactivatable>(signalToActivate.GetComponentsInChildren<SignalDeactivatable>());
    }
}
