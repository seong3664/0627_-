using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class ZombieAni : MonoBehaviour
{   //��Ʈ����Ʈ attribute
    [Header("Component")]      //�����ڰ� ���� ��ǻ�Ͱ� �д´�.
    public NavMeshAgent agent;      //������ ����� ã�� �׺���
    public Transform Player;    //�Ÿ��� ��� ����
    public Transform ThisZombie;    //�ڱ� ���� ��ġ
    public Animator animator;
    [Header ("���� ����")]
    public float attackDist = 3.0f;  //���� ����
    public float traceDist = 20.0f;  //���� ����
    void Start()
    {
        //�ڱ��ڽ� ���� ������Ʈ �ȿ� NavMeshAgent ������Ʈ�� agent�� ����
        agent = GetComponent<NavMeshAgent>();
        //C# ���־� ��Ʃ����� agent = new NavMeshAgent();
        ThisZombie = this.gameObject.transform; //�ڽ� ���� ������Ʈ�� Ʈ������ ������Ʈ�� �ִ´�.
        Player = GameObject.FindGameObjectWithTag("Player").transform;
                        //���̶�Ű �ȿ� �ִ� ���ӿ�����Ʈ�� �±׸� �о �����´�.
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        float distance = Vector3.Distance(ThisZombie.position, Player.position);
        //transform���� ������ .position���� ��� ����
        if (distance <= attackDist)
        {
            agent.isStopped = true;   //���� ����
            // Debug.Log("����");
            animator.SetBool("IsAttack", true);
        }
        else if (distance <= traceDist)
        {
            animator.SetBool("IsAttack", false);
            agent.isStopped = false;        //���� ����
            //Debug.Log("����");
            animator.SetBool("IsTrace", true);
            agent.destination = Player.position;
        }
        else
        {
            animator.SetBool("IsTrace", false);
            agent.isStopped = true;
            //Debug.Log("���� ���� ���");
        }

    }
}
