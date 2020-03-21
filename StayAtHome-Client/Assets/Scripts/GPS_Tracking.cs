using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif


public class GPS_Tracking : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI info;

    IEnumerator Start()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            info.SetText("GPS is needed. Please allow Location access");
            yield return 0;
            Permission.RequestUserPermission(Permission.FineLocation);

           
        }
        else
        {
             if(!Input.location.isEnabledByUser){
          info.SetText("GPS is required");
          yield break;
      }

            // Start service before querying location
            Input.location.Start();

            // Wait until service initializes
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                info.SetText(maxWait.ToString());
                maxWait--;
            }

            // Service didn't initialize in 20 seconds
            /*if (maxWait < 1)
            {
                info.SetText("Timed out");
                yield break;
            }*/

            // Connection has failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                info.SetText("Unable to determine device location");
                yield break;
            }
            else
            {
                // Access granted and location value could be retrieved
                info.SetText("Latitude: " + Input.location.lastData.latitude + " Longitude" + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            }

            // Stop service if there is no need to query location updates continuously
            Input.location.Stop();
        }

        // First, check if user has location service enabled
#endif
      
    }
}
