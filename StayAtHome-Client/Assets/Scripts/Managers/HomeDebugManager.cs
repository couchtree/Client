using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.Map;

namespace Managers
{
    /// <summary>
    /// DebugManager for the HomeScreen
    /// 
    /// Is displays the home- and current position as well as the current score in the corresponding text-fields
    /// </summary>
    public class HomeDebugManager : MonoBehaviour
    {
        public TextMeshProUGUI homeLat;
        public TextMeshProUGUI homeLon;
        public TextMeshProUGUI currentLat;
        public TextMeshProUGUI currentLon;
        public TextMeshProUGUI score;

        public Player player;
        public GPS_Tracking gps;

        private void Start()
        {
        }

        void Update()
        {
            homeLat.text = player.Lat.ToString();
            homeLon.text = player.Lon.ToString();
            currentLat.text = gps.GetLatitude().ToString();
            currentLon.text = gps.GetLongitude().ToString();
            score.text = player.Score.ToString();
        }
    }
}