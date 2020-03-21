using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using TMPro;
using Core.Global;

public class Request : MonoBehaviour
{
    public float lat;
    public float lon;
    public bool at_home;
    public bool tracked;

    Request()
    {
        lat = 0.0f;
        lon = 0.0f;
        at_home = false;
        tracked = false;
    }

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}

[System.Serializable]
public class Response : Object
{
    public int dir; // -> enum [0:"n",1:"ne",2:"e",3:"se",4:"s",5:"sw",6:"w",7:"nw"]
    public float dist;
    public float vel_nearing; // clarify on type

    public static Response CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Response>(jsonString);
    }
}

public class TimeHandler : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI info; // Only for debugging

    private GPS_Tracking gps;
    private HTTPManager server;

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

        isInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime && isInitialized)  
        {
            info.SetText("Send Request");
            nextActionTime += period;
            RequestUpdate();
        }
    }

    private void RequestUpdate()
    {
        // Request current lan, lon from PGS
        Request request = new Request();
        request.lat = gps.GetLatitude();
        request.lon = gps.GetLongitude();

        // Send message to server
        server.SendRequest(JsonUtility.ToJson(request), responseDelegate);
    }

    private void HandleServerRequest(string response)
    {
        Debug.Log("Response is: " + response);
        info.SetText("Response is:" + response); //Remove
        List<Response> responses =  JsonUtility.FromJson<List<Response>>(response);
        // Decide on response according to answer from server
        if (responses[0].dist > maxDistanceFromHome)
        {
            playerBehavior.SubtractPoints(10);
        }
        else
        {
            playerBehavior.AddPoints(10);
        }
    }
}


