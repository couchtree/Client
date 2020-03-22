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
        public static void Save(ISaveable toSave, IDataForSerialization dataForSerialization)
        {
            FileStream stream = new FileStream(GetSavePath(dataForSerialization.getFilename()), FileMode.Create);

            Debug.Log("save to file: " + GetSavePath(dataForSerialization.getFilename()));
            GetBinaryFormatter().Serialize(stream, toSave.GenerateSaveableData());
            stream.Close();
        }

        public static IDataForSerialization LoadPlayer()
        {
            if (File.Exists(GetSavePath(Player.filename)))
            {
                FileStream stream = new FileStream(GetSavePath(Player.filename), FileMode.Open);
                PlayerData playerData = GetBinaryFormatter().Deserialize(stream) as PlayerData;
                stream.Close();
                if (playerData is null)
                {
                    return null;
                }
                playerData.loadFromData();

                return playerData;
            }

            Debug.LogError("No player savegame found! Save first once");
            return null;
        }

        public static IDataForSerialization LoadGarden()
        {
            if (File.Exists(GetSavePath(MyGarden.filename)))
            {
                FileStream stream = new FileStream(GetSavePath(MyGarden.filename), FileMode.Open);
                GardenData gardenData = GetBinaryFormatter().Deserialize(stream) as GardenData;
                stream.Close();
                Debug.Log(gardenData);
                if (gardenData is null)
                {
                    return null;
                }
                Debug.Log(gardenData);
                gardenData.loadFromData();

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