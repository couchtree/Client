using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.DesignPattern;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace Managers
{
    /// <summary>
    /// The general Game Manager
    /// 
    /// Currently it manages the SHA-Encryption and the devive registration
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        [HideInInspector]
        public string deviceID{get; private set;}

        HTTPManager.ServerResponse responseDelegate;
        private protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            Screen.orientation = ScreenOrientation.Portrait;
            
            deviceID = GetSHA512(GetNetworkInterfaces());
            Debug.Log("DeviceID: " + deviceID);
        }

        /// <summary>
        /// Retrieve a concatenated string of the network interface mac-addresses
        /// </summary>
        /// <returns>Concatenated Mac-Addresses</returns>
        public string GetNetworkInterfaces()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            string macAdr = "";
            
            foreach (NetworkInterface adapter in nics)
            {
                PhysicalAddress address = adapter.GetPhysicalAddress();
                byte[] bytes = address.GetAddressBytes();
                string mac = null;
                for (int i = 0; i < bytes.Length; i++)
                {
                    mac = string.Concat(mac +(string.Format("{0}", bytes[i].ToString("X2"))));
                    if (i != bytes.Length - 1)
                    {
                        mac = string.Concat(mac + "-");
                    }
                }
                Debug.Log("Found device: " + mac);
                
                if (macAdr != "")
                    macAdr += "-" + mac;
                else
                    macAdr = mac;
            }

            return macAdr;
        }
        
        /// <summary>
        /// Hash the provided string with SHA512
        /// </summary>
        /// <param name="text">string to has</param>
        /// <returns>hased string</returns>
        public static string GetSHA512(string text) 
        {
            SHA512 sha = new SHA512Managed();
            
            sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            
            byte[] result = sha.Hash;
     
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
         
            return strBuilder.ToString();
        }
    }
}
