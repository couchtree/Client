using System.Collections.Generic;
using Core.DesignPattern;
using Core.Interfaces;
using UnityEngine;
using DataContainer;
using Managers;
using TMPro;


namespace Core.Garden
{
    public class MyGarden : MonoBehaviour
    {
        public List<APlant> plants;

        public GardenData gardenData;

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


        protected void Awake()
        {
            this.plants = new List<APlant>();
            SavegameManager.LoadGarden(out this.gardenData);
        }
    }
}