using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.AddressableAssets;
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

    public AssetReference PostPrefabReference;
    public List<PostDatum> postdata;
    private static readonly Vector2 VectorHalf = new Vector2(0.5f, 0.5f);

    void Start()
    {
        GetData();
        List<PostScript> postlist = new List<PostScript>(10);
        for (int i = 0; i < 10; i++)
        {
            PostPrefabReference.InstantiateAsync(transform).Completed += (go) =>
            {
                var postScript = go.Result.GetComponent<PostScript>();
                postlist.Add(postScript);
                if (postlist.Count == 10)
                {
                    setter(postlist);
                }
            };
        }
    }

    private void setter(List<PostScript> postlist)
    {
        for (int i = 0; i < 10; i++)
        {
            postlist[i].setter(postdata[i]);
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
