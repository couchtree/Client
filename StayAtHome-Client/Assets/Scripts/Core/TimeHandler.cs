using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class ServerRequest : MonoBehaviour
{
    public float lat;
    public float lon;

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}

[System.Serializable]
public class ServerReturn : Object
{
    public float distance;

    public static ServerReturn CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ServerReturn>(jsonString);
    }
}

public class TimeHandler : MonoBehaviour
{
    private GPS_Tracking gps;
    private ServerManager server;

    [Range(0.0f, 100.0f)]
    public float maxDistanceFromHome = 10.0f; // Distance from home [m]

    private bool isInitialized = false;

    private float nextActionTime = 0.0f;
    public float period = 0.1f; // [s]

    // Start is called before the first frame update
    void Start()
    {
        // Aquire Server Connect utility class
        server = GetComponent<ServerManager>();
        if (server == null)
        {
            Debug.LogError("No ServerManager found");
        }
        gps = GetComponent<GPS_Tracking>();
        if (gps == null)
        {
            Debug.LogError("No GPS_Tracking found.");
        }
        isInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime && isInitialized)  
        {
            nextActionTime += period;
            RequestAndHandleUpdate();
        }
    }

    private void RequestAndHandleUpdate()
    {
        ServerReturn answer = new ServerReturn();
        if (RequestUpdate(out answer))
        {
            HandleServerRequest(answer);
        }
    }

    private bool RequestUpdate(out ServerReturn serverAnswer)
    {
        // Request current lan, lon from PGS
        ServerRequest request = new ServerRequest();
        request.lat = gps.GetLatitude();
        request.lon = gps.GetLongitude();

        // Send message to server
        server.Send(request);

        // receiving answer from server and providing result
        // string message = server.Listen(); ??
        string message = string.Empty;
        serverAnswer = ServerReturn.CreateFromJSON(message);

        return true;
    }

    private void HandleServerRequest(ServerReturn answer)
    {
        // Decide on response according to answer from server
        if (answer.distance > maxDistanceFromHome)
        {
            // Trigger Bad event
        }
        else
        {
            // Trigger good event
        }
    }
}


