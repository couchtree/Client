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
        new public string name;

        [HideInInspector]
        public float distance; // max distance from home base until current position is no longer treated as beeing at home

        public string Name { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public int score { get; set; }

        private void Update()
        {
        }

        public void ChangeScore(int amount)
        {
            score += amount;
        }

        public bool AtHomeBase(float lat, float lon)
        {
            Vector2 homePos = new Vector2(this.lat, this.lon);
            Vector2 curPos = new Vector2(lat, lon);
            float currentDistance = Vector2.Distance(homePos, curPos);
            if (currentDistance < distance)
            {
                return true;
            }
            return false;
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