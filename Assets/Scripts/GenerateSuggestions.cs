using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class GenerateSuggestions : MonoBehaviour
{
    public class SuggestedUserData
    {
        public string[] UserImagePath=new string[10];
        public int NumberOfSuggestedUsers = 0;
        public string[] OtherInfo=new string[10];
         public string[] UserName=new string[10];

    }
    public GameObject suggestedUserPrefab;
    private SuggestedUserData Suggestions;


    void Start()
    {
        
        GetData();
        for (int i = 0; i < Suggestions.NumberOfSuggestedUsers; i++)
        {
            
            GameObject suggestedUserElement = Instantiate(suggestedUserPrefab,transform);
            var suggestedUserScript = suggestedUserElement.GetComponent<SuggestedUserScript>();
            if (!IsValidURL(Suggestions.UserImagePath[i]))
            {
                StartCoroutine(ImageLoader("file:///" + Suggestions.UserImagePath[i], suggestedUserScript));
            }
            else
            {
                StartCoroutine(ImageLoader(Suggestions.UserImagePath[i],suggestedUserScript));
            }
            suggestedUserScript.userName.text = Suggestions.UserName[i];
            suggestedUserScript.otherInfo.text = Suggestions.OtherInfo[i];
        }
    }
    IEnumerator ImageLoader(string path, SuggestedUserScript suggestedUserScript) {
        UnityWebRequest urlimage = UnityWebRequestTexture.GetTexture(path);
        yield return urlimage.SendWebRequest();
        Texture2D webTexture = ((DownloadHandlerTexture)urlimage.downloadHandler).texture as Texture2D;
        Sprite webSprite = SpriteFromTexture2D (webTexture);
        suggestedUserScript.dp.GetComponent<Image>().sprite = webSprite;
    }
    static Sprite SpriteFromTexture2D(Texture2D texture) {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height),
            new Vector2(0.5f, 0.5f), 100.0f);
    }
    
    
    private void GetData()
    {
        string readAllText = File.ReadAllText(Application.dataPath + "/Data/SuggestedUserData.json");
        Suggestions= JsonUtility.FromJson<SuggestedUserData>(readAllText);
    }
    
    public static bool IsValidURL(string url)
    {
        return Uri.IsWellFormedUriString(url, UriKind.Absolute);
    }
}
