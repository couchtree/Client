using System;
using Interfaces;

namespace Models
{
    [Serializable]
    public class PlayerData : DataForSerialization
    {
        public String playerName;
        public long lat;
        public long lon;

        public string getFilename()
        {
            return "player";
        }

        public PlayerData(PlayerInterface player)
        {
            this.playerName = player.Name;
            this.lat = player.lat;
            this.lon = player.lon;
        }
    }
}