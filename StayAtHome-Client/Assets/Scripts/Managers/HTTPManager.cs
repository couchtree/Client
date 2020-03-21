using System.Collections;
using System.Collections.Generic;
using Core.DesignPattern;
using UnityEngine;
using UnityEngine.Networking;

namespace Managers
{
    
    // Class representing the Request Body of the Backend-API for POST
    public class PostRequest : MonoBehaviour
    {
        public float lat;
        public float lon;
        public bool at_home;
        public bool tracked;

        public PostRequest()
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

    public class PostResponseElement
    {
        public int dir; // -> enum [0:"n",1:"ne",2:"e",3:"se",4:"s",5:"sw",6:"w",7:"nw"]
        public float dist; // [m]
        public float vel_nearing; // clarify on type

        public static PostResponseElement CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<PostResponseElement>(jsonString);
        }
    }
    // Class representing the Response Body-Element of the Backend-API for POST
    public class PostResponse : MonoBehaviour
    {
        public List<PostResponseElement> responseElements; // List of up PostResponseElements each for another player

        public static PostResponse CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<PostResponse>(jsonString);
        }
    }

    public class HTTPManager : Singleton<HTTPManager>
    {
        public delegate void ServerResponse(string response);


        public void SendRequest(string requestJson, ServerResponse response)
        {
            var url = "https://prooxey.de/endpoint.php";

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
                response(uwr.error);
                Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                response(uwr.downloadHandler.text);
                Debug.Log("Received: " + uwr.downloadHandler.text);
            }
        }

    }
}
