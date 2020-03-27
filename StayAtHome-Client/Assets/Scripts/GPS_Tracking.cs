﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif
using UnityEngine.iOS;

public class GPS_Tracking : MonoBehaviour
{
    float latitude, longitude;

    private void Start()
    {
        StartCoroutine(CheckForGPSAccess());
    }


    IEnumerator CheckForGPSAccess()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Debug.Log("GPS is needed. Please allow Location access");
            yield return 0;
            Permission.RequestUserPermission(Permission.FineLocation);
            while (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                Debug.Log("Needs permission");
                yield return new WaitForSeconds(2);
            }
            StartCoroutine(InitializeGPS());

        }
        else
        {
            StartCoroutine(InitializeGPS());
        }
#else
            StartCoroutine(InitializeGPS());
        
        Debug.LogWarning("GPS not implemented.");
#endif
        yield return null;
    }


    IEnumerator InitializeGPS()
    {
        // Start service before querying location
        Input.location.Start();

        // First, check if user has location service enabled
        if (!isGpsEnabled())
        {
            Debug.LogWarning("GPS required");
            yield return new WaitForSeconds(5); // used to slow down request
            StartCoroutine(InitializeGPS());
            yield break;
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            SetLatAndLong();
            Debug.Log("Latitude: " + GetLatitude().ToString() + "\n Longitude: " + GetLongitude().ToString());

            // Stop service if there is no need to query location updates continuously
            Input.location.Stop();
        }
    }

    public static bool isGpsEnabled()
    {
        return Input.location.isEnabledByUser;
    }

    void SetLatAndLong()
    {
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
    }

    public float GetLatitude()
    {
        return latitude;
    }

    public float GetLongitude()
    {
        return longitude;
    }
}