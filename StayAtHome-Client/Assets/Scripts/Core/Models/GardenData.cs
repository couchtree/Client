using Core.Garden;
using Core.Interfaces;

namespace Core.Models
{
    public class GardenData : IDataForSerialization
    {
        public string getFilename()
        {
            return "garden";
        }

        public void loadFromData()
        {
            throw new System.NotImplementedException();
        }

        public GardenData(MyGarden myGarden)
        {
        }
    }
}