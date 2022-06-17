using System.ComponentModel;
using UnityEngine;

public class TurnOffEngine : MonoBehaviour
{
    public GameObject thisBoat;
    private Rigidbody rd;

    [DefaultValue(false)]
    public static bool isStoped { get; set; }
    //private void Start()
    //{

    //    isStoped = false;
    //    rd = thisBoat.GetComponent<Rigidbody>();
    //}
    //private void FixedUpdate()
    //{
    //    if (isStoped)
    //    {   //add controller input
    //        set velocity
    //        rd.drag = 50f;
    //        isStoped = false;
    //    }

    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            if (thisBoat)
            {
                Debug.Log( "stopHit" + other.tag );
                isStoped = true;
            }
        }
    }
}
