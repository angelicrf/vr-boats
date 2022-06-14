using System.Collections;
using UnityEngine;

public class BoatSeatsOne : MonoBehaviour
{
    public GameObject hand;
    public GameObject player;
    private bool isSat = false;
    private bool isChangedPos = false;
    private Vector3 seatPos;

    private void FixedUpdate()
    {
        seatPos = new Vector3( gameObject.transform.position.x , gameObject.transform.position.y - 0.6f , transform.position.z - 0.7f );
        //if (isSat)
        //{
        //player.transform.parent = gameObject.transform;
        player.transform.position = seatPos;
            //isSat = false;
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (!isSat)
        //{
            player.transform.position = gameObject.transform.position;
           isSat = true;
       // }
    }
    IEnumerator SeatConditionCo()
    {
        player.transform.position = new Vector3( gameObject.transform.position.x , gameObject.transform.position.y - 0.5f , transform.position.z - 0.3f );    
        yield return new WaitForSeconds( 2f );
        Destroy( gameObject );
        isSat = false;
    }
  
}
