using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.XR;

public static class DriverStatics {
  
    private static bool ReturnValue = false;
    private static bool ReturnFirstValue = false;
    private static bool ReturnSecondValue = false;
    private static bool isEnabed = false;
    private static bool isRun = false;
    public static bool isThisBoat = false;
    private static bool isTest = false;
    public static allBoats boatNames;
    [DefaultValue(false)]
    public static bool isInputList{get;set;}
    private static bool primaryBtnValue = false;
    private static List<InputDevice> inputDevices = new List<InputDevice>();
    public enum allBoats { boatOne, boatTwo};

    public static void EnableAnimatorAudio(GameObject thisObj)
    {
        if (!thisObj.GetComponent<AudioSource>().enabled || !thisObj.GetComponent<Animator>().enabled)
        {
            thisObj.GetComponent<AudioSource>().enabled = true;
            thisObj.GetComponent<Animator>().enabled = true;
        }
    }
    public static IEnumerator MoveToDriveAnimCo(GameObject thisObj, string thisBool, Action<bool> thisBoatStatic)
    {
        if (!thisObj.GetComponent<Animator>().enabled)
        {
            thisObj.GetComponent<Animator>().enabled = true;
            yield return new WaitForSeconds(2f);
            if (thisObj.GetComponent<Animator>().enabled)
            {
                thisObj.GetComponent<Animator>().SetBool(thisBool, true);
                yield return new WaitForSeconds(12f);
                thisBoatStatic(true);
            }
        }
    }
    public static void EndLoopAnime(GameObject thisObj)
    {
        thisObj.GetComponent<Animator>().enabled = false;
    }
    public static IEnumerator MoveDriveToWalkAnimCo(GameObject thisObj, GameObject otherObj)
    {
        if (otherObj)
        {
            //thisObj.GetComponent<Animator>().runtimeAnimatorController.animationClips[0].wrapMode = WrapMode.Once;
            thisObj.GetComponent<Animator>().enabled = false;
            yield return new WaitForSeconds(2f);
            thisObj.SetActive(false);
            otherObj.SetActive(true);
        }
    }
    public static IEnumerator RunAnimCo(GameObject thisObj,string setBool, Action<bool> isNext, AudioClip thisClip = null, string clipName = null)
    {
        if (!isRun)
        {
            EnableAnimatorAudio(thisObj);
            if (thisObj.GetComponent<AudioSource>().enabled && thisObj.GetComponent<Animator>().enabled && !ReturnValue)
            {
                thisObj.GetComponent<Animator>().SetBool(setBool, true);
                SetAudio(thisObj, thisClip, ref isRun);
            }
        }
        if (isRun)
        {
            yield return new WaitForSeconds(thisObj.GetComponent<AudioSource>().clip.length);
            isNext(true);
            isRun = false;
            yield return null;
        }
    }

    public static IEnumerator MoveToWalkTalkAnimCo(GameObject thisObj, Action< bool> nextBool,string firstState, string secondState = "", string thirdState = "", AudioClip thisClip = null)
    {
        if (!isEnabed)
        {
            EnableAnimatorAudio(thisObj);
            isEnabed = true;
        }
 
        if (thisObj.GetComponent<AudioSource>().enabled && thisObj.GetComponent<Animator>().enabled && !ReturnValue)
        { 
            ChangeAnimState(thisObj, firstState, ref ReturnFirstValue, secondState, thirdState);
            yield return new WaitForSeconds(2f);
            if (ReturnFirstValue && thisObj.GetComponent<Animator>().GetBool(firstState) && secondState == "" && thirdState == "" && !ReturnSecondValue)
            {
                SetAudio(thisObj, thisClip, ref ReturnSecondValue);
            }
            else if (ReturnFirstValue && secondState != "" && thisObj.GetComponent<Animator>().GetBool(secondState) && !thisObj.GetComponent<Animator>().GetBool(firstState) && thirdState == "" && !ReturnSecondValue)
            {
                SetAudio(thisObj, thisClip, ref ReturnSecondValue);
            }

            else if (ReturnFirstValue && firstState != "" && secondState != "" && thirdState != "" && thisObj.GetComponent<Animator>().GetBool(secondState) && thisObj.GetComponent<Animator>().GetBool(thirdState) && !thisObj.GetComponent<Animator>().GetBool(firstState) && !ReturnSecondValue)
            {
                SetAudio(thisObj, thisClip, ref ReturnSecondValue);
            }
        }
        if (ReturnSecondValue && !thisObj.GetComponent<AudioSource>().isPlaying)
        {
            nextBool(true);
            ResetValues();
            yield return null;
        }
    }
    public static void RepeatSpeechNoticeCo(GameObject thisObj, AudioClip thisClip, Action<bool> isNextStep)
    {
        if (thisClip)
        {
            if (!isRun)
            {
                SetAudio(thisObj, thisClip, ref isRun);
            }
            else
            {
                RepeatAnim(thisObj,thisClip,"Talking");
            }
        }
    }
    private static IEnumerator RepeatAnim(GameObject thisObj, AudioClip thisClip, string animState)
    {
        if (thisObj.GetComponent<AudioSource>().clip == thisClip && !thisObj.GetComponent<AudioSource>().isPlaying)
        {
            yield return new WaitForSeconds(6f);
            thisObj.GetComponent<Animator>().Play(animState, -1, 0f);
            thisObj.GetComponent<AudioSource>().Play();
            yield return null;
        }
    }
    private static void ResetValues()
    {
        if (ReturnFirstValue)
        {
            ReturnFirstValue = false;
        }
        if (ReturnSecondValue)
        {
            ReturnSecondValue = false;
        }
    }
    private static void ChangeAnimState(GameObject thisObj, string firstState, ref bool thisBool, string secondState = "", string thirdState = "")
    {
        
        if (!thisBool)
        {
            if (secondState == "" && thirdState == "" && firstState != "")
            {
                thisObj.GetComponent<Animator>().SetBool(firstState, true);
            }
            else if (secondState != "" && thirdState == "" && firstState != "")
            {
                thisObj.GetComponent<Animator>().SetBool(firstState, false);
                thisObj.GetComponent<Animator>().SetBool(secondState, true);
            }
            else if (thirdState != "" && secondState != "" && firstState != "")
            {
                thisObj.GetComponent<Animator>().SetBool(firstState, false);
                thisObj.GetComponent<Animator>().SetBool(secondState, true);
                thisObj.GetComponent<Animator>().SetBool(thirdState, true);
            }
            
            thisBool = true;
        }
    }
    private static void SetAudio(GameObject thisObj,AudioClip thisAudio,ref bool thisBool) { 
        if (!thisBool) 
        {
            if (thisAudio != null)
            {
                thisObj.GetComponent<AudioSource>().clip = thisAudio;
            }
            thisObj.GetComponent<AudioSource>().Play();
        
            thisBool = true;
        }
    }
    public static bool GetInputDevices()
    {
        if (!isInputList)
        {
            InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left,inputDevices);
            if (inputDevices.Count > 0)
            {
                isInputList = true;   
            }
            return isInputList;
        }
        return isInputList;

    }
    public static void ReactivateBoatMenu(GameObject thisMenu)
    {
        
        if (isInputList)
        {
            foreach (var device in inputDevices)
            {
                isTest = device.TryGetFeatureValue(CommonUsages.primaryButton, out primaryBtnValue);
            }
            if (primaryBtnValue)
            {
                if (thisMenu)
                {
                    BoatOneStatics.isDrOptionsDr = false;
                    BoatOneStatics.isDrOptionsInfo = false;
                    BoatOneStatics.isDrOptionsMFD = false;
                    BoatOneStatics.isDrOptionsAuto = false;
                    isInputList = false;
                    inputDevices = new List<InputDevice>();
                    if (!BoatOneStatics.isDrOptionsDr && !BoatOneStatics.isDrOptionsInfo &&
                        !BoatOneStatics.isDrOptionsMFD && !BoatOneStatics.isDrOptionsAuto &&
                        !isInputList && inputDevices.Count == 0)
                    {
                       
                        thisMenu.SetActive(true);
                    }
                }
            }
        }
       
    }
}

