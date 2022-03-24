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
    async void Start()
    {
        GetData();
        List<SuggestedUserScript> list = new List<SuggestedUserScript>(10);
        for (int i = 0; i < 10; i++)
        {
            var suggeesteduser = await SuggestedUserReference.InstantiateAsync(transform).Task;
            var suggestedUserScript = suggeesteduser.GetComponent<SuggestedUserScript>();
            suggestedUserScript.setter(suggestionlist[i]);
        }
    }
    private void GetData()
    {
        string json = File.ReadAllText(Application.dataPath + "/Data/SuggestedUserData.json");
        suggestionlist = JsonConvert.DeserializeObject<List<SuggesteduserData>>(json);
    }
}
