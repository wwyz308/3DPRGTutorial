using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Attack", menuName = "Attack/Attack Data")]
public class AttackData_SO : ScriptableObject
{
    public float attackRange;
    public float skillRange;
    public float coolDown;
    public int minDamge;
    public int maxDamge;

    public float criticalMultiplier;    //暴击后的加成百分比
    public float criticalChance;        //暴击率 1 = 100% 暴击
}
