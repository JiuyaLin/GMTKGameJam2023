using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Item
{
    public void onMeleeHit(GameObject enemy);

    public void onRangeHit(GameObject enemy);

    public void onMeleeUse(GameObject player, GameObject attack);

    public void onRangeUse(GameObject player, GameObject attack);

    public void onGain(GameObject player);

    public void onDrop(GameObject player);
}
