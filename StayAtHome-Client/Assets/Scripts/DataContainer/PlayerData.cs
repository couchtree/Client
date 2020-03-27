namespace DataContainer
{
    /// <summary>
    /// Struct to store all player related data.
    /// It acts as a container for save and load operations w/o the need to instantiate the whole Player class
    /// </summary>
    public struct PlayerData
    {
        public float lat; // home base lateral coordinate
        public float lon; // home base longitude coordinate
        public string name; // player name
        public int score; // score of the player
    }
}