using System.Collections;
using UnityEngine;

public class BoatSeatsOne : MonoBehaviour
{
    public GameObject hand;
    public GameObject player;
    public GameObject parentObj;
    private void FixedUpdate()
    {
        if (BoatOneStatics.isSat)
        {
            player.transform.parent = parentObj.transform;
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
