using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Managers;
using TMPro;
using Core.Global;
using Core.Map;

public class TimeHandler : MonoBehaviour
{
    [SerializeField]
    private GPS_Tracking gps;

    private HTTPManager server;

    [SerializeField]
    private Player player;

    private PlayerBehavior playerBehavior;

    private HTTPManager.ServerResponse responseDelegate;

    [Range(0.0f, 100.0f)]
    public float maxDistanceFromHome = 10.0f; // Distance from home [m]

    private bool isInitialized = false;

    private float nextActionTime = 0.0f;

    [Range(0.0f, 60.0f)]
    public float period = 1.0f; // [s]

    [Range(0, 100)]
    public int scoreSteps = 10; // Amount the socre changes on a good or bad behaviour

    void Start()
    {
        server = HTTPManager.Instance;
        if (server == null)
        {
            Debug.LogError("No ServerManager found");
            return;
        }
        if (gps == null)
        {
            Debug.LogError("No GPS_Tracking found.");
            return;
        }
        playerBehavior = PlayerBehavior.Instance;
        if (playerBehavior == null)
        {
            Debug.LogError("No PlayerBehavior found.");
            return;
        }
        if (playerBehavior == null)
        {
            Debug.LogError("No PlayerBehavior found.");
            return;
        }
        responseDelegate = HandleServerRequest;

        isInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime && isInitialized)  
        {
            nextActionTime += period;
            RequestUpdate();
        }
    }

    private void RequestUpdate()
    {
        // Request current lat, lon from GPS
        PostRequest request = new PostRequest();
        request.lat = gps.GetLatitude();
        request.lon = gps.GetLongitude();
        request.at_home = player.AtHomeBase(request.lat, request.lon);
        request.tracked = true;
        // request.timestamp = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1)).TotalSeconds); TODO Enable as soon as backend is ready

        // Send message to server
        server.SendRequest(JsonUtility.ToJson(request), responseDelegate);
    }

    private void HandleServerRequest(string responseMsg)
    {
        PostResponse responses = new PostResponse();

        try
        {
            responses =  JsonUtility.FromJson<PostResponse>(responseMsg);
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to serialize message: '" + responseMsg +  "' with error: '" + ex.Message + "'");
            return;
        }

        if (playerBehavior == null)
        {
            Debug.LogError("No playerBehavior present");
            return;
        }

        if (responses.nearby_players.Length <= 0)
        {
            Debug.Log("No player close by");
            this.playerBehavior.AddPoints(scoreSteps);
            return;
        }

        // Decide on response according to answer from server
        if (responses.nearby_players[0].dist > maxDistanceFromHome)
        {
            this.playerBehavior.SubtractPoints(scoreSteps);
        }
        else
        {
            this.playerBehavior.AddPoints(scoreSteps);
        }
    }
}


