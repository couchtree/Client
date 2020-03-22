using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    [SerializeField]
    GameObject homeScreen;

    [SerializeField]
    GameObject settings;

    [SerializeField]
    GameObject credits;

    [SerializeField]
    GameObject infoSapling;

    [SerializeField]
    Toggle plantInfoToggle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (credits.activeSelf)
            {
                credits.SetActive(false);
            }
            else if (settings.activeSelf)
            {
                settings.SetActive(false);
            }else if (infoSapling.activeSelf)
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
        if (infoSapling.activeSelf)
        {
            infoSapling.SetActive(false);
        }
        else
        {
            infoSapling.SetActive(true);
        }
    }
}
