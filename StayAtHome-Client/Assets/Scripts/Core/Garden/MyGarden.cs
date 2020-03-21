using System;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Models;
using Managers;
using UnityEngine;

namespace Core.Garden
{
    public class MyGarden : MonoBehaviour, ISaveable
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

        void Start()
        {
            //just to test compiling
            SavegameManager.Save(this, this.GenerateSaveableData());
        }        
    }
}