using System;

namespace Core.Interfaces
{
    public interface DataForSerialization
    {
        String getFilename();

        void loadFromData();
    }
}