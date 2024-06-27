using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class container_spark : MonoBehaviour
{
    public GameObject sparkPrefair;
    public AudioClip clip;
    public AudioSource source;
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision coll)  //막히면서 충돌감지
    {
        Destroy(coll.gameObject);
        if (coll.gameObject.tag == "BULLET")
        {
            source.PlayOneShot(clip, 1f);
            var spark = Instantiate(sparkPrefair, coll.transform.position,Quaternion.identity);
            Destroy(spark, 0.2f);
        }
    }
}
