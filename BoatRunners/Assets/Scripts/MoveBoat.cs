using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MoveBoat : MonoBehaviour
{
    public GameObject thisBoat;
    private Rigidbody rd;
    private Vector2 primaryBtnValue;
    public float speed;
    private void Start()
    {
        rd = thisBoat.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevices( inputDevices );
        float thisTrigger;
        bool trigPreesed;
        Vector3 thispos;
        Quaternion thisRot;

        foreach (var device in inputDevices)
        {
            var runBoat = device.TryGetFeatureValue( CommonUsages.primary2DAxis , out primaryBtnValue );
            //var getValue = device.TryGetFeatureValue( CommonUsages.deviceRotation , out thisRot );
            Debug.Log( string.Format( "Device found with name '{0}' and role '{1}' and pos '{2}' " , device.name , device.characteristics.ToString() , primaryBtnValue ) );
            ///var direction = new Vector3(primaryBtnValue.x,0,primaryBtnValue.y);
            //thisBoat.transform.Translate(direction  * speed * Time.deltaTime , Space.World );
            if (primaryBtnValue.x > 0 && primaryBtnValue.y > 0)
            {
                Vector3 movement = thisBoat.transform.forward * 1f * speed * Time.deltaTime;
                if (rd)
                {
                    rd.MovePosition( rd.position + movement );
                }
            }else if(primaryBtnValue.x < 0 && primaryBtnValue.y < 0)
            {
               Vector3 movement = thisBoat.transform.forward * -1f * speed * Time.deltaTime;
                    if (rd)
                    {
                        rd.MovePosition( rd.position + movement );
                    }
            }
            else if (primaryBtnValue.y < 0 && primaryBtnValue.x > 0)
            {
                float turn = primaryBtnValue.y * 1f * Time.deltaTime;
                Quaternion turnRotation = Quaternion.Euler( 0f , turn * 100 , 0f );
                if (rd)
                {  
                    rd.MoveRotation( rd.rotation * turnRotation );
                }
            }
            else if (primaryBtnValue.y > 0 && primaryBtnValue.x < 0)
            {
                float turn = primaryBtnValue.y * 1f * Time.deltaTime;
                Quaternion turnRotation = Quaternion.Euler( 0f , turn * 100 , 0f );

                if (rd)
                {
                    rd.MoveRotation( rd.rotation * turnRotation );
                }
            }

        }
    }
}
