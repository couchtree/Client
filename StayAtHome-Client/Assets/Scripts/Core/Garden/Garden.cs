using System;
using Core.Interfaces;
using Core.Models;

namespace Core.Garden
{
    public class Garden : ISaveable
    {
        public const String filename = "player";
        
        public IDataForSerialization GenerateSaveableData()
        {
            return new GardenData(this);
        }
    }
}