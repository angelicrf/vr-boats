using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.XR;

public class DriverAnimController : MonoBehaviour
{
    private bool isResponded = false;
    private bool isAudioChanged = false;
    private bool isClearAudio= false;
    private bool isAskAudio = false;
    private bool isDriveAudio = false;
    private bool isYesToDrive;
    private bool isTest = false;
    private bool isSetUp = false;
 
    private bool isInputDevices = false;
    [DefaultValue(false)]
    private bool isDrStarted { get; set; }
    [DefaultValue(false)]
    private bool isPlayed { get; set; }
    public GameObject boatMenu;
    public AudioClip greetingDialog;
    public AudioClip askgDialog;
    public AudioClip clearDialog;
    public AudioClip driveDialog;
    public GameObject thisCell;
    public GameObject driverDr;
    public GameObject avtCap;
    public GameObject avtSG;
    public GameObject avtShoes;
    public GameObject avtShirts;
    public GameObject avtShorts;
    public List<Material> shoesMts;
    public List<Material> shortsMts;
    public List<Material> shirtsMts;
    private void Start()
    {
        if (BoatOneStatics.isDrOptionsAuto)
        {
            if (shoesMts.Count > 0 && shirtsMts.Count > 0 && shirtsMts.Count > 0)
            {
                DupAvatar.dupMTShorts = shortsMts;
                DupAvatar.dupMTShirts = shirtsMts;
                DupAvatar.dupMTShoes = shoesMts;
            }
        }
    }
    void FixedUpdate()
    {
        if (BoatOneStatics.isTeleportCompleted)
        {
            if (BoatOneStatics.isDrOptionsAuto)
            {
                if (avtSG && avtCap && avtShirts && avtShoes && avtShorts)
                {
                    DupAvatar.CustomizeAvatar(avtCap, avtSG, avtShorts, avtShirts, avtShoes);
                }
            }
            if (!isSetUp)
            {
                //customize avatar
                StartCoroutine(DriverStatics.RunAnimCo(gameObject, "isStandOnCell", res => isSetUp = res));
            }

            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Stand-TalkingCell"))
            {
                if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !gameObject.GetComponent<Animator>().IsInTransition(0))
                {
                    if (thisCell)
                    {
                        thisCell.SetActive(false);
                        gameObject.GetComponent<Animator>().SetBool("isStandOnCell", false);
                        gameObject.GetComponent<Animator>().SetBool("isTalking", true);
                    }
                }
            }
            if (!isAudioChanged)
            {
                if (gameObject.GetComponent<Animator>().GetBool("isTalking") && !gameObject.GetComponent<Animator>().GetBool("isStandOnCell"))
                {
                    if (greetingDialog)
                    {
                        StartCoroutine(PlayAudioClip(greetingDialog));
                        if (isPlayed)
                        {
                            isAudioChanged = true;
                            isPlayed = false;
                        }
                    }
                }
            }
            if (isAudioChanged && !isResponded)
            {
                StartCoroutine(PlayAudioPause());
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
                        DriverStatics.RepeatSpeechNoticeCo(gameObject, clearDialog, res => isClearAudio = res);
                    }
                }
                if (isDrStarted)
                {
                    if (BoatOneStatics.isDrOptionsAuto)
                    {
                        driverDr.SetActive(true);
                        gameObject.SetActive(false);
                    }
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
    private IEnumerator RepeatSpeech2Co()
    {
        if (BoatOneStatics.speechText.Split(' ')[0].ToString() != "yes")
        {
            DriverStatics.RepeatSpeechNoticeCo(gameObject,askgDialog,res => isAskAudio = res);
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
                        if (!isTest && gameObject.GetComponent<AudioSource>().clip == driveDialog && !gameObject.GetComponent<AudioSource>().isPlaying)
                        {
                            yield return new WaitForSeconds(3f);
                            gameObject.GetComponent<Animator>().Play("Talking", -1, 0f);
                            gameObject.GetComponent<AudioSource>().Play();
                            isTest = true;
                        }
                        if (!gameObject.GetComponent<AudioSource>().isPlaying && isTest) {
                            isYesToDrive = true;
                            isDrStarted = true;
                            yield return null;
                        }
                    }
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
                gameObject.GetComponent<AudioSource>().Play();
                
                //if (gameObject.GetComponent<AudioSource>().isPlaying)
                //{
                //    yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
                //    isPlayed = true;
                //}
                if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !gameObject.GetComponent<Animator>().IsInTransition(0))
                {
                   yield return new WaitForSeconds(3.577f);
                   isPlayed = true;
                }
            }
        }
        yield return null;
    }
    private IEnumerator PlayAudioPause()
    {
        yield return new WaitForSeconds(5f);
        isResponded = true;
    }
}
