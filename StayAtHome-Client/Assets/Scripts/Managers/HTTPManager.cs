using System.Collections;
using System.Collections.Generic;
using Core.DesignPattern;
using UnityEngine;
using UnityEngine.Networking;

namespace Managers
{
    
    // Struct representing the Request Body of the Backend-API for POST
    [System.Serializable]
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
    [System.Serializable]
    public struct PostResponseElement
    {
        public int dir; // -> enum [0:"n",1:"ne",2:"e",3:"se",4:"s",5:"sw",6:"w",7:"nw"]
        public float dist; // [m]
        public float vel_nearing; // clarify on type
    }

    // Struct representing the Response Body-Element of the Backend-API for POST
    [System.Serializable]
    public class PostResponse
    {
        public PostResponseElement[] nearby_players = new PostResponseElement[5]; // List of up nearby_players

        override public string ToString()
        {
            return JsonUtility.ToJson(this);
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
                uuid = GameManager.GetSHA512(GameManager.Instance.GetNetworkInterfaces());
                Debug.Log("Generated UUID: '" + uuid + "'");
            }
            var url = "https://creative-two.com/api/v1/player/" + uuid + "/location/";

            StartCoroutine(PostRequest(url, requestJson, response));
        }

        IEnumerator PostRequest(string url, string json, ServerResponse response)
        {
            Debug.Log("Sending to url: '" + url + "'\nMessage: '" + json + "'"); // TODO remove
            var uwr = new UnityWebRequest(url, "POST");
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");

            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError)
            {
                Debug.LogError("Error while Sending: " + uwr.error);
                response(uwr.error);
            }
            else
            {
                Debug.Log("Response from server: " + uwr.downloadHandler.text);
                response(uwr.downloadHandler.text);
            }
        }
    }
}
