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
}
