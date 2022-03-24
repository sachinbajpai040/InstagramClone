using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
public class GeneratePostScript : MonoBehaviour
{
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
    public AssetReference PostPrefabReference;
    public List<PostDatum> postdata;
    private static readonly Vector2 VectorHalf = new Vector2(0.5f, 0.5f);
    void Start()
    {
        GetData();
        LoadPosts();
    }
    private async void LoadPosts()
    {
        for (var i = 0; i < postdata.Count; i++)
        {
            var post=await PostPrefabReference.InstantiateAsync(transform).Task;
            var postScript = post.GetComponent<PostScript>();
            postScript.setter(postdata[i]);
        }
    }
    private void GetData()
    {
        Debug.Log(Application.dataPath);
        string json = File.ReadAllText(Application.dataPath + "/Data/PostData.json");
        postdata = JsonConvert.DeserializeObject<List<PostDatum>>(json);
    }
    private void Update()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
    }
}
