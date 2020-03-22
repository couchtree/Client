using Core.Garden;
using Core.Map;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class SetupManager : MonoBehaviour
    {
        [Header("Debugging stuff")] 
        public bool activateDebugging;
        public TextMeshProUGUI debuggingWifi;
        public TextMeshProUGUI debuggingGps;

        [Header("Name Input Fields")]
        public TMP_InputField playerName;
        public TMP_InputField gardenName;
        public TMP_InputField treeName;

        [Header("GPS Stuff")]
        public GameObject gpsButton;
        public GameObject gpsDeactivatedInfo;
        
        [Header("Error Handling")]
        public GameObject errorPanel;
        public TextMeshProUGUI errorText;

        [Header("Switchable Panels")]
        public GameObject panel1;
        public GameObject panel2;
        public GameObject panel3;
        public GameObject panel4;

        private void Awake()
        {
            if (!GPS_Tracking.isGpsEnabled())
            {
                Debug.Log("GPS NOT ENABLED!!!!!!!!");
                gpsButton.SetActive(false);
                gpsDeactivatedInfo.SetActive(true);
            }
            this.errorPanel.SetActive(false);
            if (activateDebugging)
            {
                PlayerPrefs.DeleteAll();
                this.debuggingGps.gameObject.SetActive(true);
                this.debuggingWifi.gameObject.SetActive(true);
            }
            if (!PlayerPrefs.HasKey("player.name") || PlayerPrefs.GetString("player.name") == "")
            {
                panel1.SetActive(true);
                panel2.SetActive(false);
                panel3.SetActive(false);
                panel4.SetActive(false);
                return;
            }
            else if (!PlayerPrefs.HasKey("garden.name") || PlayerPrefs.GetString("garden.name") == "")
            {
                panel1.SetActive(false);
                panel2.SetActive(true);
                panel3.SetActive(false);
                panel4.SetActive(false);
                return;
            }

            panel1.SetActive(false);
            panel2.SetActive(false);
            panel3.SetActive(false);
            panel4.SetActive(false);
            this.SetupCompleted();
        }

        public void SavePlayerName()
        {
            var player = GetComponent<Player>();
            if (this.playerName.text.Equals(""))
            {
                this.ShowError("Du musst einen Spielernamen auswählen!");
                Debug.LogError("No playername given");
                return;
            }

            this.hideError();

            player.Name = this.playerName.text;
            SavegameManager.SavePlayer(player);
            this.panel1.SetActive(false);
            this.panel2.SetActive(true);
        }

        public void SaveGardenName()
        {
            MyGarden garden = GetComponent<MyGarden>();
            if (this.gardenName.text.Equals(""))
            {
                this.ShowError("Du musst einen Namen für den Garten auswählen!");
                Debug.LogError("No gardenname given");
                return;
            }

            this.hideError();

            garden.Name = this.gardenName.text;
            SavegameManager.SaveGarden(garden);
            this.panel2.SetActive(false);
            this.panel3.SetActive(true);
        }

        public void SaveTreeName()
        {
            MyGarden garden = GetComponent<MyGarden>();
            if (this.treeName.text.Equals(""))
            {
                this.ShowError("Du musst einen Namen für den ersten Setzling auswählen!");
                Debug.LogError("No treenname given");
                return;
            }

            this.hideError();

            garden.tree.GetComponent<TreePlant>().Name = this.treeName.text;
            SavegameManager.SaveTree(garden.tree.GetComponent<TreePlant>());
            this.panel3.SetActive(false);
            this.panel4.SetActive(true);
        }

        public void SaveHomeLocation()
        {
            this.hideError();
            this.panel4.SetActive(false);
            SetupCompleted();
        }

        private void SetupCompleted()
        {
            SceneLoading sceneLoading = GetComponent<SceneLoading>();
            sceneLoading.LoadScene(3);
        }

        public void setHomeGPSPosition()
        {
            var gps = gameObject.GetComponent<GPS_Tracking>();
            var player = gameObject.GetComponent<Player>();
            Debug.Log("gps setzen");
            Debug.Log(gps.GetLatitude());
            Debug.Log(gps.GetLongitude());
            player.lat = gps.GetLatitude();
            player.lon = gps.GetLongitude();
            SaveHomeLocation();
        }

        private void hideError()
        {
            this.errorPanel.SetActive(false);
        }

        private void ShowError(string errorText)
        {
            this.errorText.text = errorText;
            this.errorPanel.SetActive(true);
        }
    }
}