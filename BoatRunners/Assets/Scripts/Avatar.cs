using MMLib.RapidPrototyping.Generators;
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
                AvatarDesc =  WordGeneratorExample(), AvatarId = 1 , AvatarName = "Matt",
                AvatarSprite = dupSprites[0]
                ,
                allCommentTest = ImplementList()
            },
           new Avatar {
              AvatarDesc =  WordGeneratorExample(), AvatarId = 2 , AvatarName = "Robert",
              AvatarSprite = dupSprites[1],
              allCommentTest = ImplementList()
            },
           new Avatar {
              AvatarDesc =  WordGeneratorExample(), AvatarId = 3 , AvatarName = "Dave",
              AvatarSprite = dupSprites[2],
              allCommentTest = ImplementList()
            },
           new Avatar {
              AvatarDesc =  WordGeneratorExample(), AvatarId = 4 , AvatarName = "Bryan",
              AvatarSprite = dupSprites[3],
              allCommentTest = ImplementList()
            },
           new Avatar {
              AvatarDesc =  WordGeneratorExample(), AvatarId = 5 , AvatarName = "Lisa",
              AvatarSprite = dupSprites[4],
              allCommentTest = ImplementList()
            },
             new Avatar {
              AvatarDesc =  WordGeneratorExample(), AvatarId = 6 , AvatarName = "Tanya",
              AvatarSprite = dupSprites[5],
              allCommentTest = ImplementList()
            },
        };
    private static string WordGeneratorExample()
    {
        WordGenerator generator = new WordGenerator();
        var randomWord = generator.Next();
        return randomWord;
        //LoremIpsumGenerator loremIpsumGenerator = new LoremIpsumGenerator();
        //var text = loremIpsumGenerator.Next(3, 3);
    }
    private static List<string> ImplementList()
    {
        return new List<string>()
                {
                 WordGeneratorExample(),
                 WordGeneratorExample(),
                 WordGeneratorExample(),
                 WordGeneratorExample(),
                 WordGeneratorExample(),
                };
    }
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
