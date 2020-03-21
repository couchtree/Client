using System;
using Core.Interfaces;
using Core.Models;

namespace Core.Garden
{
    public class Garden : Saveable
    {
        public const String filename = "player";

        public DataForSerialization GenerateSaveableData()
        {
            return new GardenData(this);
        }
    }
}