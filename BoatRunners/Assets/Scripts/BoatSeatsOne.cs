using System.Collections;
using UnityEngine;

public class BoatSeatsOne : MonoBehaviour
{
    public GameObject hand;
    public GameObject player;
    public GameObject parentObj;
    private bool isChangedPos = false;
    private Vector3 seatPos;
    private Quaternion seatRot;

    private void Start()
    {
        seatRot = Quaternion.Euler( player.transform.rotation.x, player.transform.rotation.y + 180f , player.transform.rotation.z);
    }
    private void FixedUpdate()
    {
        if (BoatOneStatics.isSat)
        {
            seatPos = new Vector3( gameObject.transform.position.x + 0.5f , gameObject.transform.position.y - 0.6f , transform.position.z - 1f );
            player.transform.position = seatPos;
            player.transform.rotation = seatRot;
            //player.isStatic = true;
            //player.transform.parent = parentObj.transform;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!BoatOneStatics.isSat && other.CompareTag( "Hand" ))
        {
            Debug.Log( "sat" );
           BoatOneStatics.isSat = true;
        }
    }
    IEnumerator SeatConditionCo()
    {
        player.transform.position = new Vector3( gameObject.transform.position.x , gameObject.transform.position.y - 0.5f , transform.position.z - 0.3f );    
        yield return new WaitForSeconds( 2f );
        Destroy( gameObject );
        BoatOneStatics.isSat = false;
    }
  
}
