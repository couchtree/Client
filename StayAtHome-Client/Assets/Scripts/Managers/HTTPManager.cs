using System.Collections;
using System.Collections.Generic;
using Core.DesignPattern;
using UnityEngine;
using UnityEngine.Networking;

namespace Managers
{
    /// <summary>
    /// Struct representing the Request Body of the Backend-API for POST.
    /// 
    /// Make sure to not rename the members as these are serialized into JSON.
    /// Any renaming must be discussed and agreed appon the the backend!
    /// </summary>
    [System.Serializable]
    public struct PostRequest
    {
        public float lat;  // latitude to send to server
        public float lon; // longitude to send to server
        // public int timestamp; // UNIX Timestamp TODO: un-comment as soon as backend is ready for it
        public bool at_home; // players state to send to server
        public bool tracked; // player trackability e.g. is should not be tracked if the player is moving to fast

        public string SaveToString()
        {
            return JsonUtility.ToJson(this);
        }
    }

    /// <summary>
    /// Struct representing the Response element i.e. a nearby player of the Backend-Api for POST 
    ///
    /// Make sure to not rename the members as these are serialized into JSON.
    /// Any renaming must be discussed and agreed appon the the backend!
    /// </summary>
    [System.Serializable]
    public struct PostResponseElement
    {
        public int dir; // -> enum [0:"n", 1:"ne", 2:"e", 3:"se", 4:"s", 5:"sw", 6:"w", 7:"nw"]
        public float dist; // [m]
        public float vel_nearing; // clarify on type
    }

    /// <summary>
    /// Struct representing the Response Body-Element of the Backend-API for POST 
    ///
    /// Make sure to not rename the members as these are serialized into JSON.
    /// Any renaming must be discussed and agreed appon the the backend!
    /// </summary>
    [System.Serializable]
    public class PostResponse
    {
        public PostResponseElement[] nearby_players = new PostResponseElement[5]; // List of up nearby_players

        override public string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }

    /// <summary>
    /// Singleton to communicate with the backend-server
    /// </summary>
    public class HTTPManager : Singleton<HTTPManager>
    {
        public delegate void ServerResponse(string response);

        private string uuid;

        /// <summary>
        /// Sending a request to the server and triggering the ServerResponse when answer was received.
        /// 
        /// The whole send and receive process runs asynchronous
        /// </summary>
        /// <param name="requestJson">Json-string to send to server</param>
        /// <param name="response">Response delegate to trigger when answer was received</param>
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
