using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public virtual float Weight => 0f;

    public abstract void OnMeleeHit(GameObject enemy);

    public abstract void OnRangeHit(GameObject enemy);

    public abstract void OnMeleeUse(GameObject attack);

    public abstract void OnRangeUse(GameObject attack);

    public virtual void OnGain()
    {
        GameObject.FindObjectWithTag("Player").movementSpeed -= Weight / 2;
        GameObject.FindObjectWithTag("Player").rollSpeed -= Weight;
    }

    public virtual void OnDrop()
    {
        GameObject.FindObjectWithTag("Player").movementSpeed += Weight / 2;
        GameObject.FindObjectWithTag("Player").rollSpeed += Weight;
    }

    public abstract void OnHurt();

    public abstract string GetName();

    public abstract Sprite GetSprite();
}
