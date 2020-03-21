using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using TMPro;
using Core.Global;
using Core.Map;

public class TimeHandler : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI info; // Only for debugging

    private GPS_Tracking gps;
    private HTTPManager server;

    private Player player;

    private PlayerBehavior playerBehavior;

    private HTTPManager.ServerResponse responseDelegate;

    [Range(0.0f, 100.0f)]
    public float maxDistanceFromHome = 10.0f; // Distance from home [m]

    private bool isInitialized = false;

    private float nextActionTime = 0.0f;
    public float period = 0.1f; // [s]

    void Start()
    {
        // Aquire Server Connect utility class
        server = HTTPManager.Instance;
        if (server == null)
        {
            Debug.LogError("No ServerManager found");
            info.SetText("No ServerManager found");
        }
        gps = GetComponent<GPS_Tracking>();
        if (gps == null)
        {
            Debug.LogError("No GPS_Tracking found.");
            info.SetText("No GPS_Tracking found.");
        }
        playerBehavior = GetComponent<PlayerBehavior>();
        if (playerBehavior == null)
        {
            Debug.LogError("No PlayerBehavior found.");
            info.SetText("No PlayerBehavior found.");
        }
        player = GetComponent<Player>();
        if (playerBehavior == null)
        {
            Debug.LogError("No PlayerBehavior found.");
            info.SetText("No PlayerBehavior found.");
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
        // Request current lan, lon from PGS
        PostRequest request = new PostRequest();
        request.lat = gps.GetLatitude();
        request.lon = gps.GetLongitude();
        request.at_home = player.AtHomeBase(request.lat, request.lon);
        request.tracked = true;
        // request.timestamp = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1)).TotalSeconds); TODO Enable as soon as backend is ready

        // Send message to server
        server.SendRequest(JsonUtility.ToJson(request), responseDelegate);
    }

    private void HandleServerRequest(string response)
    {
        Debug.Log("Response is: " + response);
        info.SetText("Response is:" + response); //Remove
        PostResponse responses =  JsonUtility.FromJson<PostResponse>(response);
        // Decide on response according to answer from server
        if (responses.responseElements[0].dist > maxDistanceFromHome)
        {
            playerBehavior.SubtractPoints(10);
        }
        else
        {
            playerBehavior.AddPoints(10);
        }
    }
}


