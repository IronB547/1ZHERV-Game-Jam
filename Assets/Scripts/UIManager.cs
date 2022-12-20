using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static bool paused = false;
    public GameObject StartButton;

    void Start()
    {
        Time.timeScale = 0.0f;
        AudioListener.pause = true;
        paused = true;
    }

    public void Paused()
    {
        Time.timeScale = 0.0f;
        AudioListener.pause = true;
        paused = false;
    }

    public void Play()
    {
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
        paused = true;
    }

    public void PlayFast()
    {
        Time.timeScale = 2.0f;
        paused = true;
    }

    public void PlaySuperFast()
    {
        Time.timeScale = 4.0f;
        paused = true;
    }


    public void StartGame()
    {
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
        StartButton.SetActive(false);
        paused = false;
    }
}
