using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//兽人
public class Grunt : EnemyController
{
    [Header("Skill")]
    public float kickForce = 10f;       //击飞的力

    public void KickOff()
    {
        Debug.Log("KickOff");

        if (attackTarget != null)
        {
            transform.LookAt(attackTarget.transform);

            Vector3 direction = attackTarget.transform.position - transform.position;
            direction.Normalize();

            attackTarget.GetComponent<NavMeshAgent>().isStopped = true;
            attackTarget.GetComponent<NavMeshAgent>().velocity = direction * kickForce;
            attackTarget.GetComponent<Animator>().SetTrigger("Dizzy");
            Debug.Log("击飞" + kickForce + "米");
        }
    }
}
