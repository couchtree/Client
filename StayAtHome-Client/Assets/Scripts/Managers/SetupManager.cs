using System;
using System.CodeDom;
using Core.Garden;
using Core.Interfaces;
using Core.Map;
using Core.Models;
using TMPro;
using UI;
using UnityEngine;

namespace Managers
{
    public class SetupManager : MonoBehaviour
    {
        [Header("Name Input Fields")] public TMP_InputField playerName;
        public TMP_InputField gardenName;
        public TMP_InputField treeName;

        [Header("Switchable Panels")] public GameObject panel1;
        public GameObject panel2;
        public GameObject panel3;
        public GameObject panel4;

        private void Awake()
        {
            var singleTonPlayer = Player.Instance;
            var singleTonMyGarden = MyGarden.Instance;
            var player = this.LoadPlayer();
            var garden = this.LoadGarden();
            if (player is null)
            {
                panel1.SetActive(true);
                panel2.SetActive(false);
                panel3.SetActive(false);
                panel4.SetActive(false);
                return;
            }
            else if (garden is null)
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
            SavegameManager.Save(player, player.GenerateSaveableData());
            this.panel1.SetActive(false);
            this.panel2.SetActive(true);
        }

        private IDataForSerialization LoadPlayer()
        {
            return SavegameManager.LoadPlayer();
        }

        private IDataForSerialization LoadGarden()
        {
            return SavegameManager.LoadGarden();
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
            SavegameManager.Save(garden, garden.GenerateSaveableData());
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
            SavegameManager.Save(garden, garden.GenerateSaveableData());
            this.panel3.SetActive(false);
            this.panel4.SetActive(true);
        }

        public void SaveHomeLocation()
        {
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