using UnityEngine;

public class DriverAnimController : MonoBehaviour
{
    public AudioClip greetingDialog;
    void FixedUpdate()
    {
        //Hey, Welcome to the show, Luckily the weather is on our side today, how may I help you?
        if (BoatOneStatics.isBoatTeleported)
        {
            if (!gameObject.GetComponent<AudioSource>().enabled)
            {
                gameObject.GetComponent<AudioSource>().enabled = true;
                if (gameObject.GetComponent<AudioSource>().enabled)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                    gameObject.GetComponent<AudioSource>().volume = 1f;
                }
            }
        }

        //if (BoatOneStatics.isSpeechDone)
        //{
          
        //}
    }
}
