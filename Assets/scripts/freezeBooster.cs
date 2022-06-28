using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezeBooster : booster
{
    public freezeBooster(int chance) : base (chance)
    {

    }

    void Start()
    {
        boosterInfo boost = Resources.Load<boosterInfo>("freezeBooster");

        chance = boost.Chance;
        freezeTime = boost.FreezeTime;
        killAll = boost.KillAll;
        monsterTap = boost.MonsterTap;
        StartCoroutine("timeForDeath");
    }
}
