using UnityEngine;

public class TurnOnEngine : MonoBehaviour
{
    public GameObject thisBoat;

    private bool isDriving;
    private float speed;

    private void Start()
    {
        isDriving = false;
        speed = 1f;
    }
    private void FixedUpdate()
    {
        if (isDriving)
        {         
            if (!TurnOffEngine.isStoped)
               {
               thisBoat.transform.position += thisBoat.transform.forward * Time.deltaTime * speed;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag( "Hand" ))
        {
            if (thisBoat)
            {
                isDriving = true;
            }
        }
    }
}
