using UnityEngine;

public class TurnOnLights : MonoBehaviour
{
    public GameObject lightOne;
    public GameObject lightTwo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag( "Hand" ))
        {
            Debug.Log( "lighton" );
            if (lightOne && lightTwo)
            {
                lightOne.GetComponent<Light>().intensity = 40f;
                lightTwo.GetComponent<Light>().intensity = 40f;
            }
        }
    }

}
