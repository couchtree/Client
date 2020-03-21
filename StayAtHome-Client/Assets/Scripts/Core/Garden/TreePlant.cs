using Core.Interfaces;

namespace Core.Garden
{
    public class TreePlant : APlant
    {
        public TreePlant(int evolutionLevel = 0) : base(evolutionLevel)
        {
        }

        protected override int GetMaxEvolutionLevel()
        {
            return 30;
        }

        public override string GetName()
        {
            return "Big Fat Tree! OMG YEAH!";
        }
    }
}