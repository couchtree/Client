using System.Collections;
using System.Collections.Generic;
using Core.DesignPattern;
using UnityEngine;
using UnityEngine.Networking;

namespace Managers
{
    
    // Struct representing the Request Body of the Backend-API for POST
    public struct PostRequest
    {
        public float lat;
        public float lon;
        // public int timestamp; // UNIX Timestamp TODO: un-comment as soon as backend is ready for it
        public bool at_home;
        public bool tracked;

        public string SaveToString()
        {
            return JsonUtility.ToJson(this);
        }
    }

    // Struct representing the Response element i.e. a nearby player of the Backend-Api for POST
    public struct PostResponseElement
    {
        public int dir; // -> enum [0:"n",1:"ne",2:"e",3:"se",4:"s",5:"sw",6:"w",7:"nw"]
        public float dist; // [m]
        public float vel_nearing; // clarify on type

        public static PostResponseElement CreateFromJSON(string jsonString)
        {
            Debug.Log("Trying to desirealize: '" + jsonString + "'");
            return JsonUtility.FromJson<PostResponseElement>(jsonString);
        }
    }

    // Struct representing the Response Body-Element of the Backend-API for POST
    public struct PostResponse
    {
        public List<PostResponseElement> nearby_players; // List of up nearby_players

        public static PostResponse CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<PostResponse>(jsonString);
        }
    }


    public class HTTPManager : Singleton<HTTPManager>
    {
        public delegate void ServerResponse(string response);

        private string uuid;

        public void SendRequest(string requestJson, ServerResponse response)
        {
            if (uuid == null)
            {
                uuid = System.Guid.NewGuid().ToString();
                Debug.Log("Generated UUID: '" + uuid + "'");
            }
            var url = "https://creative-two.com/api/v1/player/" + uuid + "/location/";

            StartCoroutine(PostRequest(url, requestJson, response));
        }

        IEnumerator PostRequest(string url, string json, ServerResponse response)
        {
            Debug.Log("Sending to url: '" + url + "'\nMessage: '" + json + "'");
            var uwr = new UnityWebRequest(url, "POST");
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");

            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError)
            {
                response(uwr.error);
                Debug.LogError("Error while Sending: " + uwr.error);
            }
            else
            {
                response(uwr.downloadHandler.text);
            }
        }

    }
}
