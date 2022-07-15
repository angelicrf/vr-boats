using System.Collections;
using UnityEngine;

public class DriverBtnPushAnim : MonoBehaviour
{
    private bool isStartedBtn = false;
    private bool isBgStep = false;
    private bool isActivatedBtn = false;
    private bool isPlaying = false;
    private bool isLightsOn = false;
    private bool isLightsTurnOn = false;
    private bool isNextStep = false;
    private bool isFirstStep = false;
    private bool isAnimOnce = false;
    private bool isInputDevices = false;
    public GameObject boatMenu;
    public GameObject avtCap;
    public GameObject avtSG;
    public AudioClip lightSystem;
    void FixedUpdate()
    {
       if (BoatOneStatics.isTeleportCompleted)
       {
            if (avtSG && avtCap)
            {
                DupAvatar.CustomizeAvatar(avtCap, avtSG);
            }
            if (!isStartedBtn)
            {
                StartCoroutine(DriverBTNCo());
            }
            else if (isActivatedBtn && !isLightsOn)
            {
                StartCoroutine(DriverActivateDisplayCo());
            }
            else if (isLightsOn && !isLightsTurnOn)
            {
                StartCoroutine(DriverLightOnDisplayCo());
            }
            if (isLightsTurnOn)
            {
                isAnimOnce = false;
            }

            if (isStartedBtn || isLightsOn || isLightsTurnOn)
            {
                DefineBoatState(DriverStatics.boatNames);
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
    private void DefineBoatState(DriverStatics.allBoats op)
    { 
        if (!BoatOneStatics.isDriverAsked)
        {
            BoatOneStatics.isDriverAsked = true;
        }
            switch (op)
            {
                case DriverStatics.allBoats.boatOne:
                    if (isLightsOn && isActivatedBtn)
                    {
                        BoatOneStatics.isSystemLightsOn = true;
                    }
                    if (isLightsOn && isActivatedBtn && isLightsTurnOn)
                    {
                        BoatOneStatics.isDrLightsOn = true;
                    }
                    if (isActivatedBtn && !isLightsOn)
                    {
                        BoatOneStatics.isMenuActivated = true;
                    }
                   break;

                case DriverStatics.allBoats.boatTwo:
                    if (isLightsOn)
                    {
                        Debug.Log("in Boat two");
                        //BoatTwoStatics.isSystemLightsOn = true;
                    }
                    else
                    {
                        Debug.Log("in Boat two");
                        //BoatTwoStatics.isSystemLightsOff= false;
                    }
                    if (isActivatedBtn)
                    {
                        Debug.Log("in Boat two");
                        // boatTwoStatic
                    }
                break;

               default:
                   break;
            }
            //return isThisBoat;   
    }
    private IEnumerator DriverBTNCo()
    {
        DriverStatics.EnableAnimatorAudio(gameObject);
        if (!isBgStep)
        {
            if (gameObject.GetComponent<AudioSource>().enabled && gameObject.GetComponent<Animator>().enabled)
            {
                gameObject.GetComponent<AudioSource>().Play();
                gameObject.GetComponent<Animator>().speed = 0;
                gameObject.GetComponent<Animator>().SetBool("isBtnPushed", true);
                isBgStep = true;
            }
        }
        if (isBgStep && !gameObject.GetComponent<AudioSource>().isPlaying)
        {
            if (!isFirstStep)
            {
                gameObject.GetComponent<Animator>().speed = 1;
                gameObject.GetComponent<Animator>().Play("BtnPushing", -1, 0f);
                isFirstStep = true;
                
            }
            if (isFirstStep && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !gameObject.GetComponent<Animator>().IsInTransition(0))
            {
                isStartedBtn = true;
                isActivatedBtn = true;
                yield return null;
            }
        }
        
    }
    private IEnumerator DriverActivateDisplayCo()
    {
        if (!isPlaying)
        {
            yield return new WaitForSeconds(3f);
            gameObject.GetComponent<AudioSource>().clip = lightSystem;
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().speed = 1f;
            isPlaying = true;
        }
        if (isPlaying && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !gameObject.GetComponent<Animator>().IsInTransition(0))
        {
            if (!isNextStep)
            {
                yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length + 3f);
                isNextStep = true;
            }
            if (isNextStep)
            {
                if (!isAnimOnce)
                {
                    gameObject.GetComponent<Animator>().Play("BtnPushing", -1, 0f);
                    isAnimOnce = true;
                }
            }
        }
        if (isAnimOnce && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !gameObject.GetComponent<Animator>().IsInTransition(0) && !isLightsOn)
        {
            yield return new WaitForSeconds(3f);
            isAnimOnce = false;
            isLightsOn = true;
            yield return null;
        }
    }
    private IEnumerator DriverLightOnDisplayCo()
    {
        if (!isAnimOnce && !isLightsTurnOn)
         {
            gameObject.GetComponent<Animator>().Play("BtnPushing", -1, 0f);
            isAnimOnce = true;
         }
        
        if (isAnimOnce && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !gameObject.GetComponent<Animator>().IsInTransition(0))
        {
            isLightsTurnOn = true;
            yield return null;
        }
    }
}
