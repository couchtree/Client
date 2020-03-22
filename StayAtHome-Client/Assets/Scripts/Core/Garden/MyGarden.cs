using System.Collections.Generic;
using Core.DesignPattern;
using Core.Interfaces;
using UnityEngine;

namespace Core.Garden
{
    public class MyGarden : Singleton<MyGarden>
    {
        public List<APlant> plants;
        public GameObject tree;

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
            this.tree.AddComponent<TreePlant>();
        }

        protected void LoadGarden()
        {
            if (!PlayerPrefs.HasKey("garden.name") && !PlayerPrefs.HasKey("tree.name"))
            {
                return;
            }

            this.Name = PlayerPrefs.GetString("garden.name");
            this.GetComponent<TreePlant>().Name = PlayerPrefs.GetString("tree.name");
        }

        public MyGarden()
        {
        }
    }
}