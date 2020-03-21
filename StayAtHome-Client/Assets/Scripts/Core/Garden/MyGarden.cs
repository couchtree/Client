using System;
using Boo.Lang;
using Core.Interfaces;
using Core.Models;

namespace Core.Garden
{
    public class MyGarden : ISaveable
    {
        private List<Plant> _plants;

        public MyGarden()
        {
            _plants = new List<Plant>();
        }

        public const String filename = "player";

        public IDataForSerialization GenerateSaveableData()
        {
            return new GardenData(this);
        }
    }
}