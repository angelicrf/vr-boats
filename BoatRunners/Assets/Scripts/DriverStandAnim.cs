using UnityEngine;

public class DriverStandAnim : MonoBehaviour
{
    private bool isDrStanding = false;
    private bool isInfoDone = false;
    private bool isBtnStart = false;
  
    public AudioClip driverStartInfo;
    public AudioClip driverAudioBtn;
    public GameObject driverBtn;
    private void FixedUpdate()
    {
       
        //if (BoatOneStatics.isBoatTeleported)
       // {
            if (!isDrStanding)
            {
               StartCoroutine(DriverStatics.MoveToWalkTalkAnimCo(gameObject, result => isDrStanding = result,"isStanding"));
            }
            if (isDrStanding && !isInfoDone)
            {
                StartCoroutine(DriverStatics.MoveToWalkTalkAnimCo(gameObject, res => isInfoDone = res, "isStanding", "isWalking", "", driverStartInfo));
            }
            if (isInfoDone)
            {
                StartCoroutine(DriverStatics.MoveToWalkTalkAnimCo(gameObject, res => isBtnStart = res, "isWalking", "isStanding", "isBtnPushed", driverAudioBtn));
            }
            if (isBtnStart)
            {
              // if play directly set it to print
                gameObject.SetActive(false);
                driverBtn.SetActive(true);
            }
        //}
    }
}
