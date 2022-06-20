using UnityEngine;

public class TurnOnLights : MonoBehaviour
{
    public GameObject lightOne;
    public GameObject lightTwo;
    public void TurnOnLightsBoatOne()
    {
        if (lightOne && lightTwo)
        {
            if (!BoatOneStatics.isLightOn)
            {
                lightOne.GetComponent<Light>().intensity = 40f;
                lightTwo.GetComponent<Light>().intensity = 40f;
                BoatOneStatics.isLightOn = true;
            }
            else
            {
                BoatOneStatics.isLightOn = false;
                lightOne.GetComponent<Light>().intensity = 0;
                lightTwo.GetComponent<Light>().intensity = 0;
            }
        }
    }

}
