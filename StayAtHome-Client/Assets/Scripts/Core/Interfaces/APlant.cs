using System;
using UnityEngine;
using DataContainer;

namespace Core.Interfaces
{
    /// <summary>
    /// An abstract class for all plants in this game.
    /// 
    /// Stores its data in the PlantData-struct.
    /// The public variables implement an auto-save
    /// </summary>
    public abstract class APlant : MonoBehaviour
    {
        public int EvolutionLevel
        {
            get {return data.evolutionLevel;}
            set
            {
                data.evolutionLevel = value;
                Save();
            }
        }

        public string Name
        {
            get {return data.name;}
            set
            {
                data.name = value;
                Save();
            }
        }

        protected PlantData data; // Data of this plant

        protected abstract int GetMaxEvolutionLevel();

        public abstract void Load();
        public abstract void Save();

        public bool IsMaxLvl()
        {
            return this.GetMaxEvolutionLevel() == this.EvolutionLevel;
        }

        public void IncreaseEvolution()
        {
            this.EvolutionLevel++;
        }

        protected APlant(int evolutionLevel = 0)
        {
            data = new PlantData();
            this.EvolutionLevel = evolutionLevel;
        }
    }
}