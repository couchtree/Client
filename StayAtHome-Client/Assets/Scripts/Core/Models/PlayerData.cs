using System;
using Core.Map;
using Core.Interfaces;

namespace Core.Models
{
    [Serializable]
    public class PlayerData : IDataForSerialization
    {
        public String playerName;
        public long lat;
        public long lon;

        [NonSerialized] private Player _playerObject;

        public string getFilename()
        {
            return Player.filename;
        }

        public PlayerData(Player player)
        {
            this.playerName = player.Name;
            this.lat = player.lat;
            this.lon = player.lon;
            this._playerObject = player;
        }

        public void loadFromData()
        {
            this._playerObject.Name = this.playerName;
            this._playerObject.lat = this.lat;
            this._playerObject.lon = this.lon;
        }
    }
}