using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class ZombieAni : MonoBehaviour
{   //어트리뷰트 attribute
    [Header("Component")]      //개발자가 쓰고 컴퓨터가 읽는다.
    public NavMeshAgent agent;      //추적할 대상을 찾는 네비기능
    public Transform Player;    //거리를 재기 위해
    public Transform ThisZombie;    //자기 좀비 위치
    public Animator animator;
    [Header ("관련 변수")]
    public float attackDist = 3.0f;  //공격 범위
    public float traceDist = 20.0f;  //추적 범위
    void Start()
    {
        //자기자신 게임 오브젝트 안에 NavMeshAgent 컴포넌트를 agent에 대입
        agent = GetComponent<NavMeshAgent>();
        //C# 비주얼 스튜디오면 agent = new NavMeshAgent();
        ThisZombie = this.gameObject.transform; //자신 게임 오브젝트에 트랜스폼 컴포넌트를 넣는다.
        Player = GameObject.FindGameObjectWithTag("Player").transform;
                        //하이라키 안에 있는 게임오브젝트의 태그를 읽어서 가져온다.
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        float distance = Vector3.Distance(ThisZombie.position, Player.position);
        //transform으로 설정해 .position으로 사용 가능
        if (distance <= attackDist)
        {
            agent.isStopped = true;   //추적 중지
            // Debug.Log("공격");
            animator.SetBool("IsAttack", true);
        }
        else if (distance <= traceDist)
        {
            animator.SetBool("IsAttack", false);
            agent.isStopped = false;        //추적 시작
            //Debug.Log("추적");
            animator.SetBool("IsTrace", true);
            agent.destination = Player.position;
        }
        else
        {
            animator.SetBool("IsTrace", false);
            agent.isStopped = true;
            //Debug.Log("추적 범위 벗어남");
        }

    }
}
