using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using TextMeshPro = TMPro.TextMeshPro;

public class UIManager : MonoBehaviour
{
    public GameObject StartButton;
    public TextMeshProUGUI SpeedNumber;
    public GameObject SpawnMenu;

    public TextMeshProUGUI FoodNumber;
    public TextMeshProUGUI CellNumber;
    public TextMeshProUGUI PhageNumber;

    public Slider FoodSlider;
    public Slider CellSlider;
    public Slider PhageSlider;

    private bool showMenu = false;
    private bool startGame = false;
    public float speed = 1.0f;
    public bool paused = false;

    void Start()
    {
        Time.timeScale = 0.0f;
        SpeedNumber.text = "0x";
        AudioListener.pause = true;
        showMenu = false;
        startGame = false;
        paused = true;
        SpawnMenu.SetActive(false);

        FoodSlider.onValueChanged.AddListener((value) =>
        {
            FoodNumber.text = value.ToString("0");
        });

        CellSlider.onValueChanged.AddListener((value) =>
        {
            CellNumber.text = value.ToString("0");
        });

        PhageSlider.onValueChanged.AddListener((value) =>
        {
            PhageNumber.text = value.ToString("0");
        });
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Paused();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayFast();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlaySuperFast();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ShowMenu();
        }

    }

    void CheckStartButton()
    {
        if (startGame == false)
        {
            StartButton.SetActive(false);
            startGame = true;
        }
    }

    public void Paused()
    {
        if (paused)
        {
            Time.timeScale = speed;
            SpeedNumber.text = speed + "x";
            paused = false;
            AudioListener.pause = false;
        }
        else
        {
            paused = true;
            Time.timeScale = 0.0f;
            SpeedNumber.text = "0x";
            AudioListener.pause = true;
        }
    }

    public void Play()
    {
        CheckStartButton();
        Time.timeScale = 1.0f;
        speed = 1.0f;
        paused = false;

        SpeedNumber.text = "1x";
        AudioListener.pause = false;
    }

    public void PlayFast()
    {
        CheckStartButton();
        SpeedNumber.text = "2x";
        paused = false;

        speed = 2.0f;
        Time.timeScale = 2.0f;
    }

    public void PlaySuperFast()
    {
        CheckStartButton();
        SpeedNumber.text = "4x";
        paused = false;

        speed = 4.0f;
        Time.timeScale = 4.0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        SpeedNumber.text = "1x";
        AudioListener.pause = false;
        paused = false;
        startGame = true;
        StartButton.SetActive(false);
    }

    public void ShowMenu()
    {
        if (showMenu)
        {
            SpawnMenu.SetActive(false);
            showMenu = false;
        }
        else
        {
            SpawnMenu.SetActive(true);
            showMenu = true;
        }

    }
}
