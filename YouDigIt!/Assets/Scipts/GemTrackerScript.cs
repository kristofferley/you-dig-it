using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemTrackerScript : MonoBehaviour
{
    public Text gemCount;    
    public static int latestGems;
        
    void Update()
    {
        gemCount.text = latestGems.ToString();
    }
}
