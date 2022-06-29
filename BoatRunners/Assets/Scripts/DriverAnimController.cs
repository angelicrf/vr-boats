using UnityEngine;

public class DriverAnimController : MonoBehaviour
{
    public Animator driverAnim;
    void FixedUpdate()
    {
        if (BoatOneStatics.isSpeechDone)
        {
            driverAnim.SetBool("isSitidle", true);
        }
    }
}
