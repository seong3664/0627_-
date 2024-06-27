using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    [Header("컴퍼넌트들")]
    public GameObject billetprefab;
    public Transform firePos;   //발사 위치
    public Animation fireAni;   //발사시 애니메이션
    public AudioSource source;
    public AudioClip clip;
    public ParticleSystem muzzleFlash;

    [Header("각종 변수들")]
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
        #region 한발씩 발사하는 로직
        //마우스 왼쪽 버튼이 눌렸을 때 0은 마우스 왼쪽 1은 오른쪽 2는 휠버튼.
        //if (Input.GetMouseButtonDown(0))
        //{
        //    fire();             //함수 호출
        //}
        #endregion
        #region 연사로 발사하는 로직
        if (!Hand_Ctrl.Isrun && BulletCount < 10)
        {
            if (Input.GetMouseButton(0))
            {
                //현재 시간에서 과거시간을 뺴면 흘러간 시간이 된다.
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
            //스타트 코루틴
            //게임 중 개발자가 원하는 프레임을
            //만들려고 할때 사용
            StartCoroutine(Reload());    //게임중에 원하는 장면이나 프레임 구현 할때
            //아래 Rload()호출
        }
        #endregion
    }
    void fire()
    {
        ++BulletCount;
        source.PlayOneShot(clip, 1f);
        Instantiate(billetprefab, firePos.position, firePos.rotation); //오브젝트 생성
        fireAni.Play("fire");
        Invoke("muzzleFlashDiable", 0.03f);
    }
    IEnumerator Reload()
    {
        //emptyBull = true;
        fireAni.Play("pump2");
        //0.5초 후에
        yield return new WaitForSeconds(0.6f);  //yield  0.5초후에 다음 반환값으로 넘긴다.
        BulletCount = 0;
       //emptyBull = false;
    }
    void muzzleFlashDiable()
    {
        muzzleFlash.Stop();
    }
}
