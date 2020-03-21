using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Core.Garden;
using Core.Map;
using Core.Interfaces;
using Core.Models;

namespace Managers
{
    public static class SavegameManager
    {
        public static void Save(Saveable toSave, DataForSerialization dataForSerialization)
        {
            FileStream stream = new FileStream(GetSavePath(dataForSerialization.getFilename()), FileMode.Create);

            Debug.Log("save to file: " + GetSavePath(dataForSerialization.getFilename()));
            GetBinaryFormatter().Serialize(stream, toSave.GenerateSaveableData());
            stream.Close();
        }

        public static DataForSerialization LoadPlayer()
        {
            if (File.Exists(GetSavePath(Player.filename)))
            {
                FileStream stream = new FileStream(GetSavePath(Player.filename), FileMode.Open);
                PlayerData playerData = GetBinaryFormatter().Deserialize(stream) as PlayerData;
                stream.Close();

                return playerData;
            }

            Debug.LogError("No player savegame found! Save first once");
            return null;
        }

        public static DataForSerialization LoadGarden()
        {
            if (File.Exists(GetSavePath(Garden.filename)))
            {
                FileStream stream = new FileStream(GetSavePath(Garden.filename), FileMode.Open);
                GardenData gardenData = GetBinaryFormatter().Deserialize(stream) as GardenData;
                stream.Close();

                return gardenData;
            }

            Debug.LogError("No garden savegame found! Save first once");
            return null;
        }

        public static String GetSavePath(String fileName)
        {
            return Application.persistentDataPath + "/" + fileName + ".stay";
        }

        private static BinaryFormatter GetBinaryFormatter()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter;
        }
    }
}