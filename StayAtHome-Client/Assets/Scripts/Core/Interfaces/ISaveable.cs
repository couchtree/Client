namespace Core.Interfaces
{
    public interface ISaveable
    {
        IDataForSerialization GenerateSaveableData();
    }
}