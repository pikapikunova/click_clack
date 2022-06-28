using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "booster", menuName = "Gameplay/ New booster")]
public class boosterInfo : ScriptableObject
{
    [SerializeField] private int chance;
    [SerializeField] private int freezeTime;
    [SerializeField] private bool killAll;
    [SerializeField] private int monsterTap;

    public int Chance => chance;
    public int FreezeTime => freezeTime;
    public bool KillAll => killAll;
    public int MonsterTap => monsterTap;

}