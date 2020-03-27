namespace DataContainer
{
    /// <summary>
    /// Struct to store all plant related data.
    /// It acts as a container for save and load operations w/o the need to instantiate the whole derived APlant-class
    /// </summary>
    public struct PlantData
    {
        public string name; // name of the plant
        public int evolutionLevel; // evoluation level of the plant
    }
}