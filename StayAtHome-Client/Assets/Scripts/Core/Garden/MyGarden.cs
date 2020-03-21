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