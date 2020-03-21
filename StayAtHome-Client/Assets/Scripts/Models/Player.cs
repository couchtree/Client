using System;
using Interfaces;
using Managers;
using UnityEngine;

namespace Models
{
    public class Player : MonoBehaviour, Saveable, PlayerInterface
    {
        public const String filename = "player";

        public string Name { get; set; }
        public long lat { get; set; }
        public long lon { get; set; }

        public DataForSerialization GenerateSaveableData()
        {
            return new PlayerData(this);
        }
        
        // Start is called before the first frame update
        void Start()
        {
            //just to test compiling
            SavegameManager.Save(this,this.GenerateSaveableData());
        }        
    }
}