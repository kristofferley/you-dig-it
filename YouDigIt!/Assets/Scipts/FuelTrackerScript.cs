using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelTrackerScript : MonoBehaviour
{
    public Text fuelCount;    
    public static int latestFuel;
        
    void Update()
    {
        fuelCount.text = latestFuel.ToString();
    }
}
