using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffEngine : MonoBehaviour
{
    public GameObject thisBoat;
    private Rigidbody rd;
    private bool isStoped;
    private void Start()
    {

        isStoped = false;
        rd = thisBoat.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (isStoped)
        {   //add controller input
            //set velocity
            rd.drag = 50f;
            isStoped = false;
        }
 
    }
    private void OnTriggerEnter(Collider other)
    {

        if (thisBoat && rd)
        {
            Debug.Log( "coliderOff" );
            isStoped = true;
        }
    }
}
