using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    // -5.08 sil  1.58 gelsin
    //-1.2  3
/*
    private float rand;
    
    void Start()
    {
        rand = Random.Range(-1.2f, 3f);
        transform.position = new Vector3(1.58f,rand,transform.position.z);
    }
*/
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameStarted)
        {
            transform.Translate(-2.1f*Time.deltaTime, 0, 0);
        }
       
        /*
        if (transform.position.x <= -5.08f)
        {
            Destroy(this);
        }
        */
    }
}
