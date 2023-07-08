using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public virtual float Weight => 0f;
    public abstract void OnMeleeHit(GameObject enemy);

    public abstract void OnRangeHit(GameObject enemy);

    public abstract void OnMeleeUse(ThirdPersonMovement2 player, GameObject attack);

    public abstract void OnRangeUse(ThirdPersonMovement2 player, GameObject attack);

    public virtual void OnGain(ThirdPersonMovement2 player)
    {
        player.movementSpeed -= Weight / 2;
        player.rollSpeed -= Weight;
    }

    public virtual void OnDrop(ThirdPersonMovement2 player)
    {
        player.movementSpeed += Weight / 2;
        player.rollSpeed += Weight;
    }

    public abstract void OnHurt(ThirdPersonMovement2 player);
}
