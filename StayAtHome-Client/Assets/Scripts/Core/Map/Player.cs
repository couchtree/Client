using UnityEngine;
using Core.DesignPattern;

namespace Core.Map
{
    public class Player : Singleton<Player>
    {
        [HideInInspector] new public string name;

        [HideInInspector] public float
            distance; // max distance from home base until current position is no longer treated as beeing at home

        public string Name { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public float workLat { get; set; }
        public float WorkLon { get; set; }
        public int score { get; set; }

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

        public void LoadPlayer()
        {
            if (!PlayerPrefs.HasKey("player.name"))
            {
                return;
            }

            if (PlayerPrefs.HasKey("player.lat") && PlayerPrefs.HasKey("player.lon"))
            {
                this.lat = PlayerPrefs.GetFloat("player.lat");
                this.lon = PlayerPrefs.GetFloat("player.lon");
            }

            this.Name = PlayerPrefs.GetString("player.name");
            this.score = PlayerPrefs.GetInt("player.score", 0);
            return;
        }
    }
}