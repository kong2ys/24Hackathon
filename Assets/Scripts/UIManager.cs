using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private void Start()
    {
        deathPanel.SetActive(false);
    }

    public GameObject deathPanel;

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
}
