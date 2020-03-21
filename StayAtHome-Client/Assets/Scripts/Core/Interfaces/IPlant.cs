using System;

namespace Core.Interfaces
{
    public interface IPlant
    {
        int GetEvolutionLevel();
        int GetMaxEvolutionLevel();
        String GetName();
        bool IsMaxLvl();
    }
}