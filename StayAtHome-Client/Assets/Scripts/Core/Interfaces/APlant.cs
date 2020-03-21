using System;
using UnityEngine;

namespace Core.Interfaces
{
    public abstract class APlant: MonoBehaviour
    {
        public int EvolutionLevel;

        protected abstract int GetMaxEvolutionLevel();
        public abstract String GetName();

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