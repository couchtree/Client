using Core.Interfaces;
using Core.Models;

namespace Core.Garden
{
    public class Plant: ISaveable, IPlant
    {
        public IDataForSerialization GenerateSaveableData()
        {
            return new PlantData(this);
        }

        public int GetEvolutionLevel()
        {
            throw new System.NotImplementedException();
        }

        public int GetMaxEvolutionLevel()
        {
            throw new System.NotImplementedException();
        }

        public string GetName()
        {
            throw new System.NotImplementedException();
        }

        public bool IsMaxLvl()
        {
            throw new System.NotImplementedException();
        }
    }
}