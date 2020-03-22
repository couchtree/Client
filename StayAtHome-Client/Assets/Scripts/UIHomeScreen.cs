using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Managers;

public class UIHomeScreen : MonoBehaviour
{

    public GameObject overlay;
    public GameObject credits;
    public GameObject settings;
    public GameObject homeScreen;

    public TextMeshProUGUI healthCurValue;
    public TextMeshProUGUI healthMaxValue;

    public TextMeshProUGUI waterCurValue;
    public TextMeshProUGUI waterMaxValue;

    public TextMeshProUGUI rankCurValue;
    public TextMeshProUGUI rankMaxValue;

    public TextMeshProUGUI dungCurValue;
    public TextMeshProUGUI dungMaxValue;

    public TextMeshProUGUI diseaseCurValue;
    public TextMeshProUGUI diseaseMaxValue;

    public void OpenSettings()
    {
        // TODO
        this.settings.SetActive(true);
        this.homeScreen.SetActive(false);
    }

    public void OpenCredits()
    {
        this.credits.SetActive(true);
        this.settings.SetActive(false);
    }

    public void CloseSettings()
    {
        this.homeScreen.SetActive(true);
        this.settings.SetActive(false);
    }

    public void CloseCredits()
    {
        this.settings.SetActive(true);
        this.credits.SetActive(false);
    }

    public void OpenStatistics()
    {
        this.overlay.SetActive(true);
    }

    public void CloseStatistics()
    {
        this.overlay.SetActive(false);
    }

    public void ToggleStatistics()
    {
        if(this.overlay.activeSelf)
        {
            this.CloseStatistics();
        }
        else
        {
            this.OpenStatistics();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.overlay.SetActive(false);

        this.healthCurValue.text = GameManager.Instance.Garden.Health.ToString();
        this.healthMaxValue.text = GameManager.Instance.Garden.MaxHealth.ToString();

        this.waterCurValue.text = GameManager.Instance.Garden.Water.ToString();
        this.waterMaxValue.text = GameManager.Instance.Garden.MaxWater.ToString();

        this.rankCurValue.text = GameManager.Instance.Garden.Rank.ToString();
        this.rankMaxValue.text = GameManager.Instance.Garden.MaxRank.ToString();

        this.dungCurValue.text = GameManager.Instance.Garden.Dung.ToString();
        this.dungMaxValue.text = GameManager.Instance.Garden.MaxDung.ToString();

        this.diseaseCurValue.text = GameManager.Instance.Garden.Disease.ToString();
        this.diseaseMaxValue.text = GameManager.Instance.Garden.MaxDisease.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (this.credits.activeSelf)
            {
                this.CloseCredits();
            }
            else if (this.settings.activeSelf)
            {
                this.CloseSettings();
            }
            else if (this.overlay.activeSelf)
            {
                this.ToggleStatistics();
            }
            else if(this.homeScreen.activeSelf)
            {
                Application.Quit();
            }
        }
    }
}
