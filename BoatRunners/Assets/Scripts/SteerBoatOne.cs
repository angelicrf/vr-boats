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
                //var runBoat = device.TryGetFeatureValue( CommonUsages.primary2DAxis , out primaryBtnValue );
                var getValue = device.TryGetFeatureValue( CommonUsages.deviceRotation , out thisRot );
                Debug.Log( string.Format( "Device found with name '{0}' and role '{1}' and pos '{2}' " , device.name , device.characteristics.ToString() , primaryBtnValue) );
                //transform.rotation = Quaternion.Lerp( Quaternion.Euler( new Vector3( transform.rotation.eulerAngles.x , transform.rotation.eulerAngles.y , transform.rotation.eulerAngles.z ) ) , Quaternion.Euler(new Vector3( transform.rotation.eulerAngles.x , transform.rotation.eulerAngles.y , thisRot.eulerAngles.z)) , Time.deltaTime * speed );

                // var direction = new Vector3(  , 0f ,  );
                // transform.Translate( direction * speed * Time.deltaTime , Space.World );

                // Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
                // Apply this movement to the rigidbody's position.
                //m_Rigidbody.MovePosition( m_Rigidbody.position + movement );

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
