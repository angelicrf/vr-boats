using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SteerBoatOne : MonoBehaviour
{
    public GameObject thisBoat;
    private Rigidbody rd;
    private bool isTurning;
    private bool isNotTurning;
    private Vector2 primaryBtnValue;
    private Quaternion prevValueRot;
    public float speed;
    private void Start()
    {
        isTurning = false;
        isNotTurning = false;
        isLeftTurn = false;
        rd = thisBoat.GetComponent<Rigidbody>();
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
                //device.TryGetFeatureValue( CommonUsages.primary2DAxis , out primaryBtnValue );
                var getValue = device.TryGetFeatureValue( CommonUsages.deviceRotation , out thisRot );
                //Debug.Log( string.Format( "Device found with name '{0}' and role '{1}' and pos '{2}' " , device.name , device.characteristics.ToString() , thisRot.eulerAngles.z ) );
                //transform.rotation = Quaternion.Lerp( Quaternion.Euler( new Vector3( transform.rotation.eulerAngles.x , transform.rotation.eulerAngles.y , transform.rotation.eulerAngles.z ) ) , Quaternion.Euler(new Vector3( transform.rotation.eulerAngles.x , transform.rotation.eulerAngles.y , thisRot.eulerAngles.z)) , Time.deltaTime * speed );
                if (thisRot.eulerAngles.z > 9f && thisRot.eulerAngles.z < 100f)
                {
                    StartCoroutine( MoveBoatCo() );
                }
                if (thisRot.eulerAngles.z > 220f && thisRot.eulerAngles.z < 350f)
                {
                    Debug.Log( "exitTrigger" + transform.forward );
                    transform.RotateAround( transform.position , - transform.forward  , speed * Time.deltaTime );
                    //thisBoat.transform.transform.Rotate( 0 , transform.up.y , 0 , Space.Self );
                    //thisBoat.transform.RotateAround( transform.position , transform.TransformDirection(- Vector3.up ) , speed * Time.deltaTime );
                    prevValueRot = transform.rotation;
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
        thisBoat.transform.RotateAround(thisBoat.transform.position , thisBoat.transform.up , speed * Time.deltaTime );
    }
    private void OnTriggerEnter(Collider other)
    {
        if (thisBoat && rd)
            {
            isNotTurning = false;
            isTurning = true;
            }
    }
    private void OnTriggerExit(Collider other)
    {
        if (thisBoat && rd)
        {
            isTurning = false;
            isNotTurning = true;
        }
    }
}
