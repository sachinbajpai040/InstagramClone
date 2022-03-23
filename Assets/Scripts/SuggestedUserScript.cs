using TMPro;
using UnityEngine;
public class SuggestedUserScript : MonoBehaviour
{
    public GameObject dp;
    public TMP_Text userName;
    public TMP_Text otherInfo;
    
    
    public void setter(GenerateSuggestions.SuggesteduserData suggestedUserData)
    {
        userName.text = suggestedUserData.UserName;
        otherInfo.text = suggestedUserData.OtherInfo;
        Debug.Log(suggestedUserData.UserImagePath);
        dp.GetComponent<ImageLoader>().load(suggestedUserData.UserImagePath);
    }
}
