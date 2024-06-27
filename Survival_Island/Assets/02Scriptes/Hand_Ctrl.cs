using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Hand_Ctrl : MonoBehaviour
{
    public Animation ComBatSGAni;
    public Light flashLight;
    public AudioClip flashsound;   //소리파일
    public AudioSource A_sourse;   //오디오 소스
    public bool Isrun = false;
    void Start()    //게임 시작 전 호출
    {
        
    }

    void Update()    //게임 시작 후 계속 호출
    {
        GunCrtl();
        flashlightonoff();
    }

    private void flashlightonoff()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            A_sourse.PlayOneShot(flashsound, 1.0f);
            //소리 파일    소리 볼륨
            flashLight.enabled = !flashLight.enabled;
        }
    }

    private void GunCrtl()
    {
       
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {

                ComBatSGAni.Play("running");
            Isrun = true;
        }
        
        else if (Input.GetKeyUp(KeyCode.LeftShift))    //왼쪽 쉬프트 키를 띄었다면
        {
            ComBatSGAni.Play("runStop");
            Isrun = false;
        }
    }
}

