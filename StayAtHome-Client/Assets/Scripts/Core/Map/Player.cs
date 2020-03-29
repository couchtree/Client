using UnityEngine;
using DataContainer;
using Managers;
using Core.DesignPattern;

namespace Core.Map
{
    /// <summary>
    /// Singleton to manage all the player actions and behaviours
    ///
    /// Stores its data in the PlayerData-struct.
    /// The public variables implement an auto-save
    /// </summary>
    public class Player : Singleton<Player>
    {
        [HideInInspector]
        public float distance; // max distance from home base until current position is no longer treated as beeing at home

        public string Name
        {
            get {return data.name;}
            set
            {
                data.name = value;
                SavePlayer();
            }
        }
        public float Lat
        {
            get {return data.lat;}
            set
            {
                data.lat = value;
                SavePlayer();
            }
        }
        public float Lon
        {
            get {return data.lon;}
            set
            {
                data.lon = value;
                SavePlayer();
            }
        }
        public int Score
        {
            get {return data.score;}
            set
            {
                data.score = value;
                SavePlayer();
            }
        }

        private PlayerData data;

        private protected override void Awake()
        {
            base.Awake();
            this.LoadPlayer();
        }

        /// <summary>
        /// Change the score of the player by the given amount.
        /// Note: The score has a lower bound of zero.
        /// </summary>
        /// <param name="amount"></param>
        public void ChangeScore(int amount)
        {
            // Ensure that the player score can not fall below zero
            if (Score + amount < 0)
            {
                Score = 0;
            }
            else
            {
                Score += amount;   
            }
        }

        /// <summary>
        /// Check if the player is currently at this home base location
        /// </summary>
        /// <param name="lat">current lateral coordinate</param>
        /// <param name="lon">current longitudal coordinate</param>
        /// <returns>True if the player is at his home location, false otherwise</returns>
        public bool AtHomeBase(float lat, float lon)
        {
            Vector2 homePos = new Vector2(this.Lat, this.Lon);
            Vector2 curPos = new Vector2(lat, lon);
            float currentDistance = Vector2.Distance(homePos, curPos);
            if (currentDistance < distance)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Change the player's home base
        /// </summary>
        /// <param name="lat">current lateral coordinate</param>
        /// <param name="lon">current longitudal coordinate</param>
        public void changeHomeBase(float lat, float lon)
        {
            this.Lat = lat;
            this.Lon = lon;
            
            this.SavePlayer();
        }

        private void LoadPlayer()
        {
            SavegameManager.LoadPlayer(out this.data);
            return;
        }

        private void SavePlayer()
        {
            SavegameManager.SavePlayer(this.data);
        }
    }
}