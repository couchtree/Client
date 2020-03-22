using UnityEngine;
using Core.Garden;
using Core.Map;

namespace Managers
{
    public static class SavegameManager
    {
        public static void SavePlayer(Player player)
        {
            PlayerPrefs.SetFloat("player.lat", player.lat);
            PlayerPrefs.SetFloat("player.lon", player.lon);
            PlayerPrefs.SetInt("player.score", player.score);
            PlayerPrefs.SetString("player.name", player.Name);
            PlayerPrefs.Save();
        }

        public static void SaveGarden(MyGarden garden)
        {
            PlayerPrefs.SetString("garden.name", garden.Name);
            PlayerPrefs.Save();
        }

        public static void SaveTree(TreePlant treePlant)
        {
            PlayerPrefs.SetString("tree.name", treePlant.Name);
            PlayerPrefs.SetInt("tree.evolution", treePlant.EvolutionLevel);
            PlayerPrefs.Save();
        }
        //
        // public static void Save(ISaveable toSave, IDataForSerialization dataForSerialization)
        // {
        //     FileStream stream = new FileStream(GetSavePath(dataForSerialization.getFilename()), FileMode.Create);
        //
        //     Debug.Log("save to file: " + GetSavePath(dataForSerialization.getFilename()));
        //     GetBinaryFormatter().Serialize(stream, toSave.GenerateSaveableData());
        //     stream.Close();
        // }
        //
        // public static IDataForSerialization LoadPlayer()
        // {
        //     if (File.Exists(GetSavePath(Player.filename)))
        //     {
        //         FileStream stream = new FileStream(GetSavePath(Player.filename), FileMode.Open);
        //         PlayerData playerData = GetBinaryFormatter().Deserialize(stream) as PlayerData;
        //         stream.Close();
        //         if (playerData is null)
        //         {
        //             return null;
        //         }
        //
        //         playerData.loadFromData();
        //
        //         return playerData;
        //     }
        //
        //     Debug.LogError("No player savegame found! Save first once");
        //     return null;
        // }
        //
        // public static IDataForSerialization LoadGarden()
        // {
        //     if (File.Exists(GetSavePath(MyGarden.filename)))
        //     {
        //         FileStream stream = new FileStream(GetSavePath(MyGarden.filename), FileMode.Open);
        //         GardenData gardenData = GetBinaryFormatter().Deserialize(stream) as GardenData;
        //         stream.Close();
        //         Debug.Log(gardenData);
        //         if (gardenData is null)
        //         {
        //             return null;
        //         }
        //
        //         Debug.Log(gardenData);
        //         gardenData.loadFromData();
        //
        //         return gardenData;
        //     }
        //
        //     Debug.LogError("No garden savegame found! Save first once");
        //     return null;
        // }
        //
        // public static String GetSavePath(String fileName)
        // {
        //     return Application.persistentDataPath + "/" + fileName + ".stay";
        // }
        //
        // private static BinaryFormatter GetBinaryFormatter()
        // {
        //     BinaryFormatter formatter = new BinaryFormatter();
        //     return formatter;
        // }
    }
}