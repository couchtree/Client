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
        private PlayerInterface playerObject;

        public string getFilename()
        {
            return "player";
        }

        public PlayerData(PlayerInterface player)
        {
            this.playerName = player.Name;
            this.lat = player.lat;
            this.lon = player.lon;
            this.playerObject = player;
        }

        public void loadFromData()
        {
            this.playerObject.Name = this.playerName;
            this.playerObject.lat = this.lat;
            this.playerObject.lon = this.lon;
        }
    }
}