using System.ComponentModel;
public static class BoatOneStatics
{
    [DefaultValue( false )]
    public static bool isStoped { get; set; }
    [DefaultValue( false )]
    public static bool isSat{get;set;}
    [DefaultValue( false )]
    public static bool isLightOn { get; set; }
    [DefaultValue( false )]
    public static bool isBoatTeleported { get; set; }
    [DefaultValue(false)]
    public static bool isInBoatOne { get; set; }
    public static string city { get; set; }
    public static string dateW { get; set; }
    public static string descriptionW { get; set; }
    public static string tempMin { get; set; }
    public static string tempMax { get; set; }
    public static string cityName { get; set; }
    [DefaultValue(false)]
    public static bool iskeyBoardUsed { get; set; }
    [DefaultValue(false)]
    public static bool isSpeechDone { get; set; }
    public static string speechText { get; set; }
    [DefaultValue(false)]
    public static bool isAtBoatOne { get; set; }
    [DefaultValue(false)]
    public static bool isDriveBoatOne { get; set; }
    [DefaultValue(false)]
    public static bool isBoatOneStartDrive { get; set; }
    [DefaultValue(false)]
    public static bool isSystemLightsOn { get; set; }
    [DefaultValue(false)]
    public static bool isSystemLightsOff { get; set; }
    [DefaultValue(false)]
    public static bool isMenuActivated { get; set; }
    [DefaultValue(false)]
    public static bool isDriverAsked { get; set; }
}
