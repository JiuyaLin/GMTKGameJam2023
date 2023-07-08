using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    public List<Transform> activate;
    public bool active = false;

    public override void OnInteract()
    {
        active = !active;
        foreach (Transform transformToActivate in activate)
        {
            if (active)
            {
                foreach (SignalActivatable activatable in transformToActivate.GetComponentsInChildren<SignalActivatable>())
                {
                    activatable.OnSignalActivate();
                }
            }
            else
            {
                foreach (SignalDeactivatable deActivatable in transformToActivate.GetComponentsInChildren<SignalDeactivatable>())
                {
                    deActivatable.OnSignalDeactivate();
                }
            }
        }
    }
}
