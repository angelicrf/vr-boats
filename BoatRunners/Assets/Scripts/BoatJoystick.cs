using UnityEngine;

public class BoatJoystick : MonoBehaviour
{
    public GameObject thisJS;
    public GameObject thisBoat;
    private float speed = 1f;
    private bool isTurnRight = false;
    private bool isTurnLeft = false;
    private bool isMovedBack = false;
    private bool isMovedUp = false;
    private bool isStoped = false;
    private Quaternion prevBoatRot;
    private Vector3 prevBoatPos;
    private void FixedUpdate()
    {
        if (isMovedBack)
        {
            Vector3 movement = thisBoat.transform.forward * 1f * speed * Time.deltaTime;
            if (thisBoat)
            {
                if (prevBoatRot.x != 0 || prevBoatRot.y != 0 || prevBoatRot.z != 0)
                {
                    thisBoat.transform.rotation = prevBoatRot;
                    thisBoat.transform.Translate( movement );
                    prevBoatPos = thisBoat.transform.position;
                }
                thisBoat.transform.Translate( movement );
                prevBoatRot = thisBoat.transform.rotation;
                prevBoatPos = thisBoat.transform.position;
            }
        }
        else if (isMovedUp)
        {
            Vector3 movement = thisBoat.transform.forward * -1f * speed * Time.deltaTime;
            if (prevBoatRot.x != 0 || prevBoatRot.y != 0 || prevBoatRot.z != 0)
            {
                thisBoat.transform.rotation = prevBoatRot;
                thisBoat.transform.Translate( movement );
                prevBoatPos = thisBoat.transform.position;
            }
            thisBoat.transform.Translate( movement );
            prevBoatRot = thisBoat.transform.rotation;
            prevBoatPos = thisBoat.transform.position;
        }
        else if (isTurnLeft)
        {
            float turn = -0.05f * 1f * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler( 0f , turn * 100 , 0f );
            Vector3 v = new Vector3( turnRotation.eulerAngles.x , turnRotation.eulerAngles.y , turnRotation.eulerAngles.z );
            thisBoat.transform.Rotate( v );
            prevBoatRot = thisBoat.transform.rotation;
            prevBoatPos = thisBoat.transform.position;
        }
        else if (isTurnRight)
        {
            float turn = 0.05f * 1f * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler( 0f , turn * 100 , 0f );
            Vector3 v = new Vector3( turnRotation.eulerAngles.x , turnRotation.eulerAngles.y , turnRotation.eulerAngles.z );
            thisBoat.transform.Rotate( v );
            prevBoatRot = thisBoat.transform.rotation;
            prevBoatPos = thisBoat.transform.position;
        }else if (isStoped)
        {
            thisBoat.transform.position = prevBoatPos;
            thisBoat.transform.rotation = prevBoatRot;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag( "Hand" ))
        {
            if (thisJS)
            {
                thisJS.SetActive( true );
            }
        }
    }
    public void TurnRightJS()
    {
        isTurnRight = true;
        isTurnLeft = false;
        isMovedUp = false;
        isMovedBack = false;
    }
    public void TurnLefttJS()
    {
        isTurnLeft = true;
        isTurnRight = false;
        isMovedUp = false;
        isMovedBack = false;
    }
    public void MoveUpJS()
    {
        isMovedUp = true;
        isMovedBack = false;
        isTurnLeft = false;
        isTurnRight = false;
    }
    public void MoveBackJS()
    {
        isMovedBack = true;
        isTurnLeft = false;
        isTurnRight = false;
        isMovedUp = false;
    }
    public void StopJS()
    {
        isMovedBack = false;
        isTurnLeft = false;
        isTurnRight = false;
        isMovedUp = false;
        isStoped = true;
    }
}
