using UnityEngine;

public class BoatJoystick : MonoBehaviour
{
    public GameObject thisJS;
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
}
