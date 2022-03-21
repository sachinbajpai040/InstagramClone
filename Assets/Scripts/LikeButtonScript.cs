using UnityEngine;
using UnityEngine.UI;

public class LikeButtonScript : MonoBehaviour
{
    public Button LikeButton;
    private bool IsActive;
    public Sprite EnabledLikeButton;
    public Sprite DisabledLikeButton;
    void Start()
    {
        IsActive = false;
        LikeButton.onClick.AddListener(ChangeLikeStatus);
    }
    void ChangeLikeStatus()
    {
        if (IsActive)
        {
            LikeButton.GetComponent<Image>().sprite = DisabledLikeButton;
            IsActive = false;
        }
        else
        {
            LikeButton.GetComponent<Image>().sprite = EnabledLikeButton;
            IsActive = true;
        }
    }
}
