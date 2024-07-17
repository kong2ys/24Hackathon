using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{

    private GameManager _gameManager;
    public GameObject player;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("닿음");
            SoundManager.instance.PlaySfx(SoundManager.Sfx.lose);
            //Destroy(collision.gameObject);
            player.SetActive(false);
            _gameManager.GameOver();
        }
    }
}
