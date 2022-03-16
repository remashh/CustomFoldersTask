using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using CharacterInfo = DefaultNamespace.CharacterInfo;

public class CharacterLoader : MonoBehaviour
{
    [SerializeField] private string[] characters = new string[2];

    private GameObject currentCharacter;
    private Gender gender;
    [SerializeField] private ColorSetuper colorSetuper;

    public void MaleButton()
    {
        gender = Gender.Male;
        SetupCharacter(characters[0]);
    }
    
    public void FemaleButton()
    {
        gender = Gender.Female;
        SetupCharacter(characters[1]);
    }

    public void HairColorButton()
    {
        ChangeHairColor(HairColor.Brown);
    }
    public void HairColorButtonBlonde()
    {
        ChangeHairColor(HairColor.Blonde);
    }

    private void SetupCharacter(string characterName)
    {
        var config = Resources.Load<CharacterInfo>($"Configs/{characterName}");
        var character = Resources.Load<GameObject>($"CharacterPrefabs/{config.PrefabName}");
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }
        
        currentCharacter = Instantiate(character, Vector3.zero, new Quaternion(0,180,0,1));
    }

    public void ChangeHairColor(HairColor hairColor)
    {
        var hairColorObject = gender == Gender.Female ? currentCharacter.transform.Find("Set Character_Female_Hair_4") :
            currentCharacter.transform.Find("Set Character_Male_Hair_2") ;
        var texture = colorSetuper.GetHairTexture(hairColor, gender);
        hairColorObject.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.mainTexture = texture;
    }
}
