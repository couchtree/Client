using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Interfaces;
using Models;

namespace Managers
{
    public static class SavegameManager
    {
        public static void SavePlayer(PlayerInterface player)
        {
            FileStream stream = new FileStream(GetSavePath(), FileMode.Create);

            PlayerData data = new PlayerData(player);
            GetBinaryFormatter().Serialize(stream, data);
            stream.Close();
        }

        private static BinaryFormatter GetBinaryFormatter()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter;
        }

        public static PlayerData LoadPlayerData()
        {
            if (File.Exists(GetSavePath()))
            {
                FileStream stream = new FileStream(GetSavePath(), FileMode.Open);
                PlayerData playerData = GetBinaryFormatter().Deserialize(stream) as PlayerData;
                stream.Close();

                return playerData;
            }

            Debug.LogError("No Savegame found! Save first once");
            return null;
        }

        public static String GetSavePath()
        {
            return Application.persistentDataPath + "/savegame.stay";
        }
    }
}