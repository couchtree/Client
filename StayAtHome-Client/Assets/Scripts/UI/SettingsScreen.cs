using System;
using Core.Map;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettingsScreen : MonoBehaviour
    {

        [Header("Settingobjects")] 
        public ToggleButton pushmessages;
        public ToggleButton gps;
        public Button saveHomeLocation;
        public Player player;
        public GPS_Tracking gpsTracking;

        private readonly long dayInMiliseconds = 1000 * 60 * 60 * 24; 
        
        public void TogglePushMessages()
        {
            
        }

        public void ToggleGPS()
        {
            
        }

        public void SetNewHomeLocation()
        {
            long date = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            long lastChange = PlayerPrefs.GetString("snh_loc_time") != "" ? Convert.ToInt64(PlayerPrefs.GetString("snh_loc_time")) : 0;
            
            if ((lastChange != null && lastChange != 0) && (date - lastChange) < dayInMiliseconds)
            {
                Debug.LogError("Das geht nicht..."); //TODO Error handling
                return;
            }

            PlayerPrefs.SetString("snh_loc_time", date.ToString());
            player.changeHomeBase(gpsTracking.GetLatitude(), gpsTracking.GetLongitude());
        }
        
    }
}