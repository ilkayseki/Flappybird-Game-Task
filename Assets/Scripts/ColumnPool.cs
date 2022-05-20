using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize =5;
    public GameObject columnPrefab;
    public float spawnRate = 4f;
    public float columnMin=-1.2f;
    public float columnMax = 3f;
    
    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2 (-10f, -10f);
    private float timesinceLastspawned;
    private float spawnXPosition=1.68f;
    private int currentColumn=0;


    void Start()
    {
        
        columns = new GameObject [columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject) Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }

        timesinceLastspawned = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameStarted)
        {
            timesinceLastspawned += Time.deltaTime;
            if (timesinceLastspawned >= spawnRate)
            {
                timesinceLastspawned = 0;
                float spawnYPosition = Random.Range(columnMin, columnMax);
                columns [currentColumn].transform.position= new Vector2 (spawnXPosition, spawnYPosition);
                currentColumn++;
                if (currentColumn >= columnPoolSize)
                {
                    currentColumn = 0;
                }
            }
        } 
    }
        
}
