using System.Runtime.Serialization;

namespace Interfaces
{
    public abstract class Saveable
    {
        public abstract ISerializable GenerateSaveableData();

        public abstract void LoadFromSerializedData(DataForSerialization dataForSerialization);
    }
}