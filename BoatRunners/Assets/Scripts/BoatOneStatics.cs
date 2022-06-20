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
}
