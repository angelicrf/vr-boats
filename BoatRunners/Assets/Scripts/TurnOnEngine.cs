using UnityEngine;

public class TurnOnEngine : MonoBehaviour
{
    public GameObject thisBoat;
    private Rigidbody rd;
    private bool isDriving;
    private float speed;
    private int count;
    //private TurnOffEngine turnOffEngine;
    private void Start()
    {
        //turnOffEngine = FindObjectOfType<TurnOffEngine>();
        Debug.Log( "valueTurnOff" + TurnOffEngine.isStoped );
        isDriving = false;
        count = 0;
        speed = 1f;
        rd = thisBoat.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (isDriving)
        {   //add controller input
            //set velocity
            //rd.drag = 0;
            //rd.AddForce( -Vector3.forward , ForceMode.Impulse );         
            if (!TurnOffEngine.isStoped)
               {
               thisBoat.transform.position += thisBoat.transform.forward * Time.deltaTime * speed;
            }
        }
            //isDriving = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag( "Hand" ))
        {
            if (thisBoat && rd)
            {
                isDriving = true;
            }
        }
    }
}
