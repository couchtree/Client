using Core.Interfaces;
using Managers;

namespace Core.Garden
{
    /// <summary>
    /// Normal plant which should be grown in the garden
    /// </summary>
    public class NormalPlant : APlant
    {
        private static int plantCount = 0;
        private int thisPlantIdentifier;
        public NormalPlant(int evolutionLevel = 0) : base(evolutionLevel)
        {
            thisPlantIdentifier = plantCount;
            plantCount++;
        }

        protected override int GetMaxEvolutionLevel()
        {
            return 5;
        }

        /// <summary>
        /// Load a this normal plant object
        /// </summary>
        public override void Load()
        {
            SavegameManager.SaveNormalPlant(this.data, this.thisPlantIdentifier.ToString());
        }

        /// <summary>
        /// Store this normal plant object
        /// </summary>
        public override void Save()
        {
            SavegameManager.LoadNormalPlant(out this.data, this.thisPlantIdentifier.ToString());
        }

    }
}