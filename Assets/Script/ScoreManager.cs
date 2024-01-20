using System.Collections;
using System.Collections.Generic;
using Oculus.Platform;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    float points;
    private Text score;
    // Start is called before the first frame update
    void Start()
    {
        score= GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    
        score.text= points.ToString();
    }
    public void AddScore(){
        points+=4;
    }
    public void SubScore(){
        if(points>0)points--;
        else points=0;
    }
    public float GetScore(){
        return points;
    }
}
