using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<BirdController>() != null)
        {
            GameManager.Instance.BirdScored();
        }
    }
}
