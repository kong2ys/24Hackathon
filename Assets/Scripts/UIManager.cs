using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject clearPannel;
    public GameObject deathPanel;
    public GameObject inGamePanel;
    public GameObject pausePanel;
    public GameObject retryBtn;
    public GameObject player;
    public GameObject homeBtn;
    public GameObject continueBtn;

    public TextMeshProUGUI deathCount;
    public TextMeshProUGUI gameTime;
    
    private PlayerContorller _playerContorller;

    private float sec;
    private int min;
    
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
        Time.timeScale = 0;
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
        clearPannel.SetActive(false);
        _playerContorller.init();
        Time.timeScale = 1;
    }

    public void Clear()
    {
        Debug.Log("클리어");
        inGamePanel.SetActive(false);
        Time.timeScale = 0;
        clearPannel.SetActive(true);
    }

    private void Update()
    {
        
        if (Input.GetButton("Cancel"))
        {
            Pause();
        }

        deathCount.text = GameManager.instance.DethCount.ToString();

        #region Timer

        sec += Time.deltaTime;
        if (sec >= 60f)
        {
            min += 1;
            sec = 0;
        }

        gameTime.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);

        #endregion
        
    }
}
