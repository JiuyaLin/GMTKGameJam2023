using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class PlayerStats
{
    public static int hp, maxHp, speed, meleeDamage, rangeDamage;
    public static int baseHp, baseMaxHp, baseSpeed, baseMeleeDamage, baseRangeDamage;

    static PlayerStats()
    {
        baseHp = 3;
        baseMaxHp = 3;
        baseSpeed = 1;
        baseMeleeDamage = 1;
        baseRangeDamage = 1;
        
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
