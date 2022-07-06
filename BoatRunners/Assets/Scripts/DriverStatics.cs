using System;
using System.Collections;
using UnityEngine;

public static class DriverStatics {

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
    public static IEnumerator MoveDriveToWalkAnimCo(GameObject thisObj, GameObject otherObj)
    {
        if (otherObj)
        {
            thisObj.GetComponent<Animator>().runtimeAnimatorController.animationClips[0].wrapMode = WrapMode.Once;
            yield return new WaitForSeconds(5f);
            thisObj.GetComponent<Animator>().enabled = false;
            yield return new WaitForSeconds(2f);
            thisObj.SetActive(false);
            otherObj.SetActive(true);
        }
    }
    private static bool ReturnValue = false;
    private static bool ReturnFirstValue = false;
    private static bool ReturnSecondValue = false;
    private static bool isEnabed = false;
    public static IEnumerator RunAnimCo(GameObject thisObj,Action<bool> isNowPlaying,string setBool, string clipName, Action<bool> isNext)
    {
    
        if (thisObj.GetComponent<AudioSource>().enabled && thisObj.GetComponent<Animator>().enabled && !ReturnValue)
        {
            thisObj.GetComponent<Animator>().SetBool(setBool, true);
            isNowPlaying = flag => ReturnValue = flag;
            isNowPlaying(false);
           if (thisObj.GetComponent<AudioSource>().clip.name == clipName && !thisObj.GetComponent<AudioSource>().isPlaying)
            {
                thisObj.GetComponent<AudioSource>().Play();
                isNowPlaying(true);
            }
        }
        if (ReturnValue)
        {
            yield return new WaitForSeconds(thisObj.GetComponent<AudioSource>().clip.length);
            ReturnValue = false;
            isNext(true);
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
}

