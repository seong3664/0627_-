using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCTR : MonoBehaviour
{
    public float speed = 1500f;
    public Rigidbody rb;
    void Start()
    {
                    //Vector3.forward는 글로벌 좌표다.
        rb.AddForce(transform.forward * speed);  //로컬 좌표로 스피드만큼 나간다
        Destroy(this.gameObject, 3.0f);
    }
}
