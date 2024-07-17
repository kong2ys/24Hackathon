using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int DethCount = 0;

    private UIManager _uiManager;
    

    public UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public void GameOver()
    {
        DethCount += 1;
        _uiManager.DeathPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}