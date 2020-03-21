using System.Collections;
using System.Collections.Generic;
using Core.DesignPattern;
using UnityEngine;
using UnityEngine.Networking;

namespace Managers
{
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
