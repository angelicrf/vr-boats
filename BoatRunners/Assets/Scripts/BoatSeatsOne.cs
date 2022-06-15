using System.Collections;
using UnityEngine;

public class BoatSeatsOne : MonoBehaviour
{
    public GameObject hand;
    public GameObject player;
    private bool isSat = false;
    private bool isChangedPos = false;
    private Vector3 seatPos;
    private Quaternion seatRot;
    private void Start()
    {
        seatRot = Quaternion.Euler( player.transform.rotation.x, player.transform.rotation.y + 180f , player.transform.rotation.z);
    }
    private void FixedUpdate()
    {
        if (isSat)
        {
            seatPos = new Vector3( gameObject.transform.position.x - 0.15f , gameObject.transform.position.y - 0.3f , transform.position.z - 0.35f );

            player.transform.position = seatPos;
            player.transform.rotation = seatRot;
            //isSat = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isSat && other.CompareTag( "Hand" ))
        {
            isSat = true;
        }
    }
    IEnumerator SeatConditionCo()
    {
        player.transform.position = new Vector3( gameObject.transform.position.x , gameObject.transform.position.y - 0.5f , transform.position.z - 0.3f );    
        yield return new WaitForSeconds( 2f );
        Destroy( gameObject );
        isSat = false;
    }
  
}
