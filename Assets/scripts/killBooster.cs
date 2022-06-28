using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killBooster : booster
{
    public killBooster(int chance) : base(chance)
    {


    }


    void Start()
    {
        boosterInfo boost = Resources.Load<boosterInfo>("killBooster");

        chance = boost.Chance;
        freezeTime = boost.FreezeTime;
        killAll = boost.KillAll;
        monsterTap = boost.MonsterTap;
        StartCoroutine("timeForDeath");
    }
}
