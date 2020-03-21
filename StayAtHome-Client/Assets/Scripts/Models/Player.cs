using System;
using System.Runtime.Serialization;
using Interfaces;

namespace Models
{
    public class Player: Saveable, PlayerInterface
    {
        public const String filename = "player"; 
        
        public string Name { get; set; }
        public long lat { get; set; }
        public long lon { get; set; }
        
        public override ISerializable GenerateSaveableData()
        {
            throw new System.NotImplementedException();
        }

        public override void LoadFromSerializedData(DataForSerialization dataForSerialization)
        {
            throw new System.NotImplementedException();
        }
    }
}