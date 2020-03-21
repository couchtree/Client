using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
