using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {
    public Text Error;                          //error text box
    public InputField NumberObstacle;
    public InputField Flockmembers;
    public Toggle Blue;
    public Toggle Green;
    public Toggle Red;
    public Toggle Player;
    public static int intFlockMembers=0;
    public static int intamountObstacles=0;
    public static bool blue;
    public static bool green;
    public static bool red;
    public static bool player;
    public static int count = 0;
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void ChangeScene(string sceneName)       //loads Main Simulation Scene
    {
        Debug.Log(count);
        if (count==3)
        {
             Error.text="Please select a colour";
            Debug.Log("all unselected");       
        }
        else
        {
            if (intFlockMembers==0 || intamountObstacles==0)
            {
                Error.text=("All input fields require a value");
                return;
            }
            else
            {
                Debug.Log("Change scene");
                SceneManager.LoadScene("MainSimulation");
            }
                            
        }
    }

    public void FormatObstacles()               //error checking obstacles input field
    {
        try
        {
            string NumberObstacles = NumberObstacle.text;
            intamountObstacles = Convert.ToInt32(NumberObstacles);
            Debug.Log("Obstacles = " + intamountObstacles);
            Error.text = "";
            if (intamountObstacles==0)
            {
                NumberObstacle.text = "1";
                intamountObstacles = 1;
                Error.text = "Please input amount of obstacles wanted";
            }
        }
        catch
        {
            NumberObstacle.text = "1";            
            intamountObstacles = 1;
            Error.text = "Please input amount of obstacles wanted";           
        }       
    }
    public void FormatMembers()                 //error checking number of members
    {
        try
        {
            string amountMembers = Flockmembers.text;
            intFlockMembers = Convert.ToInt32(amountMembers);
            Debug.Log("Number Units wanted equals " + intFlockMembers);
            Error.text = "";
            if (intFlockMembers <= 2)
            {
                Error.text = "Flock members must be greater than 2";
                Debug.Log("Low range error");
                intFlockMembers = 20;
                Flockmembers.text = "20";
            }
        }
        catch
        {     
                Error.text = "Flock members must be greater than 2";
                Flockmembers.text = "20";
                intFlockMembers = 20;
                Debug.Log("catch");   
        }

    }
    /// <summary>
    /// the following classes all check the boolean inputs for the colour and player creations
    /// </summary>
    public void ToggleBlue()               
    {
        if (Blue)
        {
            blue = true;
            
        }
        else
        {
            blue = false;
            count++;
        }
    }
    public void ToggleGreen()
    {
        if (Green)
        {
            green = true;
            
        }
        else
        {
            count++;
            green = false;
        }
    }
    public void ToggleRed()
    {
        if (Red)
        {
            red = true;
            
        }
        else
        {
            count++;
            red = false;
        }
    }
        public void PlayerToggle()
    {
        if (Player==true)
        {
            player = true;
        }
        else
        {
            player = false;
        }
    }
    


    


   

}
