using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{    
    void Start()
    {
        GetComponent<Text>().text = ScoreTrackerScript.latestScore.ToString();
    }    
}

