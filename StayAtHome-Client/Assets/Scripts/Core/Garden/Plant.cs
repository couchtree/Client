using Core.Interfaces;

namespace Core.Garden
{
    public class Plant: ISaveable, IPlant
    {
        public IDataForSerialization GenerateSaveableData()
        {
            throw new System.NotImplementedException();
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