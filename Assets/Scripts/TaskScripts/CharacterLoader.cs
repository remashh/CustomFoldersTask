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


    public void MaleButton()
    {
        SetupCharacter(characters[0]);
    }
    public void FemaleButton()
    {
        SetupCharacter(characters[1]);
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
    
}
