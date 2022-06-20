using UnityEngine;
using UnityEngine.UI;

public class BoatMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject displayMenu;
    public GameObject gpsMap;
    public GameObject alarm;
    public GameObject cameraOne;
    public GameObject cameraTwo;
    public Button alarmOn;
    public Button alarmOff;
    public GameObject SecurityAlarmOne;
    public GameObject SecurityAlarmTwo;
    private bool colorArm = false;
    private bool colorDisarm = false;
    private bool isLeftCam = false;
    private bool isRightCam = false;
    private ColorBlock textColorOne;
    private ColorBlock textColorTwo;
    private void Start()
    {
        textColorOne = cameraOne.GetComponent<Button>().colors;
        textColorTwo = cameraTwo.GetComponent<Button>().colors;
    }
    private void FixedUpdate()
    {
        if (colorDisarm)
        {
            alarmOn.GetComponent<Image>().color = alarmOn.colors.disabledColor;
            alarmOff.GetComponent<Image>().color = alarmOff.colors.selectedColor;
        }
        if (colorArm)
        {
            alarmOff.GetComponent<Image>().color = alarmOff.colors.disabledColor;
            alarmOn.GetComponent<Image>().color = alarmOn.colors.selectedColor;
            if (isRightCam)
            {
                cameraOne.GetComponent<Image>().color = cameraOne.GetComponent<Button>().colors.selectedColor;
            }else if (!isRightCam)
            {
                cameraOne.GetComponent<Image>().color = cameraOne.GetComponent<Button>().colors.normalColor;
                textColorOne.selectedColor = textColorOne.normalColor;
            }
            if (isLeftCam)
            {
                cameraTwo.GetComponent<Image>().color = cameraTwo.GetComponent<Button>().colors.selectedColor;
            }else if (!isLeftCam)
            {
                cameraTwo.GetComponent<Image>().color = cameraTwo.GetComponent<Button>().colors.normalColor;
                textColorTwo.selectedColor = textColorTwo.normalColor;
            }
            if(!isLeftCam && !isRightCam)
            {
                colorArm = false;
                //change img disarm color to original
                //alarmOn.GetComponent<Image>().color = alarmOn.colors.normalColor;
                //cameraTwo.SetActive( false );
                //cameraOne.SetActive( false );
            }
        }
    }
    public void StartBoatSystem()
    {
        mainMenu.SetActive( false );
        displayMenu.SetActive( true );
    }
    public void StartBoatGPSSystem()
    {
        displayMenu.SetActive( false );
        gpsMap.SetActive( true );
    }
    public void BoatAlarmSystem()
    {
        displayMenu.SetActive( false );
        alarm.SetActive( true );
    }
    public void AlarmArmSystemOn()
    {
        cameraOne.SetActive( true );
        cameraTwo.SetActive( true );
        colorArm = true;
        colorDisarm = false;
    }
    public void AlarmArmSystemOff()
    {
        SecurityAlarmOne.SetActive( false );
        SecurityAlarmTwo.SetActive( false );
        cameraTwo.SetActive( false );
        cameraOne.SetActive( false );
        colorDisarm = true;
        colorArm = false;
    }
    public void CameraOneSystem()
    {        
        isRightCam = !isRightCam;
        if (isRightCam)
        {
            SecurityAlarmOne.SetActive( true );
        }else if (!isRightCam)
        {
            SecurityAlarmOne.SetActive( false );
        }
    }
    public void CameraTwoSystem()
    {
      
        isLeftCam = !isLeftCam;
        if (isLeftCam)
        {
            SecurityAlarmTwo.SetActive( true );
        }else if (!isLeftCam)
        {
            SecurityAlarmTwo.SetActive( false );
        }
    }
}
