using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SteerBoatOne : MonoBehaviour
{
    public GameObject thisBoat;
    public GameObject thisJS;
    private bool isTurning;
    private bool isNotTurning;
    private Quaternion prevValueRot;
    public float speed;
    private void Start()
    {
        isTurning = false;
        isNotTurning = false;

        //all tested succeed
        //APIAccess.GetUserMapDirectionLocation();
        //APIAccess.GetUserMapStaticLocation();
        //APIAccess.PostUserLocation();
        //APIAccess.GetWeatherDataAsync();
    }
    private void FixedUpdate()
    { 
        if (isTurning && !isNotTurning)
        {
            var inputDevices = new List<InputDevice>();
            InputDevices.GetDevices( inputDevices );
            float thisTrigger;
            bool trigPreesed;
            Vector3 thispos;
            Quaternion thisRot;

            foreach (var device in inputDevices)
            {
                var getValue = device.TryGetFeatureValue( CommonUsages.deviceRotation , out thisRot );
                //Debug.Log( string.Format( "Device found with name '{0}' and role '{1}' and pos '{2}' " , device.name , device.characteristics.ToString() , primaryBtnValue) );
                if (thisRot.eulerAngles.z > 9f && thisRot.eulerAngles.z < 100f)
                {
                    StartCoroutine( MoveBoatCo() );
                }
                else 
                //if (thisRot.eulerAngles.z > 220f && thisRot.eulerAngles.z < 350f)
                {
                    StartCoroutine( MoveRightBoatCo() );
                }
            }
        }
        if (isNotTurning && !isTurning)
        {
            transform.rotation = prevValueRot;
        }
    }
    IEnumerator MoveBoatCo()
    {
        transform.RotateAround( transform.position , transform.forward , speed * Time.deltaTime );       
        prevValueRot = transform.rotation;
        yield return new WaitForSeconds( 1f );
        thisBoat.transform.RotateAround(thisBoat.transform.position , - thisBoat.transform.up , speed * Time.deltaTime );
    }
    IEnumerator MoveRightBoatCo()
    {
        transform.RotateAround( transform.position , - transform.forward , speed * Time.deltaTime );
        prevValueRot = transform.rotation;
        yield return new WaitForSeconds( 1f );
        thisBoat.transform.RotateAround( thisBoat.transform.position ,  thisBoat.transform.up , speed * Time.deltaTime );
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag( "Hand" ))
        {
            if (thisBoat && thisJS)
            {
                thisJS.SetActive( true );
                isNotTurning = false;
                isTurning = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag( "Hand" ))
        {
            if (thisBoat)
            {
                isTurning = false;
                isNotTurning = true;
            }
        }
    }
}
