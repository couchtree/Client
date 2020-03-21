namespace Core.Interfaces
{
    public interface Saveable
    {
        DataForSerialization GenerateSaveableData();
    }
}