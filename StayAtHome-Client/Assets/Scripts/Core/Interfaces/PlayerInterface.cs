namespace Core.Interfaces
{
    public interface PlayerInterface
    {
        string Name { get; set; }
        long lat { get; set; }
        long lon { get; set; }
    }
}