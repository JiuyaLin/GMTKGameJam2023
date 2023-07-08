using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    public static int hp, maxHp, speed, meleeDamage, rangeDamage;

    static PlayerStats()
    {
        hp = 3;
        maxHp = 3;
        speed = 1;
        meleeDamage = 1;
        rangeDamage = 1;
    }
}
