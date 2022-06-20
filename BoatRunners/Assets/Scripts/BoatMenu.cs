using UnityEngine;
using UnityEngine.UI;

public class BoatMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject displayMenu;
    public GameObject gpsMap;
    public GameObject alarm;
    public Button alarmOn;
    public Button alarmOff;
    private bool colorArm = false;
    private bool colorDisarm = false;
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
        //alarmOff.enabled = false;
        //alarmOn.enabled = true;
        colorArm = true;
        colorDisarm = false;
    }
    public void AlarmArmSystemOff()
    {
        //alarmOn.enabled = false;
        //alarmOff.enabled = true;
        colorDisarm = true;
        colorArm = false;
    }
}
