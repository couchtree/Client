using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class FieldMandetory : MonoBehaviour
{
    public Button thisButton; // Button on same gameobject
    public TextMeshProUGUI mandetoryTextField;

    public TextMeshProUGUI errorTextField;

    public GameObject currentPanel;
    public GameObject nextPanel;

    private string defaultText;
    // Start is called before the first frame update
    void Start()
    {
        if (thisButton == null)
        {
            thisButton = GetComponent<Button>();
        }
        else
        {
            thisButton.onClick.AddListener(TaskOnClick);
        }
        defaultText = mandetoryTextField.text;
    }

    void TaskOnClick()
    {
        Debug.Log("Test inside mandetory field: " + mandetoryTextField.text);
        if (mandetoryTextField.text == "" || mandetoryTextField.text == defaultText)
        {
            Debug.LogWarning("Empty field.");
            errorTextField.SetText("Please enter your name");
        }
        else
        {
            currentPanel.SetActive(false);
            nextPanel.SetActive(true);
        }
    }
}
