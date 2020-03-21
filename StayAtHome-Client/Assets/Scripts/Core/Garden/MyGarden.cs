using System;
using Boo.Lang;
using Core.Interfaces;
using Core.Models;
using UnityEngine;

namespace Core.Garden
{
    public class MyGarden : ISaveable
    {
        public const String filename = "player";
        public List<APlant> plants;
        public TreePlant tree;

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

        public MyGarden()
        {
            this.plants = new List<APlant>();
            this.plants.Add(new NormalPlant());
            this.tree = new TreePlant();
        }

        public IDataForSerialization GenerateSaveableData()
        {
            return new GardenData(this);
        }
    }
}