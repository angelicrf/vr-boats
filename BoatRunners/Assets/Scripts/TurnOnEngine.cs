using UnityEngine;

public class TurnOnEngine : MonoBehaviour
{
    public GameObject thisBoat;
    private Rigidbody rd;
    private bool isDriving;

    private void Start()
    {
        isDriving = false;
        rd = thisBoat.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (isDriving)
        {   //add controller input
            //set velocity
            rd.drag = 0;
            rd.AddForce( -Vector3.forward , ForceMode.Impulse );
            isDriving = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (thisBoat && rd)
        {
            isDriving = true;
        }
    }
}
