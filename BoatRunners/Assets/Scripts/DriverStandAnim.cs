using System.Collections;
using UnityEngine;

public class DriverStandAnim : MonoBehaviour
{
    private bool isDrStanding = false;
    private bool isInfoDone = false;
    private bool isNotBlink = false;
    private bool isNotBlink2 = false;
    private bool isNowPlaying = false;
    private bool isNowPlaying2 = false;
    private bool isNowPlaying3 = false;
    private bool isBtnStart = false;
    public AudioClip driverStartInfo;
    public AudioClip driverAudioBtn;
    public GameObject driverBtn;
    private void FixedUpdate()
    {
       
        if (BoatOneStatics.isBoatTeleported)
        {
            if (!isDrStanding)
            {
                StartCoroutine(MoveToStandAnimCo());
            }
            else if (isDrStanding && !isInfoDone)
            {
                StartCoroutine(MoveToWalkdAnimCo());
            }
            if (isInfoDone)
            {
                StartCoroutine(MoveToTalkAnimCo());
            }
            if (isBtnStart)
            {
                gameObject.SetActive(false);
                driverBtn.SetActive(true);
            }
        }
    }

    private IEnumerator MoveToStandAnimCo()
    {
        if (!gameObject.GetComponent<AudioSource>().enabled || !gameObject.GetComponent<Animator>().enabled)
        {
            gameObject.GetComponent<AudioSource>().enabled = true;
            gameObject.GetComponent<Animator>().enabled = true;
        }
        if (gameObject.GetComponent<AudioSource>().enabled && gameObject.GetComponent<Animator>().enabled)
        {
            gameObject.GetComponent<Animator>().SetBool("isStanding", true);
            if (gameObject.GetComponent<AudioSource>().clip.name == "introInfo" && !gameObject.GetComponent<AudioSource>().isPlaying && !isNowPlaying)
            {
                if (!isNowPlaying)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                    isNowPlaying = true;
                }  
            }
            if (isNowPlaying)
            {
                yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
                Debug.Log("moveStart...");
                isDrStanding = true;
                yield return null;
            }
        }
    }
    private IEnumerator MoveToWalkdAnimCo()
    {
       
        if (!isNotBlink)
        {
            gameObject.GetComponent<Animator>().SetBool("isStanding", false);
            gameObject.GetComponent<Animator>().SetBool("isWalking", true);
            isNotBlink = true;
        }
        yield return new WaitForSeconds(2f);
        if (isNotBlink && gameObject.GetComponent<Animator>().GetBool("isWalking") && !gameObject.GetComponent<Animator>().GetBool("isStanding") && !isNowPlaying2)
        {
          if (!isNowPlaying2)
                {
                    gameObject.GetComponent<AudioSource>().clip = driverStartInfo;
                    gameObject.GetComponent<AudioSource>().Play();
                    isNowPlaying2 = true;
                }
        }
        if (isNowPlaying2)
        {
            yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
            Debug.Log("moveStart2...");
            isInfoDone = true;
            yield return null;
        }
    }
    private IEnumerator MoveToTalkAnimCo()
    {
        if (!isNotBlink2)
        {
            gameObject.GetComponent<Animator>().SetBool("isWalking", false);
            gameObject.GetComponent<Animator>().SetBool("isStanding", true);
            gameObject.GetComponent<Animator>().SetBool("isBtnPushed", true);
            isNotBlink2 = true;
        }
        yield return new WaitForSeconds(2f);
        if (isNotBlink2 && gameObject.GetComponent<Animator>().GetBool("isBtnPushed") && gameObject.GetComponent<Animator>().GetBool("isStanding") && !gameObject.GetComponent<Animator>().GetBool("isWalking") && !isNowPlaying3)
        {
            if (!isNowPlaying3)
            {
                gameObject.GetComponent<AudioSource>().clip = driverAudioBtn;
                gameObject.GetComponent<AudioSource>().Play();
                isNowPlaying3 = true;
            }
        }
        if (isNowPlaying3)
        {
            yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
            isBtnStart = true;
            yield return null;
        }
    }
}
