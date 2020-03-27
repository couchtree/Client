using UnityEngine;
using DataContainer;

namespace Managers
{
    /// <summary>
    /// Static class to encapsule all save and load operation in this game
    /// 
    /// Save and Load methods should be implemented using the DataContainer-Structs in order to avoid instantiation of complex classes.
    /// Data is stored and loaded using the PlayerPref.
    /// </summary>
    public static class SavegameManager
    {
        /// <summary>
        /// Save a player data object.
        /// </summary>
        /// <param name="player">Player data to store</param>
        public static void SavePlayer(PlayerData player)
        {
            PlayerPrefs.SetFloat("player.lat", player.lat);
            PlayerPrefs.SetFloat("player.lon", player.lon);
            PlayerPrefs.SetInt("player.score", player.score);
            PlayerPrefs.SetString("player.name", player.name);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Save a Garden data object.
        /// </summary>
        /// <param name="garden">Garden data to store</param>
        public static void SaveGarden(GardenData garden)
        {
            PlayerPrefs.SetString("garden.name", garden.name);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Save a TreePlant object.
        /// </summary>
        /// <param name="treePlant">PlantData of a TreePlant to store</param>
        public static void SaveTree(PlantData treePlant)
        {
            PlayerPrefs.SetString("tree.name", treePlant.name);
            PlayerPrefs.SetInt("tree.evolution", treePlant.evolutionLevel);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Save a NormalPlant object
        /// </summary>
        /// <param name="normalPlant">PlantData of a NormalPlant to store</param>
        /// <param name="identifier">unique identifier for this plant</param>
        public static void SaveNormalPlant(PlantData normalPlant, string identifier)
        {
            PlayerPrefs.SetString(identifier + ".name", normalPlant.name);
            PlayerPrefs.SetInt(identifier + ".evolution", normalPlant.evolutionLevel);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Loads the player data
        /// </summary>
        /// <param name="player">Player data loaded (instantiates new object)</param>
        /// <returns>True if load was successful, false otherwise</returns>
        public static bool LoadPlayer(out PlayerData player)
        {
            player = new PlayerData();
            if (PlayerPrefs.HasKey("player.lat") && PlayerPrefs.HasKey("player.lon") && PlayerPrefs.HasKey("player.score") && PlayerPrefs.HasKey("player.name"))
            {
                player.lat = PlayerPrefs.GetFloat("player.lat");
                player.lon = PlayerPrefs.GetFloat("player.lon");
                player.score = PlayerPrefs.GetInt("player.score");
                player.name = PlayerPrefs.GetString("player.name");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Loads the garden data
        /// </summary>
        /// <param name="garden">Garden data loaded (instantiates new object)</param>
        /// <returns>True if load was successful, false otherwise</returns>
        public static bool LoadGarden(out GardenData garden)
        {
            garden = new GardenData();
            if (PlayerPrefs.HasKey("garden.name"))
            {
                garden.name = PlayerPrefs.GetString("garden.name");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Loads the tree data
        /// </summary>
        /// <param name="tree">PlantData for TreePlant loaded</param>
        /// <returns>True if load was successful, false otherwise</returns>
        public static bool LoadTree(out PlantData tree)
        {
            tree = new PlantData();
            if (PlayerPrefs.HasKey("tree.name") && PlayerPrefs.HasKey("tree.evolution"))
            {
                tree.name = PlayerPrefs.GetString("tree.name");
                tree.evolutionLevel = PlayerPrefs.GetInt("tree.evolution");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Loads a NormalPlant
        /// </summary>
        /// <param name="normalPlant">PlantData for NormalPlant loaded.</param>
        /// <param name="identifier">Identifier of the plant to be loaded</param>
        /// <returns>True if load was successful, false otherwise</returns>
        public static bool LoadNormalPlant(out PlantData normalPlant, string identifier)
        {
            normalPlant = new PlantData();
            string nameKey = identifier + ".name";
            string evolutionKey = identifier + ".evoluation";
            if (PlayerPrefs.HasKey(nameKey) && PlayerPrefs.HasKey(evolutionKey))
            {
                normalPlant.name = PlayerPrefs.GetString(nameKey);
                normalPlant.evolutionLevel = PlayerPrefs.GetInt(evolutionKey);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}