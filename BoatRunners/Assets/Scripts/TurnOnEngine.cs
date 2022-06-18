using System.Collections;
using UnityEngine;

public class TurnOnEngine : MonoBehaviour
{
    public GameObject thisBoat;
    public GameObject windmill;
    public GameObject lightOne;
    public GameObject lightTwo;

    private bool isDriving;
    private float speed;
    private Vector3 playerPos;
    private void Start()
    {
        isDriving = false;
        speed = 1f;
    }
    private void FixedUpdate()
    {
        if (isDriving)
        {         
            if (!BoatOneStatics.isStoped && windmill && !BoatOneStatics.isLightOn)
               {
                StartCoroutine( RunEngingCo() );       
            }
        }
    }
    private IEnumerator RunEngingCo()
    {
        //thisPlayer.transform.parent = thisBoat.transform;
        windmill.transform.RotateAround( windmill.transform.position , windmill.transform.forward , Random.Range( 0 , 360 ) );
        yield return new WaitForSeconds( 2f );
        if (lightOne && lightTwo)
        {
            lightOne.GetComponent<Light>().intensity = 40f;
            lightTwo.GetComponent<Light>().intensity = 40f;
        }
        //thisBoat.transform.position += thisBoat.transform.forward * Time.deltaTime * speed;
        yield return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log( "start" );
        if (other.CompareTag( "Hand" ))
        {
            if (thisBoat)
            {
                BoatOneStatics.isStoped = false;
                isDriving = true;
            }
        }
    }
}
