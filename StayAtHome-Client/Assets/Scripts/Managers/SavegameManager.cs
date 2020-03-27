using UnityEngine;
using DataContainer;

namespace Managers
{
    public static class SavegameManager
    {
        public static void SavePlayer(PlayerData player)
        {
            PlayerPrefs.SetFloat("player.lat", player.lat);
            PlayerPrefs.SetFloat("player.lon", player.lon);
            PlayerPrefs.SetInt("player.score", player.score);
            PlayerPrefs.SetString("player.name", player.name);
            PlayerPrefs.Save();
        }

        public static void SaveGarden(GardenData garden)
        {
            PlayerPrefs.SetString("garden.name", garden.name);
            PlayerPrefs.Save();
        }

        public static void SaveTree(TreeData treePlant)
        {
            PlayerPrefs.SetString("tree.name", treePlant.name);
            PlayerPrefs.SetInt("tree.evolution", treePlant.evolutionLevel);
            PlayerPrefs.Save();
        }

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

        public static bool LoadTree(out TreeData tree)
        {
            tree = new TreeData();
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
    }
}