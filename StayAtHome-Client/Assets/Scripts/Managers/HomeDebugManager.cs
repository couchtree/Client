using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.Map;

namespace Managers
{
    public class HomeDebugManager : MonoBehaviour
    {
        public bool enableDebugging = false;
        public TextMeshProUGUI homeLat;
        public TextMeshProUGUI homeLon;
        public TextMeshProUGUI currentLat;
        public TextMeshProUGUI currentLon;
        public TextMeshProUGUI score;

        public Player player;
        public GPS_Tracking gps;

        private void Start()
        {
            if (!enableDebugging)
            {
                var thisGameObject = GetComponent<GameObject>();
                thisGameObject.SetActive(false);
            }
        }

        void Update()
        {
            if (enableDebugging)
            {
                homeLat.text = player.Lat.ToString();
                homeLon.text = player.Lon.ToString();
                currentLat.text = gps.GetLatitude().ToString();
                currentLon.text = gps.GetLongitude().ToString();
                score.text = player.Score.ToString();
            }
        }
    }
}