using UnityEngine;

public class DriverAnimController : MonoBehaviour
{
    private bool isResponded = false;
    private bool isAudioChanged = false;
    public AudioClip greetingDialog;
    
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
                    //gameObject.GetComponent<Animator>().StartPlayback();
                    gameObject.GetComponent<AudioSource>().Play();
                    gameObject.GetComponent<AudioSource>().volume = 1f;
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
                gameObject.GetComponent<Animator>().SetBool("isTalking", true);
            }
        }
        if (!isAudioChanged)
        {
            if (gameObject.GetComponent<Animator>().GetBool("isTalking"))
            {
            
                if (greetingDialog)
                {
                    gameObject.GetComponent<AudioSource>().clip = greetingDialog;
                    gameObject.GetComponent<AudioSource>().Play();
                    gameObject.GetComponent<AudioSource>().volume = 1f;
                    isAudioChanged = true;
                    isResponded = true;
                }
            }
        }
        if (BoatOneStatics.isSpeechDone)
        {
            if (isResponded)
            {
                if (BoatOneStatics.speechText.Split(' ')[0] == "yes" || BoatOneStatics.speechText.Split(' ')[0] == "ya")
                {
                    // run a driving animation
                    Debug.Log("letsDrive...");
                }
            }
        }
    }
}
