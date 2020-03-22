using System;
using UnityEngine;

namespace Core.Interfaces
{
    public abstract class APlant : MonoBehaviour
    {
        public int EvolutionLevel;
        public string Name { get; set; }

        protected abstract int GetMaxEvolutionLevel();

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
            this.EvolutionLevel = evolutionLevel;
        }
    }
}