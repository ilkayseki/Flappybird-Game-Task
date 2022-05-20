using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    #region Singleton 

    public static Leaderboard Instance { get; private set; }
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

    
    
    private int hs1;
    private int hs2;
    private int hs3;
    private int hs4;
    private int hs5;
    
    private int[] hs;

    private int temp;

    private bool isHs = false;

    public TextMeshProUGUI hs1_text;
    public TextMeshProUGUI hs2_text;
    public TextMeshProUGUI hs3_text;
    public TextMeshProUGUI hs4_text;
    public TextMeshProUGUI hs5_text;

    public GameObject cong;

    void Start()
    {
        CreateLeaderboard();
    }

    public void GetScore(int score)
    {
        for (int i = 0; i < hs.Length; i++)
        {
            if (score>=hs[i])
            {
                //Debug.Log(i+"----"+hs[i]+"-"+score);
                Debug.Log(score+" büyüktür "+hs[i]);
                temp = hs[i];
                hs[i] = score;
                score = temp;
                isHs = true;
            }

        }

        WriteLeaderboard();

        ShowNotification();

    }


    private void CreateLeaderboard()
    {
        hs = new int[5];
        
        if (!PlayerPrefs.HasKey("hs1"))
        {
            PlayerPrefs.SetInt("hs1",10);
        }
            
            
        if (!PlayerPrefs.HasKey("hs2"))
        {
            PlayerPrefs.SetInt("hs2",7);
        }
       
           
        
        
        if (!PlayerPrefs.HasKey("hs3"))
        {
            PlayerPrefs.SetInt("hs3",6);
        }
        
         
        
        
        if (!PlayerPrefs.HasKey("hs4"))
        {
            PlayerPrefs.SetInt("hs4",5);
        }
        
            
       
        
        if (!PlayerPrefs.HasKey("hs5"))
        {
            PlayerPrefs.SetInt("hs5",4);
        }
       

        hs1=PlayerPrefs.GetInt("hs1");
        hs2=PlayerPrefs.GetInt("hs2");
        hs3=PlayerPrefs.GetInt("hs3");
        hs4=PlayerPrefs.GetInt("hs4");
        hs5=PlayerPrefs.GetInt("hs5");
        
        hs[0] = hs1;
        hs[1] = hs2;
        hs[2] = hs3;
        hs[3] = hs4;
        hs[4] = hs5;
    }


    private void WriteLeaderboard()
    {
        hs1_text.text = hs[0].ToString();
        hs2_text.text = hs[1].ToString();
        hs3_text.text = hs[2].ToString();
        hs4_text.text = hs[3].ToString();
        hs5_text.text = hs[4].ToString();
    }

    private void ShowNotification()
    {
        if (isHs)
        {
            cong.SetActive(true);
            isHs = false;
        }
    }
    
    
}
