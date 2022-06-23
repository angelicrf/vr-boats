using System;
using UnityEngine;
using UnityEngine.UI;

public class BoatMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject timeMenu;
    public GameObject temprMenu;
    public GameObject fuelMenu;
    public GameObject borderMenu;
    public GameObject timeImg;
    public GameObject temprImg;
    public GameObject fuelImg;
    public GameObject displayMenu;
    public GameObject gpsMap;
    public GameObject spotLight;
    public GameObject radar;
    public GameObject fog;
    public GameObject fan;
    public GameObject engine;
    public GameObject shorePower;
    public GameObject gangPlank;
    public GameObject electricWindow;
    public GameObject acPower;
    public GameObject doors;
    public GameObject pumps;
    public GameObject instruments;
    public GameObject clock;
    public GameObject tv;
    public GameObject cameraH;
    public GameObject lightenings;
    public GameObject aircondition;
    public GameObject thrusterH;
    public GameObject powerHach;
    public GameObject trimTabs;
    public GameObject anchors;
    public GameObject batheningsPlatform;
    public GameObject batteries;
    public GameObject oil;
    public GameObject bilgeTank;
    public GameObject underwaterLights;
    public GameObject klaxon;
    public GameObject heatedWindow;
    public GameObject fuelPump;
    public GameObject freshwaterPump;
    public GameObject alarm;
    public GameObject cameraOne;
    public GameObject cameraTwo;
    //
    public GameObject radarDevice;
    public Button alarmOn;
    public Button alarmOff;
    public Button spotLightOn;
    public Button spotLightOff;
    public Button radarOn;
    public Button radarOff;
    public Button fogOn;
    public Button fogOff;
    public Button fanOn;
    public Button fanOff;
    public Button engineOn;
    public Button engineOff;
    public Button showerPowerOn;
    public Button showerPowerOff;
    public Button gangPlankOn;
    public Button gangPlankOff;
    public Button electricWOn;
    public Button electricWOff;
    public Button acOn;
    public Button acOff;
    public Button doorsOn;
    public Button doorsOff;
    public Button pumpsOn;
    public Button pumpsOff;
    public Button instrumentOn;
    public Button instrumentOff;
    public Button clockOn;
    public Button clockOff;
    public Button tvOn;
    public Button tvOff;
    public Button cameraHOn;
    public Button cameraHOff;
    public Button lighteningOn;
    public Button lighteningOff;
    public Button airConditionOn;
    public Button airConditionOff;
    public Button thrusterHOn;
    public Button thrusterHOff;
    public Button powerHachOn;
    public Button powerHachOff;
    public Button trimTabsOn;
    public Button trimTabsOff;
    public Button anchorsOn;
    public Button anchorsOff;
    public Button batheningPlatformOn;
    public Button batheningPlatformOff;
    public Button batteriesOn;
    public Button batteriesOff;
    public Button oilOn;
    public Button oilOff;
    public Button bilgeTankOn;
    public Button bilgeTankOff;
    public Button underWaterLightOn;
    public Button underWaterLightOff;
    public Button klaxonOn;
    public Button klaxonOff;
    public Button heatedWOn;
    public Button heatedWOff;
    public Button fuelPumpOn;
    public Button fuelPumpOff;
    public Button freshWPOn;
    public Button freshWPOff;
    //
    public GameObject SecurityAlarmOne;
    public GameObject SecurityAlarmTwo;

    private bool colorArm = false;
    private bool colorDisarm = false;
    //
    private bool colorSpotLight = false;
    private bool colorDSpotLight = false;
    private bool colorRadar = false;
    private bool colorDRadar = false;
    private bool colorFog = false;
    private bool colorDFog = false;
    private bool colorFan= false;
    private bool colorDFan = false;
    private bool colorEngine = false;
    private bool colorDEngine = false;
    private bool colorShowerpower = false;
    private bool colorDShowerpower = false;
    private bool colorGangPlank = false;
    private bool colorDGangPlank = false;
    private bool colorEWindows = false;
    private bool colorDEWindows = false;
    private bool colorDoors = false;
    private bool colorDDoors = false;
    private bool colorPumps = false;
    private bool colorDPumps = false;
    private bool colorInstruments = false;
    private bool colorDInstruments = false;
    private bool colorClock = false;
    private bool colorDClock = false;
    private bool colorTV = false;
    private bool colorDTV = false;
    private bool colorCameraH = false;
    private bool colorDCameraH = false;
    private bool colorLightening = false;
    private bool colorDLightening = false;
    private bool colorAirCondition = false;
    private bool colorDAirCondition = false;
    private bool colorThrusterH = false;
    private bool colorDThrusterH = false;
    private bool colorPowerHach = false;
    private bool colorDPowerHach = false;
    private bool colorTrimTab = false;
    private bool colorDTrimTab = false;
    private bool colorAnchors = false;
    private bool colorDAnchors = false;
    private bool colorBatheningPlatform = false;
    private bool colorDBatheningPlatform = false;
    private bool colorBatteries = false;
    private bool colorDBatteries = false;
    private bool colorOil = false;
    private bool colorDOil = false;
    private bool colorBilgeTank= false;
    private bool colorDBilgeTank = false;
    private bool colorUnderWaterLight = false;
    private bool colorDUnderWaterLight = false;
    private bool colorKlaxon = false;
    private bool colorDKlaxon = false;
    private bool colorHeatedW = false;
    private bool colorDHeatedW = false;
    private bool colorFuelPump = false;
    private bool colorDFuelPump = false;
    private bool colorFreshW = false;
    private bool colorDfreshW = false;
    private bool colorAC = false;
    private bool colorDAC = false;
    //
    private bool isLeftCam = false;
    private bool isRightCam = false;
    private ColorBlock textColorOne;
    private ColorBlock textColorTwo;

    private void FixedUpdate()
    {
        timeMenu.GetComponent<Text>().text = DateTime.Now.ToString("HH:mm");
        temprMenu.GetComponent<Text>().text = string.Format("{0}\u00B0F", BoatOneStatics.tempMax) + " in " + BoatOneStatics.city;
        textColorOne = cameraOne.GetComponent<Button>().colors;
        textColorTwo = cameraTwo.GetComponent<Button>().colors;

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
                textColorOne.selectedColor = Color.red;
                cameraOne.GetComponent<Button>().colors = textColorOne;
                cameraOne.GetComponent<Image>().color = cameraOne.GetComponent<Button>().colors.selectedColor;
            }
            else if (!isRightCam)
            {
                textColorOne.selectedColor = Color.blue;
                cameraOne.GetComponent<Button>().colors = textColorOne;
                cameraOne.GetComponent<Image>().color = Color.blue;
                //cameraOne.GetComponent<Button>().colors.normalColor;
            }
            if (isLeftCam)
            {
                textColorTwo.selectedColor = Color.red;
                cameraTwo.GetComponent<Button>().colors = textColorTwo;
                cameraTwo.GetComponent<Image>().color = cameraTwo.GetComponent<Button>().colors.selectedColor;
            }
            else if (!isLeftCam)
            {
                textColorTwo.selectedColor = textColorTwo.normalColor;
                textColorTwo.selectedColor = Color.blue;
                cameraTwo.GetComponent<Button>().colors = textColorTwo;
                cameraTwo.GetComponent<Image>().color = Color.blue;
                //cameraTwo.GetComponent<Button>().colors.normalColor;
            }

        }
        ActivateSystem(colorSpotLight, colorDSpotLight, spotLightOn, spotLightOff);
        ActivateSystem(colorSpotLight, colorDSpotLight, spotLightOn, spotLightOff);
        ActivateSystem(colorRadar, colorDRadar, radarOn, radarOff);
        ActivateSystem(colorFog, colorDFog, fogOn, fogOff);
        ActivateSystem(colorFan, colorDFan, fanOn, fanOff);
        ActivateSystem(colorEngine, colorDEngine, engineOn, engineOff);
        ActivateSystem(colorShowerpower, colorDShowerpower, showerPowerOn, showerPowerOff);
        ActivateSystem(colorGangPlank, colorDGangPlank, gangPlankOn, gangPlankOff);
        ActivateSystem(colorEWindows, colorDEWindows, electricWOn, electricWOff);
        ActivateSystem(colorAC, colorDAC, acOn, acOff);
        ActivateSystem(colorDoors, colorDDoors, doorsOn, doorsOff);
        ActivateSystem(colorPumps, colorDPumps, pumpsOn, pumpsOff);
        ActivateSystem(colorInstruments, colorDInstruments, instrumentOn, instrumentOff);
        ActivateSystem(colorClock, colorDClock, clockOn, clockOff);
        ActivateSystem(colorTV, colorDTV, tvOn, tvOff);
        ActivateSystem(colorCameraH, colorDCameraH, cameraHOn, cameraHOff);
        ActivateSystem(colorLightening, colorDLightening, lighteningOn, lighteningOff);
        ActivateSystem(colorAirCondition, colorDAirCondition, airConditionOn, airConditionOff);
        ActivateSystem(colorThrusterH, colorDThrusterH, thrusterHOn, thrusterHOff);
        ActivateSystem(colorPowerHach, colorDPowerHach, powerHachOn, powerHachOff);
        ActivateSystem(colorTrimTab, colorDTrimTab, trimTabsOn, trimTabsOff);
        ActivateSystem(colorAnchors, colorDAnchors, anchorsOn, anchorsOff);
        ActivateSystem(colorBatheningPlatform, colorDBatheningPlatform, batheningPlatformOn, batheningPlatformOff);
        ActivateSystem(colorBatteries, colorDBatteries, batteriesOn, batteriesOff);
        ActivateSystem(colorOil, colorDOil, oilOn, oilOff);
        ActivateSystem(colorBilgeTank, colorDBilgeTank, bilgeTankOn, bilgeTankOff);
        ActivateSystem(colorUnderWaterLight, colorDUnderWaterLight, underWaterLightOn, underWaterLightOff);
        ActivateSystem(colorKlaxon, colorDKlaxon, klaxonOn, klaxonOff);
        ActivateSystem(colorHeatedW, colorDHeatedW, heatedWOn, heatedWOff);
        ActivateSystem(colorFuelPump, colorDFuelPump, fuelPumpOn, fuelPumpOff);
        ActivateSystem(colorFreshW, colorDfreshW, freshWPOn, freshWPOff);
    }
    private void ActivateSystem(bool isThisOn, bool isThisOff, Button thisBtnOn, Button thisBtnOff)
    {
        if (isThisOn)
        {
            thisBtnOn.GetComponent<Image>().color = Color.red;
            thisBtnOff.GetComponent<Image>().color = Color.gray; 
        }
        if (isThisOff)
        {
            thisBtnOff.GetComponent<Image>().color = Color.red;
            thisBtnOn.GetComponent<Image>().color = Color.gray;

        }
    }
    public void SpotLightSystemOn()
    {
        colorSpotLight = true;
        colorDSpotLight = false;
    }
    public void SpotLightSystemOff()
    {
        colorDSpotLight = true;
        colorSpotLight = false;
    }
    //
    public void RadarSystemOn()
    {
        colorRadar = true;
        colorDRadar = false;
        if (radarDevice)
        {
            radarDevice.SetActive(true);
        }
    }
    public void RadarSystemOff()
    {
        colorDRadar = true;
        colorRadar = false;
        if (radarDevice)
        {
            radarDevice.SetActive(false);
        }
    }
    public void FogSystemOn()
    {
        colorFog = true;
        colorDFog = false;
    }
    public void FogSystemOff()
    {
        colorDFog = true;
        colorFog = false;
    }
    public void FanSystemOn()
    {
        colorFan = true;
        colorDFan = false;
    }
    public void FanSystemOff()
    {
        colorDFan = true;
        colorFan = false;
    }
    public void EngineSystemOn()
    {
        colorEngine = true;
        colorDEngine = false;
    }
    public void EngineSystemOff()
    {
        colorDEngine = true;
        colorEngine = false;
    }
    public void ShorePowerSystemOn()
    {
        colorShowerpower = true;
        colorDShowerpower = false;
    }
    public void ShorePowerSystemOff()
    {
        colorDShowerpower = true;
        colorShowerpower = false;
    }
    public void GangPlankSystemOn()
    {
        colorGangPlank = true;
        colorDGangPlank = false;
    }
    public void GangPlankSystemOff()
    {
        colorDGangPlank = true;
        colorGangPlank = false;
    }
    public void EWindowSystemOn()
    {
        colorEWindows = true;
        colorDEWindows = false;
    }
    public void EWindowSystemOff()
    {
        colorDEWindows = true;
        colorEWindows = false;
    }
    public void ACPowerSystemOn()
    {
        colorAC = true;
        colorDAC = false;
    }
    public void ACPowerSystemOff()
    {
        colorDAC = true;
        colorAC = false;
    }
    public void DoorsSystemOn()
    {
        colorDoors = true;
        colorDDoors = false;
    }
    public void DoorsSystemOff()
    {
        colorDDoors = true;
        colorDoors = false;
    }
    public void PumpsSystemOn()
    {
        colorPumps = true;
        colorDPumps = false;
    }
    public void PumpsSystemOff()
    {
        colorDPumps = true;
        colorPumps = false;
    }
    public void InstrumentsSystemOn()
    {
        colorInstruments = true;
        colorDInstruments = false;
    }
    public void InstrumentsSystemOff()
    {
        colorDInstruments = true;
        colorInstruments = false;
    }
    public void ClockSystemOn()
    {
        colorClock = true;
        colorDClock = false;
    }
    public void ClockSystemOff()
    {
        colorDClock = true;
        colorClock = false;
    }
    public void TVSystemOn()
    {
        colorTV = true;
        colorDTV = false;
    }
    public void TVSystemOff()
    {
        colorDTV = true;
        colorTV = false;
    }
    public void CameraSystemOn()
    {
        colorCameraH = true;
        colorDCameraH = false;
    }
    public void CameraSystemOff()
    {
        colorDCameraH = true;
        colorCameraH = false;
    }
    public void LighteningSystemOn()
    {
        colorLightening = true;
        colorDLightening = false;
    }
    public void LighteningSystemOff()
    {
        colorDLightening = true;
        colorLightening = false;
    }
    public void AirConditionSystemOn()
    {
        colorAirCondition = true;
        colorDAirCondition = false;
    }
    public void AirConditionSystemOff()
    {
        colorDAirCondition = true;
        colorAirCondition = false;
    }
    public void ThrusterSystemOn()
    {
        colorThrusterH = true;
        colorDThrusterH = false;
    }
    public void ThrusterSystemOff()
    {
        colorDThrusterH = true;
        colorThrusterH = false;
    }
    public void PowerHachSystemOn()
    {
        colorPowerHach = true;
        colorDPowerHach = false;
    }
    public void PowerHachSystemOff()
    {
        colorDPowerHach = true;
        colorPowerHach = false;
    }
    public void TrimTabsSystemOn()
    {
        colorTrimTab = true;
        colorDTrimTab = false;
    }
    public void TrimTabsSystemOff()
    {
        colorDTrimTab = true;
        colorTrimTab = false;
    }
    public void AnchorSystemOn()
    {
        colorAnchors = true;
        colorDAnchors = false;
    }
    public void AnchorSystemOff()
    {
        colorDAnchors = true;
        colorAnchors = false;
    }
    public void BatheningPlatformSystemOn()
    {
        colorBatheningPlatform = true;
        colorDBatheningPlatform = false;
    }
    public void BatheningPlatformSystemOff()
    {
        colorDBatheningPlatform = true;
        colorBatheningPlatform = false;
    }
    public void BatteriesSystemOn()
    {
        colorBatteries = true;
        colorDBatteries = false;
    }
    public void BatteriesSystemOff()
    {
        colorDBatteries = true;
        colorBatteries = false;
    }
    public void OilSystemOn()
    {
        colorOil = true;
        colorDOil = false;
    }
    public void OilSystemOff()
    {
        colorDOil = true;
        colorOil = false;
    }
    public void BilgeTankSystemOn()
    {
        colorBilgeTank = true;
        colorDBilgeTank = false;
    }
    public void BilgeTankSystemOff()
    {
        colorDBilgeTank = true;
        colorBilgeTank = false;
    }
    public void UnderwaterLightSystemOn()
    {
        colorUnderWaterLight = true;
        colorDUnderWaterLight = false;
    }
    public void UnderwaterLightSystemOff()
    {
        colorDUnderWaterLight = true;
        colorUnderWaterLight = false;
    }
    public void KlaxonSystemOn()
    {
        colorKlaxon = true;
        colorDKlaxon = false;
    }
    public void KlaxonSystemOff()
    {
        colorDKlaxon = true;
        colorKlaxon = false;
    }
    public void FuelPumpSystemOn()
    {
        colorHeatedW = true;
        colorDHeatedW = false;
    }
    public void FuelPumpSystemOff()
    {
        colorDHeatedW = true;
        colorHeatedW = false;
    }
    public void HeatedWSystemOn()
    {
        colorFuelPump = true;
        colorDFuelPump = false;
    }
    public void HeatedWSystemOff()
    {
        colorDFuelPump = true;
        colorFuelPump = false;
    }
    public void FreshWSystemOn()
    {
        colorFreshW = true;
        colorDfreshW = false;
    }
    public void FreshWSystemOff()
    {
        colorDfreshW = true;
        colorFreshW = false;
    }

    //
    public void StartBoatSystem()
    {
        mainMenu.SetActive( false );
        timeMenu.SetActive(false);
        temprMenu.SetActive(false);
        fuelMenu.SetActive(false);
        borderMenu.SetActive(false);
        fuelImg.SetActive(false);
        timeImg.SetActive(false);
        temprImg.SetActive(false);
        displayMenu.SetActive( true );
    }
    public void StartAlarmSystem()
    {
        mainMenu.SetActive(false);
        alarm.SetActive(true);
    }
    public void StartBoatGPSSystem()
    {
        displayMenu.SetActive( false );
        gpsMap.SetActive( true );
    }

    public void SpotLightSystem()
    {
        displayMenu.SetActive(false);
        spotLight.SetActive(true);
    }
    public void RadarSystem()
    {
        displayMenu.SetActive(false);
        radar.SetActive(true);
    }
    public void FogSystem()
    {
        displayMenu.SetActive(false);
        fog.SetActive(true);
    }
    public void FanSystem()
    {
        displayMenu.SetActive(false);
        fan.SetActive(true);
    }
    public void engineSystem()
    {
        displayMenu.SetActive(false);
        engine.SetActive(true);
    }
    public void ShorePowerSystem()
    {
        displayMenu.SetActive(false);
        shorePower.SetActive(true);
    }
    public void GangPlankSystem()
    {
        displayMenu.SetActive(false);
        gangPlank.SetActive(true);
    }
    public void ElecticWindowSystem()
    {
        displayMenu.SetActive(false);
        electricWindow.SetActive(true);
    }
    public void ACPowerSystem()
    {
        displayMenu.SetActive(false);
        acPower.SetActive(true);
    }
    public void DoorsSystem()
    {
        displayMenu.SetActive(false);
        doors.SetActive(true);
    }
    public void PumpsSystem()
    {
        displayMenu.SetActive(false);
        pumps.SetActive(true);
    }
    public void InstrumentsSystem()
    {
        displayMenu.SetActive(false);
        instruments.SetActive(true);
    }
    public void ClockSystem()
    {
        displayMenu.SetActive(false);
        clock.SetActive(true);
    }
    public void TVSystem()
    {
        displayMenu.SetActive(false);
        tv.SetActive(true);
    }
    public void CameraSystem()
    {
        displayMenu.SetActive(false);
        cameraH.SetActive(true);
    }
    public void LighteningSystem()
    {
        displayMenu.SetActive(false);
        lightenings.SetActive(true);
    }
    public void AirConditionSystem()
    {
        displayMenu.SetActive(false);
        aircondition.SetActive(true);
    }
    public void ThrusterSystem()
    {
        displayMenu.SetActive(false);
        thrusterH.SetActive(true);
    }
    public void PowerHachSystem()
    {
        displayMenu.SetActive(false);
        powerHach.SetActive(true);
    }
    public void TrimTabsSystem()
    {
        displayMenu.SetActive(false);
        trimTabs.SetActive(true);
    }
    public void AnchorsSystem()
    {
        displayMenu.SetActive(false);
        anchors.SetActive(true);
    }
    public void BatheningPlatformSystem()
    {
        displayMenu.SetActive(false);
        batheningsPlatform.SetActive(true);

    }
    public void BatteriesSystem()
    {
        displayMenu.SetActive(false);
        batteries.SetActive(true);
    }
    public void OilSystem()
    {
        displayMenu.SetActive(false);
        oil.SetActive(true);
    }
    public void BilgeTankSystem()
    {
        displayMenu.SetActive(false);
        bilgeTank.SetActive(true);
    }
    public void UnderwaterLightsSystem()
    {
        displayMenu.SetActive(false);
        underwaterLights.SetActive(true);
    }
    public void KlaxonSystem()
    {
        displayMenu.SetActive(false);
        klaxon.SetActive(true);
    }
    public void HeatedWindowSystem()
    {
        displayMenu.SetActive(false);
        heatedWindow.SetActive(true);
    }
      public void FuelPumpSystem()
    {
        displayMenu.SetActive( false );
        fuelPump.SetActive( true );
    }
    public void FreshWaterPumpSystem()
    {
        displayMenu.SetActive(false);
        freshwaterPump.SetActive(true);
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
        isLeftCam = false;
        isRightCam = false;
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
