using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class DriverAnimController : MonoBehaviour
{
    private bool isResponded = false;
    private bool isRepeated = false;
    private bool isAudioChanged = false;
    private bool isClearAudio= false;
    private bool isAskAudio = false;
    private bool isDriveAudio = false;
    private bool isYesToDrive;
    private bool isLastStep = false;
    [DefaultValue(false)]
    private bool isDrStarted { get; set; }
    [DefaultValue(false)]
    private bool isPlayed { get; set; }
    public AudioClip greetingDialog;
    public AudioClip askgDialog;
    public AudioClip clearDialog;
    public AudioClip driveDialog;
    public GameObject thisCell;
    public GameObject driverDr;
    void FixedUpdate() 
    {
        if (BoatOneStatics.isBoatTeleported)
        {
            if (!gameObject.GetComponent<AudioSource>().enabled && !gameObject.GetComponent<Animator>().enabled)
            {
                gameObject.GetComponent<Animator>().enabled = true;
                gameObject.GetComponent<AudioSource>().enabled = true;
                if (gameObject.GetComponent<AudioSource>().enabled && gameObject.GetComponent<Animator>().enabled)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                }
            }
        }
        //else
        //{
        //    if (gameObject.GetComponent<AudioSource>().enabled)
        //    {
        //        gameObject.GetComponent<AudioSource>().enabled = false;
        //    }
        //}
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Stand-TalkingCell"))
        {
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !gameObject.GetComponent<Animator>().IsInTransition(0))
            {
                if (thisCell)
                {
                    thisCell.SetActive(false);
                    gameObject.GetComponent<Animator>().SetBool("isTalking", true);
                }
            }
        }
        if (!isAudioChanged)
        {
            if (gameObject.GetComponent<Animator>().GetBool("isTalking"))
            {
                if (greetingDialog)
                {
                   StartCoroutine( PlayAudioClip(greetingDialog));
                    if (isPlayed)
                    {
                        isAudioChanged = true;
                        isResponded = true;
                        isPlayed = false;
                    }
                }
            }
        }
        if (isResponded)
        {
            if (BoatOneStatics.isSpeechDone)
            {
                if (!isDrStarted)
                {
                    StartCoroutine(RepeatSpeech2Co());
                }
                // more speech actions then isResponded = false
            }
            else 
            {
                if (!isDrStarted)
                {
                    StartCoroutine(RepeatSpeech2NoticeCo());
                }
            }
            if (isDrStarted)
            {
                driverDr.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
    private IEnumerator RepeatSpeech2Co()
    {
        if (BoatOneStatics.speechText.Split(' ')[0].ToString() != "yes")
        {
            if (askgDialog)
            {
                if (!isAskAudio)
                {
                    if (gameObject.GetComponent<AudioSource>().clip != askgDialog)
                    {
                        gameObject.GetComponent<AudioSource>().clip = askgDialog;
                    }
                    if (isPlayed)
                    {
                        isPlayed = false;
                    }
                    if (!isPlayed && gameObject.GetComponent<AudioSource>().clip == askgDialog)
                    {
                        isAskAudio = true;
                    }
                }
                else
                {
                    if (gameObject.GetComponent<AudioSource>().clip == askgDialog && !gameObject.GetComponent<AudioSource>().isPlaying)
                    {
                       yield return new WaitForSeconds(6f);
                        isRepeated = true;
                        gameObject.GetComponent<Animator>().Play("Talking", -1, 0f);
                        gameObject.GetComponent<AudioSource>().Play();

                       yield return null;
                    }
                }
            }
        }
        else 
        if (BoatOneStatics.speechText.Split(' ')[0].ToString() == "yes")
        {
            if (!isDriveAudio)
            {
                if (gameObject.GetComponent<AudioSource>().clip != driveDialog)
                {
                    gameObject.GetComponent<AudioSource>().clip = driveDialog;
                }
                if (isPlayed)
                {
                    isPlayed = false;
                }
                if (!isPlayed && gameObject.GetComponent<AudioSource>().clip == driveDialog)
                {
                    isDriveAudio = true;
                }
            }
            else
            {
                if (driveDialog)
                {
                    if (!isYesToDrive && !isDrStarted)
                    {
                        yield return new WaitForSeconds(3f);
                       
                        if (gameObject.GetComponent<AudioSource>().clip == driveDialog && !gameObject.GetComponent<AudioSource>().isPlaying)
                        {
                            gameObject.GetComponent<Animator>().Play("Talking", -1, 0f);
                            gameObject.GetComponent<AudioSource>().Play();
                            if (!isRepeated)
                            {
                                yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
                            }
                            isYesToDrive = true;
                            isDrStarted = true;
                            yield return null;
                        }
                    }
                 }
             }
        }
    }
    private IEnumerator RepeatSpeech2NoticeCo()
    {
        if (clearDialog)
        {
            if (!isClearAudio)
            {
                if (gameObject.GetComponent<AudioSource>().clip != clearDialog)
                {
                    gameObject.GetComponent<AudioSource>().clip = clearDialog;
                }
                if (isPlayed)
                {
                    isPlayed = false;
                }
                if (!isPlayed && gameObject.GetComponent<AudioSource>().clip == clearDialog)
                {
                    isClearAudio = true;
                }
            }
            else
            {
                if (gameObject.GetComponent<AudioSource>().clip == clearDialog && !gameObject.GetComponent<AudioSource>().isPlaying)
                {
                   yield return new WaitForSeconds(6f);
                    isRepeated = true;
                    gameObject.GetComponent<Animator>().Play("Talking", -1, 0f);
                    gameObject.GetComponent<AudioSource>().Play();
                   yield return null;
                }
            }
        }
    }
    private IEnumerator PlayAudioClip(AudioClip thisClip)
    {
        if (gameObject.GetComponent<AudioSource>().clip != thisClip)
        {
            gameObject.GetComponent<AudioSource>().clip = thisClip;
           
        }
        if (gameObject.GetComponent<AudioSource>().clip == thisClip && !gameObject.GetComponent<AudioSource>().isPlaying)
        {
            if (!isPlayed)
            {
                if (isLastStep)
                {
                   gameObject.GetComponent<Animator>().Play("Talking", -1, 0f);
                }
                gameObject.GetComponent<AudioSource>().Play();
                if (gameObject.GetComponent<AudioSource>().isPlaying)
                {
                    yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
                    if (isLastStep)
                    {
                        isYesToDrive = true;
                        isDrStarted = true;
                        isLastStep = false;
                    }
                    isPlayed = true;
                }
            }
        }
        yield return null;
    }
}
