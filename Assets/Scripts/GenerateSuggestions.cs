using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GenerateSuggestions : MonoBehaviour
{
    public class SuggesteduserData
    {
        public string UserImagePath;
        public string OtherInfo;
        public string UserName;
    }
    public AssetReference SuggestedUserReference;
    public List<SuggesteduserData> suggestionlist;
    void Start()
    {
        GetData();
        List<SuggestedUserScript> list = new List<SuggestedUserScript>(10);
        for (int i = 0; i < 10; i++)
        {
            SuggestedUserReference.InstantiateAsync(transform).Completed += (go) =>
            {
                var suggestedUserScript = go.Result.GetComponent<SuggestedUserScript>();
                list.Add(suggestedUserScript);
                Debug.Log(list.Capacity);
                if (list.Count == 10)
                {
                    setter(list);
                }
            };
        }
    }
    private void setter(List<SuggestedUserScript> list)
    {
        for (int i = 0; i < 10; i++)
        {
            list[i].setter(suggestionlist[i]);
        }
    }
    private void GetData()
    {
        string json = File.ReadAllText(Application.dataPath + "/Data/SuggestedUserData.json");
        suggestionlist = JsonConvert.DeserializeObject<List<SuggesteduserData>>(json);
    }
}
