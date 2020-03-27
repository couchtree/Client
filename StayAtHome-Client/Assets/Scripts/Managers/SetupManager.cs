using Core.Garden;
using Core.Map;
using DataContainer;
using TMPro;
using UI;
using UnityEngine;

namespace Managers
{
    public class SetupManager : MonoBehaviour
    {
        [Header("Debugging stuff")] 
        public bool activateDebugging;

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
        public GameObject namePanel;
        public GameObject gardenPanel;
        public GameObject treePanel;
        public GameObject homebasePanel;

        private PlayerData player;

        private void Awake()
        {
            player = new PlayerData();

            this.errorPanel.SetActive(false);
            if (activateDebugging)
            {
                PlayerPrefs.DeleteAll();
            }
            if (!PlayerPrefs.HasKey("player.name") || PlayerPrefs.GetString("player.name") == "")
            {
                namePanel.SetActive(true);
                gardenPanel.SetActive(false);
                treePanel.SetActive(false);
                homebasePanel.SetActive(false);
                return;
            }
            else if (!PlayerPrefs.HasKey("garden.name") || PlayerPrefs.GetString("garden.name") == "")
            {
                namePanel.SetActive(false);
                gardenPanel.SetActive(true);
                treePanel.SetActive(false);
                homebasePanel.SetActive(false);
                return;
            }

            namePanel.SetActive(false);
            gardenPanel.SetActive(false);
            treePanel.SetActive(false);
            homebasePanel.SetActive(false);
            this.SetupCompleted();
        }

        private void Update()
        {
            if (GPS_Tracking.isGpsEnabled())
            {
                gpsButton.SetActive(true);
                gpsDeactivatedInfo.SetActive(false);
                return;
            }

            Debug.Log("GPS NOT ENABLED!!!!!!!!");
            gpsButton.SetActive(false);
            gpsDeactivatedInfo.SetActive(true);
        }

        public void SavePlayerName()
        {
            if (this.playerName.text.Equals(""))
            {
                this.ShowError("Du musst einen Spielernamen auswählen!");
                Debug.LogError("No playername given");
                return;
            }

            this.hideError();

            player.name = this.playerName.text;
            SavegameManager.SavePlayer(player);
            this.namePanel.SetActive(false);
            this.gardenPanel.SetActive(true);
        }

        public void SaveGardenName()
        {
            GardenData garden = new GardenData();
            if (this.gardenName.text.Equals(""))
            {
                this.ShowError("Du musst einen Namen für den Garten auswählen!");
                Debug.LogError("No gardenname given");
                return;
            }

            this.hideError();

            garden.name = this.gardenName.text;
            SavegameManager.SaveGarden(garden);
            this.gardenPanel.SetActive(false);
            this.treePanel.SetActive(true);
        }

        public void SaveTreeName()
        {
            PlantData tree = new PlantData();
            if (this.treeName.text.Equals(""))
            {
                this.ShowError("Du musst einen Namen für den ersten Setzling auswählen!");
                Debug.LogError("No treenname given");
                return;
            }

            this.hideError();

            tree.name = this.treeName.text;
            tree.evolutionLevel = 0;
            SavegameManager.SaveTree(tree);
            this.treePanel.SetActive(false);
            this.homebasePanel.SetActive(true);
        }

        private void SetupCompleted()
        {
            SceneLoading sceneLoading = GetComponent<SceneLoading>();
            sceneLoading.LoadScene(3);
        }

        public void proceedFromLocationPanel()
        {
            this.hideError();
            this.homebasePanel.SetActive(false);
            SetupCompleted();
        }

        public void SaveHomeLocation()
        {
            if (Application.internetReachability != NetworkReachability.ReachableViaLocalAreaNetwork)
            {
                this.ShowError("Du bist mit keinem WLAN verbunden. Bist du wirklich zuhause du Lümmel?");
                return;
            }
            
            var gps = gameObject.GetComponent<GPS_Tracking>();
            Debug.Log("gps setzen");
            Debug.Log(gps.GetLatitude());
            Debug.Log(gps.GetLongitude());
            
            player.lat = gps.GetLatitude();
            player.lon = gps.GetLongitude();
            SavegameManager.SavePlayer(player);

            proceedFromLocationPanel();
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