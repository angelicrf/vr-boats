using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public static class DupAvatar {

    [DefaultValue(false)]
    public static bool isCapselected { get; set; }
    [DefaultValue(false)]
    public static bool isSGSelected { get; set; }
    [DefaultValue(false)]
    public static bool isShoeOne { get; set; }
    [DefaultValue(false)]
    public static bool isShoeTwo { get; set; }

    [DefaultValue(false)]
    public static bool isShirtOne { get; set; }
    [DefaultValue(false)]
    public static bool isShirtTwo { get; set; }
    [DefaultValue(false)]
    public static bool isShortOne { get; set; }
    [DefaultValue(false)]
    public static bool isShortTwo { get; set; }
    [DefaultValue(false)]
    public static bool isAccessories { get; set; }
    [DefaultValue(false)]
    public static bool isButtom { get; set; }
    [DefaultValue(false)]
    public static bool isTop { get; set; }
    [DefaultValue(false)]
    public static bool isShoes { get; set; }

    private static Sprite spOne, spTwo, spThree, spFour, spFive,spSix;
    public static List<Avatar> dupAvatrs = new List<Avatar>();
    private static List<Sprite> dupSprites = new List<Sprite>()
       {
         spOne,spTwo,spThree,spFour,spFive,spSix
       };
    public static int avtCurrentId { get; set; }
    public static List<Avatar> avatarsList = new List<Avatar>
        {
            new Avatar {
                AvatarDesc = "test1", AvatarId = 1 , AvatarName = "Matt",
                AvatarSprite = dupSprites[0]
                ,
                allCommentTest = new List<string>()
                {
                "is a nice Driver",
                "made us fun",
                "created a Fantastic day",
                "has experinces",
                "is knowledgable",
                }
            },
           new Avatar { 
              AvatarDesc = "test2", AvatarId = 2 , AvatarName = "Robert",
              AvatarSprite = dupSprites[1],
              allCommentTest = new List<string>()
                {
                "is a nice Driver",
                "made us fun",
                "created a Fantastic day",
                "has experinces",
                "is knowledgable",
                }
            },
           new Avatar { 
              AvatarDesc = "test3", AvatarId = 3 , AvatarName = "Dave",
              AvatarSprite = dupSprites[2],
              allCommentTest = new List<string>()
                {
                "is a nice Driver",
                "made us fun",
                "created a Fantastic day",
                "has experinces",
                "is knowledgable",
                }
            },
           new Avatar {
              AvatarDesc = "test4", AvatarId = 4 , AvatarName = "Bryan",
              AvatarSprite = dupSprites[3],
              allCommentTest = new List<string>()
                {
                "is a nice Driver",
                "made us fun",
                "created a Fantastic day",
                "has experinces",
                "is knowledgable",
                }
            },
           new Avatar {
              AvatarDesc = "test5", AvatarId = 5 , AvatarName = "Lisa",
              AvatarSprite = dupSprites[4],
              allCommentTest = new List<string>()
                {
                "is a nice Driver",
                "made us fun",
                "created a Fantastic day",
                "has experinces",
                "is knowledgable",
                }
            },
             new Avatar {
              AvatarDesc = "test6", AvatarId = 6 , AvatarName = "Tanya",
              AvatarSprite = dupSprites[5],
              allCommentTest = new List<string>()
                {
                "is a nice Driver",
                "made us fun",
                "created a Fantastic day",
                "has experinces",
                "is knowledgable",
                }
            },
        };
}

public class Avatar {
    public string AvatarName { get; set; }
    public string AvatarDesc { get; set; }
    public int AvatarId { get; set; }
    public Sprite AvatarSprite { get; set; }
    private List<string> AvtarSubRvs = new List<string>();
    public List<string> AvtRvs { get { return AvtarSubRvs; } }
    public List<string> allCommentTest = new List<string>();
  
    public Avatar() { }
    public Avatar(int thisId,string thisName, string thisDesc, Sprite avtSprite, List<string> avtComs)
    {
        AvatarId = thisId;
        AvatarName = thisName;
        AvatarDesc = thisDesc;
        AvatarSprite = avtSprite;
        AvtarSubRvs = avtComs;
        for (int i = 0; i < 5; i++)
        {
            AddRv($"comment {i+1}: {thisName} , {allCommentTest[i]}");
        }
    }
    private void AddRv(String argValue)
    {
        AvtarSubRvs.Add(argValue);
    }
}
