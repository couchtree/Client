using System;
using System.Collections.Generic;
using Core.Garden;
using Core.Interfaces;

namespace Core.Models
{
    [Serializable]
    public class GardenData : IDataForSerialization
    {
        public List<int> plantEvolutions;
        public int treeEvolution;
        public string treeName;
        public string gardenName;

        public GardenData(MyGarden myGarden)
        {
            this.plantEvolutions = new List<int>();
            foreach (var plant in myGarden.plants)
            {
                this.plantEvolutions.Add(plant.EvolutionLevel);
            }

            this.treeEvolution = myGarden.tree.GetComponent<TreePlant>().EvolutionLevel;
            this.gardenName = myGarden.Name;
            this.treeName = myGarden.tree.GetComponent<TreePlant>().Name;
        }

        public string getFilename()
        {
            return "garden";
        }

        public void loadFromData()
        {
            var singleTon = MyGarden.Instance;
            singleTon.Name = this.gardenName;
            singleTon.tree.GetComponent<TreePlant>().Name = this.treeName;

//            this._myGarden.plants = new List<APlant>();
//            foreach (int plantEvolution in this.plantEvolutions)
            //          {
            //this._myGarden.plants.Add(new NormalPlant(plantEvolution));
            //}
        }
    }
}