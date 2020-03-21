﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.DesignPattern;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public string deviceID;
        private protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            Screen.orientation = ScreenOrientation.Portrait;
            
            deviceID = GetSHA512(GetNetworkInterfaces());
            Debug.Log("DeviceID: " + deviceID);
            
            // HTTP Test
            HTTPManager.Instance.SendRequest("{\"test\":\"djhgfusdhufg\"}");
        }

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
