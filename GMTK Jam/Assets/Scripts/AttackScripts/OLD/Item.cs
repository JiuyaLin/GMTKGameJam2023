using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Item
{
    public void onContact(GameObject enemy);

    public void onCast (GameObject player);

    public void onGain(GameObject player);

    public void onDrop(GameObject player);
}
