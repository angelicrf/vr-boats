using System.Collections;
using UnityEngine;

public class TurnOnEngine : MonoBehaviour
{
    public GameObject thisBoat;
    public GameObject windmill;
    private bool isDriving;
    private float speed;
    private Vector3 playerPos;
    private void Start()
    {
        isDriving = false;
        speed = 1f;
    }
    private void FixedUpdate()
    {
        if (isDriving)
        {         
            if (!BoatOneStatics.isStoped && windmill && BoatOneStatics.isSat)
               {
                StartCoroutine( RunEngingCo() );       
            }
        }
    }
    private IEnumerator RunEngingCo()
    {
        //thisPlayer.transform.parent = thisBoat.transform;
        windmill.transform.RotateAround( windmill.transform.position , windmill.transform.forward , Random.Range( 0 , 360 ) );
        //yield return new WaitForSeconds( 3f );
        //thisBoat.transform.position += thisBoat.transform.forward * Time.deltaTime * speed;
        yield return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log( "start" );
        if (other.CompareTag( "Hand" ))
        {
            if (thisBoat)
            {
                isDriving = true;
            }
        }
    }
}
