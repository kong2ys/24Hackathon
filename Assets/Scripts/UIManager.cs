using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    public GameObject deathPanel;
    public GameObject inGamePanel;
    public GameObject pausePanel;
    public GameObject retryBtn;
    public GameObject player;
    public GameObject homeBtn;
    public GameObject continueBtn;

    public TextMeshProUGUI deathCount;
    
    private PlayerContorller _playerContorller;
    
    private void Start()
    {
        inGamePanel.SetActive(true);
        deathPanel.SetActive(false);
        _playerContorller = GameObject.FindWithTag("Player").GetComponent<PlayerContorller>();
    }

    public void DeathPanel()
    {
        inGamePanel.SetActive(false);
        deathPanel.SetActive(true);
    }
    
    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0; // game stop
    }

    public void OnClickContinue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1; // game continue
    }

    public void OnClickHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }

    public void Retry()
    {
        Debug.Log("클릭함");
        inGamePanel.SetActive(true);
        player.SetActive(true);
        deathPanel.SetActive(false);
        _playerContorller.init();
    }

    private void Update()
    {
        
        if (Input.GetButton("Cancel"))
        {
            Pause();
        }

        deathCount.text = GameManager.instance.DethCount.ToString();
    }
}
