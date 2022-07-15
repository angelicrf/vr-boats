using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatsSettings : MonoBehaviour
{
    public GameObject drivePoses;
    public GameObject driveDr;
    public GameObject driveInfo;
    public GameObject driveMfd;
    public GameObject driverStr;
    public GameObject driversOptions;
    public GameObject selfTourBtn;
    public GameObject driveTourBtn;
    public GameObject restartBtn;
  
    void Start()
    {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
    }
    public void RestartGame()
    {
        //Application.Quit();
        StartCoroutine(LoadCurrentAsyncScene());

    }
    public void AvatarDesign()
    {
        StartCoroutine(LoadAvatarScene());
    }
    private IEnumerator LoadAvatarScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Avatar");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    IEnumerator LoadCurrentAsyncScene()
    {
        BoatOneStatics.isTeleportCompleted = false;
        BoatOneStatics.isInBoatOne = false;
        BoatOneStatics.isDriveBoatOne = false;
        yield return new WaitUntil(() => 
             !BoatOneStatics.isInBoatOne &&
             !BoatOneStatics.isTeleportCompleted &&
             !BoatOneStatics.isDriveBoatOne
            );
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BoatScene");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    public void ActivateSelfTour()
    {
        if (drivePoses)
        {
            if (drivePoses.activeInHierarchy)
            {
                drivePoses.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }
    public void ActivateDriverOptions()
    {
        if (driversOptions)
        {
            driversOptions.SetActive(true);
            selfTourBtn.SetActive(false);
            driveTourBtn.SetActive(false);
            restartBtn.transform.localPosition = new Vector3(restartBtn.transform.localPosition.x, restartBtn.transform.localPosition.y - 9f, restartBtn.transform.localPosition.z);
        }
    }
    public void ActivateDriverDr()
    {
        if (driversOptions)
        {
            drivePoses.SetActive(true);
            CheckStat(driveDr, driveInfo, driveMfd, res => BoatOneStatics.isDrOptionsDr = res);
            
        }
    }
    public void ActivateDriverMFD()
    {
        if (driversOptions)
        {
            drivePoses.SetActive(true);
            CheckStat(driveMfd, driveDr, driveInfo, res => BoatOneStatics.isDrOptionsMFD = res);
        }
    }
    public void ActivateDriverInfo()
    {
        if (driversOptions)
        {
            drivePoses.SetActive(true);
            CheckStat(driveInfo, driveDr, driveMfd, res => BoatOneStatics.isDrOptionsInfo = res);
        }
    }
    public void ActivateDriverAuto()
    {
        if (driversOptions)
        {
            drivePoses.SetActive(true);
            if (drivePoses.activeInHierarchy && driverStr)
            {
                BoatOneStatics.isDrOptionsAuto = true;
                driverStr.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
    private void CheckStat(GameObject toCheck, GameObject statOne, GameObject statTwo, Action<bool> thisBool)
    {
        if (drivePoses.activeInHierarchy)
        {
            toCheck.SetActive(true);
            statOne.SetActive(false);
            statTwo.SetActive(false);
            thisBool(true);
            Debug.Log("driverstat2" + toCheck.activeSelf);
            gameObject.SetActive(false);
        }
    }
}
