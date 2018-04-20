using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimUI : MonoBehaviour
{
    public Text Information;
    public void Start()
    {
        
    }
    public void Update()
    {
        InfoOutput();
    }

    public void ReturnToMenu(string scenename)
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void InfoOutput()                    //assigns text in simulation
    {
        if (Settings.blue&&Settings.red&&Settings.green)
        {
            Information.text = ("Units per Flock: 0    Obstacles: " + ObstacleController.columnslength);
        }
        else
        {
            Information.text = ("Units per Flock: " + Settings.intFlockMembers+"   Obstacles: "+ObstacleController.columnslength);
        }
        
    }
}
   