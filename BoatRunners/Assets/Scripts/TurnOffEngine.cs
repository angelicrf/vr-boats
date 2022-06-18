using System.ComponentModel;
using UnityEngine;

public class TurnOffEngine : MonoBehaviour
{
    public GameObject thisBoat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            if (thisBoat)
            {
                Debug.Log( "stoped" );
                BoatOneStatics.isStoped = true;
            }
        }
    }
}
