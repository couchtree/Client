using System;
using Core.Interfaces;
using Managers;
using Core.Models;
using UnityEngine;

namespace Core.Map
{
    public class Player : MonoBehaviour, ISaveable
    {
        public const String filename = "player";

        [HideInInspector]
        public string name;

        [HideInInspector]
        public float distance;

        public string Name { get; set; }
        public long lat { get; set; }
        public long lon { get; set; }
        public int score { get; set; }

        private void Update()
        {
        }

        public void ChangeScore(int amount)
        {
            score += amount;
        }

        public IDataForSerialization GenerateSaveableData()
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