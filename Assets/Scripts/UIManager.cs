using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject deathPanel;
    public GameObject retryBtn;
    
    private void Start()
    {
        deathPanel.SetActive(false);
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void DeathPanel()
    {
        deathPanel.SetActive(true);
    }

    public void Retry()
    {
        deathPanel.SetActive(false);
    }
}
