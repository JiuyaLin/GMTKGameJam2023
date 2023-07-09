using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class PlayerStats
{
    public static int hp, maxHp, speed, meleeDamage, rangeDamage;
    public static int baseHp, baseMaxHp, baseSpeed, baseMeleeDamage, baseRangeDamage;
    public static bool isImmune;

    static PlayerStats()
    {
        baseHp = 100;
        baseMaxHp = 100;
        baseSpeed = 1;
        baseMeleeDamage = 5;
        baseRangeDamage = 5;
        
        resetStats();
    }

    public static void resetStats() {
        hp = baseHp;
        maxHp = baseMaxHp;
        speed = baseSpeed;
        meleeDamage = baseMeleeDamage;
        rangeDamage = baseRangeDamage;
    }
}
