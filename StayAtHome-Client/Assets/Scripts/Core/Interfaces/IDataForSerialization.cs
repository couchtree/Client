using System;

namespace Core.Interfaces
{
    public interface IDataForSerialization
    {
        String getFilename();

        void loadFromData();
    }
}