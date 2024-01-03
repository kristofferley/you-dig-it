using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuitterScript : MonoBehaviour
{    
    public void QuitGame()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}