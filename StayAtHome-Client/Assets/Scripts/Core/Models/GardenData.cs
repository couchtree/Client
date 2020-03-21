using Core.Interfaces;

namespace Core.Models
{
    public class GardenData : DataForSerialization
    {
        public string getFilename()
        {
            return "garden";
        }

        public void loadFromData()
        {
            throw new System.NotImplementedException();
        }
    }
}