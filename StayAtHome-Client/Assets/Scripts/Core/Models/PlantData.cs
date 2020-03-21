using Core.Garden;
using Core.Interfaces;

namespace Core.Models
{
    public class PlantData : IDataForSerialization
    {
        public PlantData(Plant plant)
        {
        }

        public string getFilename()
        {
            return "plant";
        }

        public void loadFromData()
        {
            throw new System.NotImplementedException();
        }
    }
}