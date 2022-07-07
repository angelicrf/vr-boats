using System.Collections;
using UnityEngine;

public class BoatsSettings : MonoBehaviour
{
    public GameObject drivePoses;
    public GameObject driveDr;
    public GameObject driveInfo;
    public GameObject driveMfd;
    public GameObject driversOptions;
    public GameObject selfTourBtn;
    public GameObject driveTourBtn;

    void Start()
    {
        gameObject.transform.position = new Vector3(-1f, gameObject.transform.position.y, gameObject.transform.position.z);
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
        }
    }
    public void ActivateDriverDr()
    {
        if (driversOptions)
        {
            drivePoses.SetActive(true);
            CheckStat(driveDr, driveInfo, driveMfd);
        }
    }
    public void ActivateDriverMFD()
    {
        if (driversOptions)
        {
            drivePoses.SetActive(true);
            CheckStat(driveMfd, driveDr, driveInfo);
        }
    }
    public void ActivateDriverInfo()
    {
        if (driversOptions)
        {
            drivePoses.SetActive(true);
            CheckStat(driveInfo, driveDr, driveMfd);
        }
    }
    public void ActivateDriverAuto()
    {
        if (driversOptions)
        {
            drivePoses.SetActive(true);
            if (drivePoses.activeInHierarchy)
            {
                //work on
                gameObject.SetActive(false);
            }
        }
    }
    private void CheckStat(GameObject toCheck, GameObject statOne, GameObject statTwo)
    {
        if (drivePoses.activeInHierarchy)
        {
            toCheck.SetActive(true);
            statOne.SetActive(false);
            statTwo.SetActive(false);
            Debug.Log("driverstat2" + toCheck.activeSelf);
            gameObject.SetActive(false);
        }
    }
}
