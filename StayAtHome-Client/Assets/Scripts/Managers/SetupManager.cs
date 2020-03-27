using Core.Garden;
using Core.Map;
using DataContainer;
using TMPro;
using UI;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Manager class to setup a new player
    /// </summary>
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

        private PlayerData player;  // setup data of the player

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

        /// <summary>
        /// Tries to save the player name.
        /// If playerName was entered by the user - i.e. name field is not empty - the name is saved and the screen moves on to the next input field.
        /// Otherwise an error is displayed.
        /// </summary>
        public void SavePlayerName()
        {
            if (this.playerName.text.Equals(""))
            {
                this.showError("Du musst einen Spielernamen auswählen!");
                Debug.LogError("No playername given");
                return;
            }

            this.hideError();

            player.name = this.playerName.text;
            SavegameManager.SavePlayer(player);
            this.namePanel.SetActive(false);
            this.gardenPanel.SetActive(true);
        }

        /// <summary>
        /// Tries to save the garden name.
        /// If gardenname was entered by the user - i.e. name field is not emtpy - the name is saved and the screen moves on to the next input field.
        /// Otherwise an error is displayed
        /// </summary>
        public void SaveGardenName()
        {
            GardenData garden = new GardenData();
            if (this.gardenName.text.Equals(""))
            {
                this.showError("Du musst einen Namen für den Garten auswählen!");
                Debug.LogError("No gardenname given");
                return;
            }

            this.hideError();

            garden.name = this.gardenName.text;
            SavegameManager.SaveGarden(garden);
            this.gardenPanel.SetActive(false);
            this.treePanel.SetActive(true);
        }

        /// <summary>
        /// Tries to save the tree name.
        /// If tree name was entered by the user - i.e. name field is not emtpy - the name is saved and the screen moves on to the next input field.
        /// Otherwise an error is displayed
        /// </summary>
        public void SaveTreeName()
        {
            PlantData tree = new PlantData();
            if (this.treeName.text.Equals(""))
            {
                this.showError("Du musst einen Namen für den ersten Setzling auswählen!");
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

        /// <summary>
        /// Skipps the setting of a home base.
        /// </summary>
        public void proceedFromLocationPanel()
        {
            this.hideError();
            this.homebasePanel.SetActive(false);
            SetupCompleted();
        }

        /// <summary>
        /// Tries to save the home location.
        /// First checks if the user is connected to a WLAN. If not an error is displayed.
        /// If WLAN connection is confirmed the current GPS location is stored as the home location
        /// </summary>
        public void SaveHomeLocation()
        {
            if (Application.internetReachability != NetworkReachability.ReachableViaLocalAreaNetwork)
            {
                this.showError("Du bist mit keinem WLAN verbunden. Bist du wirklich zuhause du Lümmel?");
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

        private void showError(string errorText)
        {
            this.errorText.text = errorText;
            this.errorPanel.SetActive(true);
        }
    }
}