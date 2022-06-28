using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decreaseMonsterTapBooster : booster
{

    public decreaseMonsterTapBooster(int chance) : base(chance)
    {


    }

    void Start()
    {
        boosterInfo boost = Resources.Load<boosterInfo>("decreaseMonsterTapBooster");

        chance = boost.Chance;
        freezeTime = boost.FreezeTime;
        killAll = boost.KillAll;
        monsterTap = boost.MonsterTap;
        StartCoroutine("timeForDeath");
    }

}
