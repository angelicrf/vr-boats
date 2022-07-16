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
    private static Material mtShortOne,mtShortTwo, mtOrShort,mtShirtOne, mtShirtTwo,mtOrShirt,mtShoesOne,mtShoesTwo,mtOrShoes;
    private static List<Sprite> dupSprites = new List<Sprite>()
       {
         spOne,spTwo,spThree,spFour,spFive,spSix
       };
    public static List<Material> dupMTShoes = new List<Material>()
    {
      mtShoesOne,mtShoesTwo,mtOrShoes
    };
    public static List<Material> dupMTShorts = new List<Material>()
    {
       mtShortOne,mtShortTwo, mtOrShort
    };
    public static List<Material> dupMTShirts = new List<Material>()
    {
       mtShirtOne, mtShirtTwo,mtOrShirt
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
    public static void CustomizeAvatar(GameObject thisCap, GameObject thisSG, GameObject thisPant, GameObject thisShirt, GameObject thisShoes)
    {
       
        if (isSGSelected)
        {
            thisSG.SetActive(true);
        }
        if (isCapselected)
        {
            thisCap.SetActive(true);
        }
        if (!isSGSelected)
        {
            thisSG.SetActive(false);
        }
        if (!isCapselected)
        {
            thisCap.SetActive(false);
        }
        if (isShoeOne)
        {
            thisShoes.GetComponent<SkinnedMeshRenderer>().material = dupMTShoes[0];
        }
        if (!isShoeOne && !isShoeTwo)
        {
            thisShoes.GetComponent<SkinnedMeshRenderer>().material = dupMTShoes[2];
        }
        if (isShoeTwo)
        {
            thisShoes.GetComponent<SkinnedMeshRenderer>().material = dupMTShoes[1];
        }
        //if (!isShoeTwo)
        //{
        //    thisShoes.GetComponent<SkinnedMeshRenderer>().material = dupMTShoes[2];
        //}
        if (isShirtOne )
        {
            thisShirt.GetComponent<SkinnedMeshRenderer>().material = dupMTShirts[0];
        }
        if (!isShirtOne && !isShirtTwo)
        {
            thisShirt.GetComponent<SkinnedMeshRenderer>().material = dupMTShirts[2];
        }
        if (isShirtTwo)
        {
            thisShirt.GetComponent<SkinnedMeshRenderer>().material = dupMTShirts[1];
        }
        //if (!isShirtTwo)
        //{
        //    thisShirt.GetComponent<SkinnedMeshRenderer>().material = dupMTShirts[2];
        //}
        if (isShortOne)
        {
            thisPant.GetComponent<SkinnedMeshRenderer>().material = dupMTShorts[0];
        }
        if (!isShortOne && !isShortTwo)
        {
            thisPant.GetComponent<SkinnedMeshRenderer>().material = dupMTShorts[2];
        }
        if (isShortTwo)
        {
            thisPant.GetComponent<SkinnedMeshRenderer>().material = dupMTShorts[1];
        }
        //if (!isShortOne )
        //{
        //    thisPant.GetComponent<SkinnedMeshRenderer>().material = dupMTShorts[2];
        //}
        // (isSGSelected ? new Action(TestMethod) : TestMethod)();
    }
    private static void TestMethod() { }
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
