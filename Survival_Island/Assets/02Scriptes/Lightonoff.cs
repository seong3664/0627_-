using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_sensour : MonoBehaviour
{
    public Light StairLight;
    public AudioSource source;
    public AudioClip clip;
    void Start()
    {
        
    }
    //is trrgger 했을 때 통과 하면서 충돌 감지 하는 함수
    //콜백 함수라고 함 스스로 호출 하기 때문
    private void OnTriggerEnter(Collider other)     //콜라이더는 충돌 관련구조체
    {
        if(other.gameObject.tag == "Player")
        {
            source.PlayOneShot(clip,1.0f);
            StairLight.enabled = true;
            //충돌체의 태그를 감지한 후 맞으면 라이트 온
        }
    }
    //콜라이더 범위에 들어왔다가 빠져나갔을 때
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            source.PlayOneShot(clip, 1.0f);
            StairLight.enabled = false;
        }
    }
    void Update()
    {
        
    }
}
