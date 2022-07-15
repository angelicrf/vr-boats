using UnityEngine;

public class DriverStandAnim : MonoBehaviour
{
    private bool isDrStanding = false;
    private bool isInfoDone = false;
    private bool isBtnStart = false;
    private bool isDrStandSec = false;
    private bool isInputDevices = false;
    public GameObject boatMenu;
    public AudioClip driverStartInfo;
    public AudioClip driverAudioBtn;
    public GameObject driverBtn;
    public GameObject avtCap;
    public GameObject avtSG;
    private void FixedUpdate()
    {

        if (BoatOneStatics.isTeleportCompleted)
        {
            if (avtSG && avtCap)
            {
                DupAvatar.CustomizeAvatar(avtCap, avtSG);
            }
            if (!isDrStanding)
            {
               StartCoroutine(DriverStatics.MoveToWalkTalkAnimCo(gameObject, result => isDrStanding = result,"isStanding"));
            }
            if (isDrStanding && !isInfoDone)
            {
                StartCoroutine(DriverStatics.MoveToWalkTalkAnimCo(gameObject, res => isInfoDone = res, "isStanding", "isWalking", "", driverStartInfo));
                if(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("StartWalking") && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f){
                    gameObject.GetComponent<Animator>().SetBool("isStanding", true);
                    gameObject.GetComponent<Animator>().SetBool("isWalking", false);
                 }
                if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Talking-BriefCase1") && !gameObject.GetComponent<AudioSource>().isPlaying)
                {
                    isDrStandSec = true;
                }
            }
            if (isInfoDone && isDrStandSec)
            {
                StartCoroutine(DriverStatics.MoveToWalkTalkAnimCo(gameObject, res => isBtnStart = res, "isWalking", "isStanding", "isBtnPushed", driverAudioBtn));
            }
            if (isBtnStart)
            {
                // if play directly set it to print
                if (BoatOneStatics.isDrOptionsAuto)
                {
                    gameObject.SetActive(false);
                    driverBtn.SetActive(true);
                }
            }
            if (!isInputDevices)
            {
                isInputDevices = DriverStatics.GetInputDevices();
            }
            if (isInputDevices && boatMenu)
            {
                DriverStatics.ReactivateBoatMenu(boatMenu);
            }
        }
    }
}
