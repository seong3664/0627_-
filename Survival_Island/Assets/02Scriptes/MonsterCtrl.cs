using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    [Header("컴포넌트")]
    public Animator animator;
    public NavMeshAgent agent;
    public Transform ThisMonster;
    public Transform Player;


    [Header("변수")]
    public float Trace = 15.0f;
    public float Attack = 2.5f;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        ThisMonster = this.gameObject.transform;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

 
    void Update()
    {
        float dist = Vector3.Distance(ThisMonster.position,Player.position);
        if (dist < Attack)
        {
            agent.isStopped = true;
            animator.SetBool("IsAtk", true);
        }
        else if (dist < Trace)
        {
            agent.isStopped = false;
            animator.SetBool("IsAtk", false);
            animator.SetBool("IsWalk", true);
            agent.destination = Player.position;
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("IsWalk", false);
        }
    }
}
