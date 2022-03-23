using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class GenerateSuggestions : MonoBehaviour
{
    public class SuggesteduserData
    {
        public string UserImagePath;
        public string OtherInfo;
        public string UserName;
    }

    public List<SuggesteduserData> suggestionlist;
    public GameObject suggestedUserPrefab;

    void Start()
    {
        
        GetData();
        for (int i = 0; i < 10; i++)
        {
            
            GameObject suggestedUserElement = Instantiate(suggestedUserPrefab,transform);
            var suggestedUserScript = suggestedUserElement.GetComponent<SuggestedUserScript>();
            suggestedUserScript.setter(suggestionlist[i]);
        }
    }


    private void GetData()
    {
        string json = File.ReadAllText(Application.dataPath + "/Data/SuggestedUserData.json");
        suggestionlist = JsonConvert.DeserializeObject<List<SuggesteduserData>>(json);
    }
}
