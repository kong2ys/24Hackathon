using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{   

    public void StartBtn()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}