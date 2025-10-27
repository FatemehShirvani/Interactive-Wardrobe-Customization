using UnityEngine;
using System.IO;
using System;
using SimpleFileBrowser;
using System.Collections;

public class CharacterSaveManager : MonoBehaviour
{
    public CustomizeCharacterManager characterManager;
    public CharacterClothingManager clothingManager;


    public void ShowSaveDialog()
    {
        StartCoroutine(ShowSaveDialogCoroutine());
    }

    private IEnumerator ShowSaveDialogCoroutine()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("JSON Files", ".json"));
        FileBrowser.SetDefaultFilter(".json");
        
       yield return FileBrowser.WaitForSaveDialog(
            pickMode: FileBrowser.PickMode.Files,
            allowMultiSelection: false,
            initialPath: null,            
            initialFilename: "CharacterSave.json", 
            title: "Save Character",     
            saveButtonText: "Save"       
        );
     
        
        if (FileBrowser.Success && FileBrowser.Result.Length > 0)
        {
            string path = FileBrowser.Result[0];
            if (!path.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
            path += ".json";

            SaveCharacter(path);
        }
    }
    public void SaveCharacter(string path)
    {
        CharacterSaveData data = new CharacterSaveData();

        // body and hair
        data.bodyTypeName = characterManager.GetBodySpriteName();
        data.hairstyleName = characterManager.GetHairSpriteName();

        // body and hair colors
        data.bodyColor = characterManager.GetBodyColor();
        data.hairColor = characterManager.GetHairColor();

        // clothing
        if (clothingManager.currentlyEquippedTop != null)
        {
            data.topClothingName = clothingManager.currentlyEquippedTop.name;
            data.topColor = clothingManager.topRenderer.material.color;

            Texture patternTex = clothingManager.topRenderer.material.GetTexture("_PatternTex");
            data.topPatternName = patternTex != null ? patternTex.name : null;
        }

        if (clothingManager.currentlyEquippedBottom != null)
        {
            data.bottomClothingName = clothingManager.currentlyEquippedBottom.name;
            data.bottomColor = clothingManager.bottomRenderer.material.color;

            Texture patternTex = clothingManager.bottomRenderer.material.GetTexture("_PatternTex");
            data.bottomPatternName = patternTex != null ? patternTex.name : null;
        }


        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
        Debug.Log("Character saved to " + path);
    }

        public void ShowLoadDialog()
    {
        StartCoroutine(ShowLoadDialogCoroutine());
    }

    private IEnumerator ShowLoadDialogCoroutine()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("JSON Files", ".json"));
        FileBrowser.SetDefaultFilter(".json");

        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");

        yield return FileBrowser.WaitForLoadDialog(
            FileBrowser.PickMode.Files,
            false,
            null,
            null,
            "Select Character File",
            "Load"
        );

        if (FileBrowser.Success && FileBrowser.Result.Length > 0)
        {
            string path = FileBrowser.Result[0]; 
            LoadCharacter(path);
        }
    }


    public void LoadCharacter(string path)
    {
        if (!File.Exists(path)) return;

        string json = File.ReadAllText(path);
        CharacterSaveData data = JsonUtility.FromJson<CharacterSaveData>(json);

        // restore body and hair

        Sprite[] bodySprites = Resources.LoadAll<Sprite>("sprites/body");
        Sprite bodySprite = Array.Find(bodySprites, s => s.name == data.bodyTypeName);

        if (bodySprite == null)
        {
            Debug.LogError($"Could not find sprite with name {data.bodyTypeName}");
        }
        else
        {
            Debug.Log($"Loaded sprite: {bodySprite.name}");
            characterManager.UpdateBodySprite(bodySprite);
            characterManager.SetBodyColor(data.bodyColor);
        }

        Sprite[] hairSprites = Resources.LoadAll<Sprite>("sprites/hairstyle");
        Sprite hairSprite = Array.Find(hairSprites, s => s.name == data.hairstyleName);

        if (hairSprite == null)
        {
            Debug.LogError($"Could not find sprite with name {data.hairstyleName}");
        }
        else
        {
            Debug.Log($"Loaded sprite: {bodySprite.name}");
            characterManager.UpdateHairstyleSprite(hairSprite);
            characterManager.SetHairColor(data.hairColor);
        }

        characterManager.RefreshMainOutlines();


        // restore clothing

        if (!string.IsNullOrEmpty(data.topClothingName))
        {
            clothingManager.EquipTopByName(data.topClothingName);
            clothingManager.topRenderer.material.color = data.topColor;
        }
        if (!string.IsNullOrEmpty(data.bottomClothingName))
        {
            clothingManager.EquipBottomByName(data.bottomClothingName);
            clothingManager.bottomRenderer.material.color = data.bottomColor;
        }
        if (!string.IsNullOrEmpty(data.topPatternName))
        {
            Texture2D patternTex = Resources.Load<Texture2D>($"patterns/{data.topPatternName}");
            if (patternTex != null)
                clothingManager.topRenderer.material.SetTexture("_PatternTex", patternTex);
            clothingManager.topRenderer.material.SetFloat("_UsePattern", 1f);
        }
        else
        {
            clothingManager.topRenderer.material.SetFloat("_UsePattern", 0f);
        }
        if (!string.IsNullOrEmpty(data.bottomPatternName))
        {
            Texture2D patternTex = Resources.Load<Texture2D>($"patterns/{data.bottomPatternName}");
            if (patternTex != null)
                clothingManager.bottomRenderer.material.SetTexture("_PatternTex", patternTex);
            clothingManager.bottomRenderer.material.SetFloat("_UsePattern", 1f);
        }
        else
        {
            clothingManager.bottomRenderer.material.SetFloat("_UsePattern", 0f);
        }

        Debug.Log("Character loaded");
    }
}
