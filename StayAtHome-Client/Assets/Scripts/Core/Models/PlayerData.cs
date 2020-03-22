using System;
using Core.Map;
using Core.Interfaces;

namespace Core.Models
{
    [Serializable]
    public class PlayerData : IDataForSerialization
    {
        public string playerName;
        public float lat;
        public float lon;

        public string getFilename()
        {
            return Player.filename;
        }

        public PlayerData(Player player)
        {
            this.playerName = player.Name;
            this.lat = player.lat;
            this.lon = player.lon;
        }

        public void loadFromData()
        {
            var singleTon = Player.Instance;
            singleTon.Name = this.playerName;
            singleTon.lat = this.lat;
            singleTon.lon = this.lon;
        }
    }
}