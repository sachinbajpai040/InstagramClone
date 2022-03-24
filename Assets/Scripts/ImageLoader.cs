using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader:MonoBehaviour
{
    [SerializeField]
    private Image Image;
    private static readonly Vector2 VectorHalf = new Vector2(0.5f, 0.5f);

    public void load(string path)
    {
        
        if (!IsValidURL(path))
        {
            StartCoroutine(Loader("file:///" + Application.dataPath+path));
        }
        else
        {
            StartCoroutine(Loader(path));
        }
    }
    public static bool IsValidURL(string url)
    {
        return Uri.IsWellFormedUriString(url, UriKind.Absolute);
    }
    IEnumerator Loader(string path) {
        UnityWebRequest urlimage = UnityWebRequestTexture.GetTexture(path);
        yield return urlimage.SendWebRequest();
        while (!urlimage.isDone)
        {
            yield return null;
        };
        Texture2D webTexture = ((DownloadHandlerTexture)urlimage.downloadHandler).texture as Texture2D;
        Sprite webSprite = SpriteFromTexture2D (webTexture);
        Image.sprite = webSprite;
    }
        
    static Sprite SpriteFromTexture2D(Texture2D texture) {

        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height),
            VectorHalf, 100.0f);
    }
}