using System.Collections;
using UnityEngine;

public class DriverBtnPushAnim : MonoBehaviour
{
    private bool isStartedBtn = false;
    private bool isActivatedBtn = false;
    private bool isPlaying = false;
    private bool isPlaying2 = false;
    private bool isLightsOn = false;
    private bool isNextStep = false;
    private bool isFirstStep = false;
    private bool isAnimOnce = false;
    //public AudioClip activateDisplay;
    public AudioClip lightSystem;
    void FixedUpdate()
    {
        if (BoatOneStatics.isBoatTeleported)
        {
            if (!isStartedBtn)
            {
                StartCoroutine(DriverBTNCo());
            }
            if (isActivatedBtn)
            {
                StartCoroutine(DriverActivateDisplayCo());
            }
            //if (isLightsOn)
            //{
            //    StartCoroutine(DriverLightsCo());
            //}
            //if (isNextStep)
            //{
            //    Debug.Log("lastTry...");
            //}
        }
    }
    private IEnumerator DriverBTNCo()
    {
        DriverStatics.EnableAnimatorAudio(gameObject);
        if (!isStartedBtn)
        {
            if (gameObject.GetComponent<AudioSource>().enabled && gameObject.GetComponent<Animator>().enabled)
            {
                gameObject.GetComponent<AudioSource>().Play();
                gameObject.GetComponent<Animator>().speed = 0;
                gameObject.GetComponent<Animator>().SetBool("isBtnPushed", true);
                isStartedBtn = true;
            }
        }
        if (isStartedBtn )
        {
            if (!isFirstStep)
            {
                yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
                gameObject.GetComponent<Animator>().speed = 1;
                gameObject.GetComponent<Animator>().Play("BtnPushing", -1, 0f);
                isFirstStep = true;
            }
            if(isFirstStep)
            //&& gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !gameObject.GetComponent<Animator>().IsInTransition(0))
            {
                isActivatedBtn = true;
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
        if (isPlaying)
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
                if (isAnimOnce)
                {
                    yield return new WaitForSeconds(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                    isLightsOn = true;
                }
            }
        }
    }
    //private IEnumerator DriverLightsCo()
    //{
    //    if (!isPlaying2)
    //    {
    //        yield return new WaitForSeconds(2f);
    //        gameObject.GetComponent<Animator>().Play("BtnPushing", -1, 0f);
    //        gameObject.GetComponent<AudioSource>().clip = lightSystem;
    //        gameObject.GetComponent<AudioSource>().Play();
    //        isPlaying2 = true;
    //    }
    //    if (isPlaying2)
    //    {
    //        yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
    //        isNextStep = true;
    //    }
    //}
}
