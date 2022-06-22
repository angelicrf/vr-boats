using System.Collections;
using UnityEngine;

public class BoatSeatsOne : MonoBehaviour
{
    public GameObject hand;
    public GameObject player;
    public GameObject parentObj;
    public GameObject thisSeat;
    private Vector3 prevPos;
    private void FixedUpdate()
    {
        if (BoatOneStatics.isSat)
        {
            player.transform.position = thisSeat.transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!BoatOneStatics.isSat && other.CompareTag( "Hand" ))
        {
           BoatOneStatics.isSat = true;
        }
    }
  
}
