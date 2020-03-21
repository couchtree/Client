using System;
using Boo.Lang;
using Core.Garden;
using Core.Interfaces;

namespace Core.Models
{
    [Serializable]
    public class GardenData : IDataForSerialization
    {
        public List<int> plantEvolutions;
        public int treeEvolution;
        [NonSerialized] private MyGarden _myGarden;

        public string getFilename()
        {
            return "garden";
        }

        public void loadFromData()
        {
            this._myGarden.tree = new TreePlant(this.treeEvolution);
            this._myGarden.plants = new List<APlant>();
            foreach (int plantEvolution in this.plantEvolutions)
            {
                this._myGarden.plants.Add(new NormalPlant(plantEvolution));
            }
        }

        public GardenData(MyGarden myGarden)
        {
            foreach (var plant in myGarden.plants)
            {
                this.plantEvolutions.Add(plant.EvolutionLevel);
            }

            this.treeEvolution = myGarden.tree.EvolutionLevel;
            this._myGarden = myGarden;
        }
    }
}