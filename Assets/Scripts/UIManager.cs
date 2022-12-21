using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor;
using UnityEngine;
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

    void Start()
    {
        Time.timeScale = 0.0f;
        SpeedNumber.text = "0x";
        AudioListener.pause = true;
        showMenu = false;
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

    public void Paused()
    {
        Time.timeScale = 0.0f;
        SpeedNumber.text = "0x";
        AudioListener.pause = true;
    }

    public void Play()
    {
        Time.timeScale = 1.0f;
        SpeedNumber.text = "1x";
        AudioListener.pause = false;
    }

    public void PlayFast()
    {
        SpeedNumber.text = "2x";
        Time.timeScale = 2.0f;
    }

    public void PlaySuperFast()
    {
        SpeedNumber.text = "4x";
        Time.timeScale = 4.0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        SpeedNumber.text = "1x";
        AudioListener.pause = false;
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

    public void SpawnFood()
    {

    }

    public void SpawnCell()
    {

    }
    public void SpawnPhage()
    {

    }
}
