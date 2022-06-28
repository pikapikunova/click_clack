using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseMonsterTapBooster : booster
{

    public increaseMonsterTapBooster(int chance) : base(chance)
    {


    }


    void Start()
    {
        boosterInfo boost = Resources.Load<boosterInfo>("increaseMonsterTapBooster");

        chance = boost.Chance;
        freezeTime = boost.FreezeTime;
        killAll = boost.KillAll;
        monsterTap = boost.MonsterTap;
        StartCoroutine("timeForDeath");
    }
}
