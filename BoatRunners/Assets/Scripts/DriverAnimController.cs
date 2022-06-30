using UnityEngine;

public class DriverAnimController : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<Animator>().SetBool("isSitidle", true);
    }
    //void FixedUpdate()
    //{

    //    if (BoatOneStatics.isSpeechDone)
    //    {
    //        other funstionality
    //    }
    //}
}
