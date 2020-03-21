using System;
using Interfaces;

namespace Models
{
    [Serializable]
    public class PlayerData : Saveable
    {
        protected new String SavegameName = "player";
        public String playerName;
        public long lat;
        public long lon;

        public PlayerData(PlayerInterface player)
        {
            this.playerName = player.Name;
            this.lat = player.lat;
            this.lon = player.lon;
        }
    }
}