using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    [Header("���۳�Ʈ��")]
    public GameObject billetprefab;
    public Transform firePos;   //�߻� ��ġ
    public Animation fireAni;   //�߻�� �ִϸ��̼�
    public AudioSource source;
    public AudioClip clip;
    public ParticleSystem muzzleFlash;

    [Header("���� ������")]
    public float fireTime;
    public Hand_Ctrl Hand_Ctrl;
    public int BulletCount = 0;
    public bool emptyBull = false;
    void Start()
    {
        fireTime = Time.time;
        Hand_Ctrl = this.gameObject.GetComponent<Hand_Ctrl>();
        muzzleFlash.Stop();
    }

    void Update()
    {
        //if (Input.GetMouseButtonUp(0))
        //{
        //    muzzleFlash.Stop();
        //}
        #region �ѹ߾� �߻��ϴ� ����
        //���콺 ���� ��ư�� ������ �� 0�� ���콺 ���� 1�� ������ 2�� �ٹ�ư.
        //if (Input.GetMouseButtonDown(0))
        //{
        //    fire();             //�Լ� ȣ��
        //}
        #endregion
        #region ����� �߻��ϴ� ����
        if (!Hand_Ctrl.Isrun && BulletCount < 10)
        {
            if (Input.GetMouseButton(0))
            {
                //���� �ð����� ���Žð��� ���� �귯�� �ð��� �ȴ�.
                if (Time.time - fireTime > 0.5f)
                {
                    fire();
                    fireTime = Time.time;
                    muzzleFlash.Play();
                }
            }
        }
        if (BulletCount == 10)
        {
            //��ŸƮ �ڷ�ƾ
            //���� �� �����ڰ� ���ϴ� ��������
            //������� �Ҷ� ���
            StartCoroutine(Reload());    //�����߿� ���ϴ� ����̳� ������ ���� �Ҷ�
            //�Ʒ� Rload()ȣ��
        }
        #endregion
    }
    void fire()
    {
        ++BulletCount;
        source.PlayOneShot(clip, 1f);
        Instantiate(billetprefab, firePos.position, firePos.rotation); //������Ʈ ����
        fireAni.Play("fire");
        Invoke("muzzleFlashDiable", 0.03f);
    }
    IEnumerator Reload()
    {
        //emptyBull = true;
        fireAni.Play("pump2");
        //0.5�� �Ŀ�
        yield return new WaitForSeconds(0.6f);  //yield  0.5���Ŀ� ���� ��ȯ������ �ѱ��.
        BulletCount = 0;
       //emptyBull = false;
    }
    void muzzleFlashDiable()
    {
        muzzleFlash.Stop();
    }
}
