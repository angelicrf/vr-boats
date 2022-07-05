using System.Collections;
using UnityEngine;

public class DriverStandAnim : MonoBehaviour
{
    private bool isDrStanding = false;
    private bool isInfoDone = false;
    private bool isNotBlink = false;
    private bool isNowPlaying = false;
    public AudioClip driverStartInfo;
    
    private void FixedUpdate()
    {
       
        if (BoatOneStatics.isBoatTeleported)
        {
            Debug.Log("startAnim");
            if (!isDrStanding)
            {
                StartCoroutine(MoveToStandAnimCo());
            }
            else if (isDrStanding && !isInfoDone)
            {
                StartCoroutine(MoveToWalkdAnimCo());
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
            yield return new WaitForSeconds(1f);
            if (gameObject.GetComponent<AudioSource>().clip.name == "introInfo" && !gameObject.GetComponent<AudioSource>().isPlaying)
            {
                if (!isNowPlaying)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                    if (gameObject.GetComponent<AudioSource>().isPlaying)
                    {
                        yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
                        isNowPlaying = true;
                        isDrStanding = true;
                    }
                }
            }
            yield return null;
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
        if (isNotBlink && gameObject.GetComponent<Animator>().GetBool("isWalking") && !gameObject.GetComponent<Animator>().GetBool("isStanding"))
        {
            if (gameObject.GetComponent<AudioSource>().enabled)
            {
                gameObject.GetComponent<AudioSource>().clip = driverStartInfo;
                gameObject.GetComponent<AudioSource>().Play();
                //yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
                if (gameObject.GetComponent<AudioSource>().isPlaying)
                {
                    isInfoDone = true;
                    yield return null;
                }
            }
        }
    }
}
