using Core.Interfaces;
using Managers;

namespace Core.Garden
{
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

        public override void Load()
        {
            SavegameManager.SaveNormalPlant(this.data, this.thisPlantIdentifier.ToString());
        }

        public override void Save()
        {
            SavegameManager.LoadNormalPlant(out this.data, this.thisPlantIdentifier.ToString());
        }

    }
}