using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class booster : MonoBehaviour, IPointerClickHandler
{
    public int chance;
    protected int freezeTime;
    protected bool killAll;
    protected int monsterTap;
    private static int deathTime = 5;

    public booster(int Chance)
    {
        chance = Chance;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (killAll)
            killMonsters();
        else
        {
            if (freezeTime != 0)
                freeze();
            else
                if (monsterTap != 0)
                    moreMonsterTaps();
        }
    }

    public void killMonsters()
    {
        StopCoroutine("timeForDeath");
        monster[] mons = FindObjectsOfType<monster>();
        print(mons.Length);
        for (int i = 0; i < mons.Length; i++)
            Destroy(mons[i].gameObject);
        
        Destroy(gameObject);
    }

    public void freeze()
    {
        StopCoroutine("timeForDeath");
        FindObjectOfType<spawn>().StopCoroutine("timer");
        StartCoroutine("timerForFreeze");
        gameObject.transform.position = new Vector3(10, 10, 10);
    }

    IEnumerator timerForFreeze()
    {
        yield return new WaitForSeconds(freezeTime);
        FindObjectOfType<spawn>().StartCoroutine("timer");
        Destroy(gameObject);
    }

    IEnumerator timeForDeath()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }

    public void moreMonsterTaps()
    {
        StopCoroutine("timeForDeath");
        FindObjectOfType<spawn>().addTaps(monsterTap);
        Destroy(gameObject);
    }
}
