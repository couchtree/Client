using System.Collections.Generic;
using Core.DesignPattern;
using Core.Interfaces;
using UnityEngine;
using TMPro;

namespace Core.Garden
{
    public class MyGarden : Singleton<MyGarden>
    {
        public List<APlant> plants;
        
        public GameObject tree;

        public TextMeshProUGUI treeNameField;

        public TextMeshProUGUI gardenName;

        public string Name { get; set; }

        // Move these to wherever you see fit..
        public int Health { get; private set; } = 100;
        public int MaxHealth { get; private set; } = 100;

        public int Water { get; private set; } = 50;
        public int MaxWater { get; private set; } = 100;

        public int Rank { get; private set; } = 0;
        public int MaxRank { get; private set; } = 10;

        public int Dung { get; private set; } = 0;
        public int MaxDung { get; private set; } = 10;

        public int Disease { get; private set; } = 0;
        public int MaxDisease { get; private set; } = 10;


        private protected override void Awake()
        {
            base.Awake();

            this.plants = new List<APlant>();
            this.tree = new GameObject("tree");
            this.tree.transform.parent = this.transform;
            this.tree.AddComponent<TreePlant>();
            LoadGarden();
        }

        protected void LoadGarden()
        {
            if (PlayerPrefs.HasKey("garden.name"))
            {
                this.Name = PlayerPrefs.GetString("garden.name");
                this.gardenName.text = "Garden " + this.Name;
            }

            if (PlayerPrefs.HasKey("tree.name") && PlayerPrefs.HasKey("tree.evolution"))
            {
                TreePlant treePlant = this.tree.GetComponent<TreePlant>();
                treePlant.Name = PlayerPrefs.GetString("tree.name");
                treePlant.EvolutionLevel = PlayerPrefs.GetInt("tree.evolution");
                this.treeNameField.text = PlayerPrefs.GetString("tree.name");
            }
        }

        public MyGarden()
        {
        }
    }
}