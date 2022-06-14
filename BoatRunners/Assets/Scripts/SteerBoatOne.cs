using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerBoatOne : MonoBehaviour
{
    public GameObject thisBoat;
    private Rigidbody rd;
    private void Start()
    {
        rd = thisBoat.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag( "Player" ))
        //{
            if (thisBoat && rd)
            {
                Debug.Log( "isDriving.." );
                //add controller input
                //set velocity
                rd.AddForce( -Vector3.forward , ForceMode.Impulse );
            }

       // }
    }
    private void OnTriggerExit(Collider other)
    {
       // if (other.CompareTag( "Player" ))
       // {
            if (thisBoat && rd)
            {
                Debug.Log( "isDrivingExit.." );
            }
       // }
    }
}
