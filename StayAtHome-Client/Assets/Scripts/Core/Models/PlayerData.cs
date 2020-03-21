using System;
using Core.Map;
using Core.Interfaces;

namespace Core.Models
{
    [Serializable]
    public class PlayerData : DataForSerialization
    {
        public String playerName;
        public long lat;
        public long lon;
        
        [NonSerialized]
        private Player playerObject;

        public string getFilename()
        {
            return Player.filename;
        }

        public PlayerData(Player player)
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