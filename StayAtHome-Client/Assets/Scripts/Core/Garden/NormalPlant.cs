using Core.Interfaces;

namespace Core.Garden
{
    public class NormalPlant : APlant
    {
        public NormalPlant(int evolutionLevel = 0) : base(evolutionLevel)
        {
        }

        protected override int GetMaxEvolutionLevel()
        {
            return 5;
        }
    }
}