using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//石头人扔出去的石头

public class Rock : MonoBehaviour
{
    public enum RockStates { HitPlayer, HitEnemy, HitNothing }
    public RockStates rockStates;

    private Rigidbody rb;

    [Header("Basic Settings")]

    public float force;     //向前冲击的力
    public int damage;

    public GameObject target;
    private Vector3 direction;
    public GameObject breakEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.one;

        rockStates = RockStates.HitPlayer;
        FlyToTarget();
    }

    private void FixedUpdate()
    {
        if(rb.velocity.sqrMagnitude < 1f)
        {
            rockStates = RockStates.HitNothing;
        }
    }

    public void FlyToTarget()
    {
        if (target == null)
            target = FindObjectOfType<PlayerController>().gameObject;

        direction = (target.transform.position - transform.position + Vector3.up).normalized;
        rb.AddForce(direction * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (rockStates)
        {
            case RockStates.HitPlayer:
                {
                    if (other.gameObject.CompareTag("Player"))
                    {
                        direction = target.transform.position - transform.position;
                        direction.Normalize();

                        other.gameObject.GetComponent<NavMeshAgent>().isStopped = true;
                        other.gameObject.GetComponent<NavMeshAgent>().velocity = direction * force;

                        other.gameObject.GetComponent<Animator>().SetTrigger("Dizzy");
                        other.gameObject.GetComponent<CharacterStats>().TakeDamage(damage, other.gameObject.GetComponent<CharacterStats>());

                        rockStates = RockStates.HitNothing;
                    }
                }
                break;
            case RockStates.HitEnemy:
                {
                    if(other.gameObject.GetComponent<Golem>())
                    {
                        var otherStats = other.gameObject.GetComponent<CharacterStats>();
                        otherStats.TakeDamage(damage, otherStats);

                        Instantiate(breakEffect, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                }
                break;
            case RockStates.HitNothing:
                {
                }
                break;
        }
    }
}
