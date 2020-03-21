using System;
using Interfaces;

namespace Models
{
    public class Player : Saveable, PlayerInterface
    {
        public const String filename = "player";

        public string Name { get; set; }
        public long lat { get; set; }
        public long lon { get; set; }

        public override DataForSerialization GenerateSaveableData()
        {
            return new PlayerData(this);
        }
    }
}