using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Managers;
using Core.Garden;

public class UIHomeScreen : MonoBehaviour
{
    [SerializeField]
    private MyGarden garden;

    public GameObject overlay;
    public GameObject credits;
    public GameObject settings;
    public GameObject homeScreen;
    public GameObject impressumScreen;
    public GameObject privacyScreen;

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


    public void OpenImpressum()
    {
        this.impressumScreen.SetActive(true);
        this.settings.SetActive(false);
    }

    public void CloseImpressum()
    {
        this.impressumScreen.SetActive(false);
        this.settings.SetActive(true);
    }

    public void OpenPrivacy()
    {
        this.privacyScreen.SetActive(true);
        this.settings.SetActive(false);
    }

    public void ClosePrivacy()
    {
        this.privacyScreen.SetActive(false);
        this.settings.SetActive(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        this.overlay.SetActive(false);
        this.settings.SetActive(false);
        this.credits.SetActive(false);

        this.healthCurValue.text = garden.Health.ToString();
        this.healthMaxValue.text = garden.MaxHealth.ToString();

        this.waterCurValue.text = garden.Water.ToString();
        this.waterMaxValue.text = garden.MaxWater.ToString();

        this.rankCurValue.text = garden.Rank.ToString();
        this.rankMaxValue.text = garden.MaxRank.ToString();

        this.dungCurValue.text = garden.Dung.ToString();
        this.dungMaxValue.text = garden.MaxDung.ToString();

        this.diseaseCurValue.text = garden.Disease.ToString();
        this.diseaseMaxValue.text = garden.MaxDisease.ToString();
    }

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
                TogglePlantInformation();
            }
            else
            {
                Application.Quit();
            }
        }
    }

    public void TogglePlantInformation()
    {
        if (this.overlay.activeSelf)
        {
            this.CloseStatistics();
        }
        else
        {
            this.OpenStatistics();
        }
    }
}
