using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GeneratePostScript : MonoBehaviour
{
    public GameObject PostPrefab;
    
    public class PostDatum
    {
        public string Name;
        public string Location;
        public string PostImagePath;
        public string UserDpPath;
        public string Tags;
        public string Description;
        public string Comment;
        public string UserName;
    }

    public class Instafeed
    {
        private List<PostDatum> instafeed=new List<PostDatum>();
    }
    public class PostData
    {
        public string[] Name;
        public string[] Location;
        public string[] PostImagePath;
        public string[] UserDpPath;
        public string[] Tags;
        public string[] Description;
        public string[] Comment;
        public string[] UserName;
        public int NumberOfPosts;
    }
    public PostData postData;
    private static readonly Vector2 VectorHalf = new Vector2(0.5f, 0.5f);

    // public async Task<Sprite> load(string path)
    // {
    //     Sprite sprite = null;
    //     if (!IsValidURL(path))
    //     {
    //         StartCoroutine(ImageLoader("file:///" + path,returnValue =>
    //         {
    //             sprite = returnValue;
    //         }));
    //     }
    //     else
    //     {
    //         StartCoroutine(ImageLoader(path, returnValue =>
    //         {
    //            sprite = returnValue;
    //         }));
    //     }
    //     return sprite;
    // }
    private void generatefeed(PostData postData,int index)
    {
        
    }

    void Start()
    {
        GetData();
        for (int i = 0; i < postData.NumberOfPosts; i++)
        {
            var post=Instantiate(PostPrefab,transform);
            var postScript = post.GetComponent<PostScript>();
            postScript.Name.text = postData.Name[i];
            postScript.Location.text = postData.Location[i];
            postScript.Tags.text = postData.Tags[i];
            postScript.Description.text = postData.Description[i];
            postScript.Comment.text = postData.Comment[i];
            postScript.username.text = postData.UserName[i];

            //postScript.Image.GetComponent<Image>().sprite = await load(postData.PostImagePath[i]);
            
            if (!IsValidURL(postData.PostImagePath[i]))
            {
                StartCoroutine(ImageLoader("file:///" + postData.PostImagePath[i],returnValue =>
                {
                    postScript.PostImage.GetComponent<Image>().sprite = returnValue;
                }));
            }
            else
            {
                StartCoroutine(ImageLoader(postData.PostImagePath[i], returnValue =>
                {
                    postScript.PostImage.GetComponent<Image>().sprite = returnValue;
                }));
            }
            if (!IsValidURL(postData.UserDpPath[i]))
            {
                StartCoroutine(ImageLoader(postData.UserDpPath[i],returnValue =>
                {
                    postScript.DpImage.GetComponent<Image>().sprite = returnValue;
                }));
            }
            else
            {
                StartCoroutine(ImageLoader(postData.UserDpPath[i], returnValue =>
                {
                    postScript.DpImage.GetComponent<Image>().sprite = returnValue;
                }));
            }

        }
    }
    
    IEnumerator ImageLoader(string path, System.Action<Sprite> image) {
        UnityWebRequest urlimage = UnityWebRequestTexture.GetTexture(path);
        yield return urlimage.SendWebRequest();
        while (!urlimage.isDone)
        {
            yield return null;
        };
        Texture2D webTexture = ((DownloadHandlerTexture)urlimage.downloadHandler).texture as Texture2D;
        Sprite webSprite = SpriteFromTexture2D (webTexture);
        image(webSprite);
    }
    
    static Sprite SpriteFromTexture2D(Texture2D texture) {

        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height),
            VectorHalf, 100.0f);
    }
    
    public static bool IsValidURL(string url)
    {
        return Uri.IsWellFormedUriString(url, UriKind.Absolute);
    }
    private void GetData()
    {
        string readAllText = File.ReadAllText(Application.dataPath + "/Data/PostData.json");
        postData= JsonUtility.FromJson<PostData>(readAllText);
    }
    

    private void Update()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
    }
}
