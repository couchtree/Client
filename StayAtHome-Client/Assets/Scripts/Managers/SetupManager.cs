﻿using Core.Garden;
using Core.Map;
using TMPro;
using UI;
using UnityEngine;

namespace Managers
{
    public class SetupManager : MonoBehaviour
    {
        [Header("Name Input Fields")]
        public TMP_InputField playerName;
        public TMP_InputField gardenName;
        public TMP_InputField treeName;

        [Header("Switchable Panels")]
        public GameObject panel1;
        public GameObject panel2;
        public GameObject panel3;
        public GameObject panel4;

        private void Awake()
        {
            PlayerPrefs.DeleteAll();
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
                Debug.LogError("No playername given");
                return;
            }

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
                Debug.LogError("No gardenname given");
                return;
            }

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
                Debug.LogError("No treenname given");
                return;
            }

            garden.tree.GetComponent<TreePlant>().Name = this.treeName.text;
            SavegameManager.SaveTree(garden.tree.GetComponent<TreePlant>());
            this.panel3.SetActive(false);
            this.panel4.SetActive(true);
        }

        public void SaveHomeLocation()
        {
            //Todo GPS saving
            this.panel4.SetActive(false);
            SetupCompleted();
        }

        private void SetupCompleted()
        {
            SceneLoading sceneLoading = GetComponent<SceneLoading>();
            sceneLoading.LoadScene(2);
        }
    }
}