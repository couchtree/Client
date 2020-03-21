﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Managers;

public class UIHomeScreen : MonoBehaviour
{

    public GameObject overlay;

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

        Debug.Log(GameManager.Instance);

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
        
    }
}