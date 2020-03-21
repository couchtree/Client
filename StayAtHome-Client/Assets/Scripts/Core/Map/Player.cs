﻿using System;
using Core.Interfaces;
using Managers;
using Core.Models;
using UnityEngine;

namespace Core.Map
{
    public class Player : MonoBehaviour, Saveable
    {
        public const String filename = "player";
        
        [HideInInspector] 
        public string name;
        
        [HideInInspector] 
        public float distance;

        public string Name { get; set; }
        public long lat { get; set; }
        public long lon { get; set; }

        private void Update()
        {
        }

        public DataForSerialization GenerateSaveableData()
        {
            return new PlayerData(this);
        }

        void Start()
        {
            //just to test compiling
            SavegameManager.Save(this, this.GenerateSaveableData());
        }
    }
}