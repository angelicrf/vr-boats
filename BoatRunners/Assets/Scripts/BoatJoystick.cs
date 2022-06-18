using UnityEngine;

public class BoatJoystick : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag( "Hand" ))
        {
            Debug.Log( "handle..." );
        }
    }
}
