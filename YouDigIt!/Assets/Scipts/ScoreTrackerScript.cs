using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTrackerScript : MonoBehaviour
{
    public Text scoreCount;    
    public static int latestScore;
        
    void Update()
    {
        scoreCount.text = latestScore.ToString();
    }
}
