using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject deathPanel;
    public GameObject retryBtn;

    private PlayerContorller _playerContorller;
    
    private void Start()
    {
        deathPanel.SetActive(false);
        _playerContorller = GameObject.Find("Player").GetComponent<PlayerContorller>();
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
        _playerContorller.init();
    }
}
