using UnityEngine;

public class BoatSeatsOne : MonoBehaviour
{
    public GameObject hand;
    public GameObject player;
    private Vector3 playerOrigPos;

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log( other.tag );
        //if (other.CompareTag( "Hand" ))
        //{
        //playerOrigPos = player.transform.position;
            Debug.Log( "seatCollider" );
            player.transform.position = new Vector3( transform.position.x , player.transform.position.y - 0.4f , transform.position.z );
        //}
    }
  
}
