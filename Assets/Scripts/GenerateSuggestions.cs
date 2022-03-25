using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMPro;
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
        await GetData();
        for (int i = 0; i < 10; i++)
        {
            var suggesteduser = await SuggestedUserReference.InstantiateAsync(transform).Task;
            var suggestedUserScript = suggesteduser.GetComponent<SuggestedUserScript>();
            suggestedUserScript.setter(suggestionlist[i]);
        }
    }
    private async Task GetData()
    {
        
        var file = await Addressables.LoadAssetAsync<TextAsset>("Data/SuggestedUserData").Task;
        suggestionlist = JsonConvert.DeserializeObject<List<SuggesteduserData>>(file.ToString());
    }
}
