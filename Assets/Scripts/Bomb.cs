using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Transform birdPosition;

    private  GameObject[] objs ;

    public void BombDestroy()
    {
        if (!GameManager.Instance.gameOver)
        {
            birdPosition = BirdController.Instance.transform;

            objs = GameObject.FindGameObjectsWithTag("pipe");
            foreach(GameObject lightuser in objs) {
                lightuser.GetComponent<Transform>().position=new Vector2(-10f,-10f);
            }

            this.gameObject.SetActive(false);

        }
        
    }

    public void CreateBomb()
    {
     this.gameObject.SetActive(true);
    }

}
