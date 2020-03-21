using System;
using Interfaces;
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
    }
}