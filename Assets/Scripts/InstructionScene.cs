using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionScene : MonoBehaviour
{
    public void LoadMenu()
    {
      SceneManager.LoadScene("MainMenu");
    }
}
