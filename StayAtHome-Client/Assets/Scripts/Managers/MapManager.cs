using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Core.DesignPattern;
using Core.Global;
using Core.Map;
using Debug = UnityEngine.Debug;

namespace Managers
{
    public class MapManager : Singleton<MapManager>
    {
        public GameObject playerPrefab;
        public GameObject nearPlayerGroup;

        GameObject player;
        List<GameObject> nearPlayers = new List<GameObject>();

        private void Start()
        {
            player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }

        private void Update()
        {
            TestFunction();
        }

        private void TestFunction()
        {
            if (Input.GetKeyDown(KeyCode.A))
                AddPlayer("Test", CardinalDirection.NorthEast, 4f);
        }

        public void AddPlayer(String name, float direction, float distance)
        {
            var position = new Vector3(distance, 0, 0);
            var rotation = Quaternion.Euler(0, 0, direction);
            var newPlayer = Instantiate(playerPrefab, transform.position, rotation);

            var player = newPlayer.GetComponent<Player>();

            player.name = name;
            player.distance = distance;
            
            newPlayer.name = "Player " + name;
            newPlayer.transform.parent = nearPlayerGroup.transform;

            newPlayer.transform.Translate(position);
            newPlayer.transform.localRotation = Quaternion.Euler(0, 0, 0);
            
            Debug.Log("Near player : " + name + " - Distance: " + distance);
        }
    }
}
