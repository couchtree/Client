using Core.Garden;
using Core.Map;
using UnityEngine;
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

    [Header("Text references")]
    public TextMeshProUGUI playerNameTextField;
    public TextMeshProUGUI gardenNameTextField;

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

    // Start is called before the first frame update
    void Start()
    {
        this.overlay.SetActive(false);
        this.settings.SetActive(false);
        this.credits.SetActive(false);
        
        this.healthCurValue.text = MyGarden.Instance.Health.ToString();
        this.healthMaxValue.text = MyGarden.Instance.MaxHealth.ToString();

        this.waterCurValue.text = MyGarden.Instance.Water.ToString();
        this.waterMaxValue.text = MyGarden.Instance.MaxWater.ToString();

        this.rankCurValue.text = MyGarden.Instance.Rank.ToString();
        this.rankMaxValue.text = MyGarden.Instance.MaxRank.ToString();

        this.dungCurValue.text = MyGarden.Instance.Dung.ToString();
        this.dungMaxValue.text = MyGarden.Instance.MaxDung.ToString();

        this.diseaseCurValue.text = MyGarden.Instance.Disease.ToString();
        this.diseaseMaxValue.text = MyGarden.Instance.MaxDisease.ToString();

        this.playerNameTextField.text = Player.Instance.Name;
        this.gardenNameTextField.text = MyGarden.Instance.Name;
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