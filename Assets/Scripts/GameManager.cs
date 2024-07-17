using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int DethCount = 0;

    public UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void GameOver()
    {
        DethCount += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
