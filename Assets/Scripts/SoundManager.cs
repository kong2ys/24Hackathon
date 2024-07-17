using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum Sfx
    {
        jump,
        test
    }

    [Header("BGM SET")]
    public AudioClip bgmClip;
    private AudioSource bgmPlayer;

    [Header("SFX SET")]
    public AudioClip[] sfxClips;
    public int channels;
    private AudioSource[] sfxPlayers;
    private int channelIndex;
    
    void Start()
    {
        GameObject bgmObject
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
