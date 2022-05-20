using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    #region Singleton 

    public static BirdController Instance { get; private set; }
    private void Awake() 
    { 
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    #endregion
    
    
    private Rigidbody2D rig;

    public float jumpSpeed;
    
    public float turnSpeed;

    public bool isDead = false;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity=Vector2.zero;
        rig.gravityScale = 0;
    }

    void Update()
    {
        if (GameManager.Instance.isGameStarted == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)||Input.touchCount>0)
            {
                GameManager.Instance.GameStart();
                rig.gravityScale = 0.8f;
            }
        }

        else if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)||Input.touchCount>0)
            {
                rig.velocity=Vector2.up * jumpSpeed;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 60f);
            }
            else
            {
                transform.eulerAngles -= new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, turnSpeed);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        isDead = true;
        GameManager.Instance.BirdDied();
    }
}
