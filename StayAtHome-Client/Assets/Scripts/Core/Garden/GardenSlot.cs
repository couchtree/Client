using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenSlot : MonoBehaviour
{
    public GameObject selectedPlant;

    public bool seedPlanted;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void plantSeed()
    {
        if (seedPlanted)
        {
            return;
        }

        Instantiate(selectedPlant, transform);
        seedPlanted = true;
    }
}