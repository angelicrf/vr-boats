using UnityEngine;

public class Avatar {
    public string AvatarName { get; set; }
    public string AvatarDesc { get; set; }
    public int AvatarId { get; set; }
    public Sprite AvatarSprite { get; set; }
    //public int CountId { get; set; }
    public Avatar(int thisId,string thisName, string thisDesc, Sprite avtSprite)
    {
        AvatarId = thisId;
        AvatarName = thisName;
        AvatarDesc = thisDesc;
        AvatarSprite = avtSprite;
        
    }
}
