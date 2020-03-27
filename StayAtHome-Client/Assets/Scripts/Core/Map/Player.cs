using UnityEngine;
using DataContainer;
using Managers;
using Core.DesignPattern;

namespace Core.Map
{
    public class Player : Singleton<Player>
    {
        [HideInInspector]
        public float distance; // max distance from home base until current position is no longer treated as beeing at home

        public string Name
        {
            get {return data.name;}
            set {data.name = value;}
        }
        public float Lat
        {
            get {return data.lat;}
            set {data.lat = value;}
        }
        public float Lon
        {
            get {return data.lon;}
            set {data.lon = value;}
        }
        public int Score
        {
            get {return data.score;}
            set {data.score = value;}
        }

        private PlayerData data;

        private protected override void Awake()
        {
            base.Awake();
            this.LoadPlayer();
        }

        private void Update()
        {
        }

        public void ChangeScore(int amount)
        {
            Score += amount;
        }

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

        public void LoadPlayer()
        {
            SavegameManager.LoadPlayer(out this.data);
            return;
        }
    }
}