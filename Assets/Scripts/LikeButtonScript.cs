using System;
using UnityEngine;
using UnityEngine.UI;

public class LikeButtonScript : MonoBehaviour
{
    public Button LikeButton;
    private bool IsActive;
    public Sprite EnabledLikeButton;
    public Sprite DisabledLikeButton;
    private Image _likeImage;

    private void Awake()
    {
        _likeImage=LikeButton.GetComponent<Image>();
    }

    void Start()
    {
        IsActive = false;
        LikeButton.onClick.AddListener(ChangeLikeStatus);
    }
    void ChangeLikeStatus()
    {
        if (IsActive)//IsLiked
        {
            _likeImage.sprite = DisabledLikeButton;
            IsActive = false;
        }
        else
        {
            _likeImage.sprite = EnabledLikeButton;
            IsActive = true;
        }
    }

    void SetLiked()
    {
        _likeImage.sprite = EnabledLikeButton;
        IsActive = true;
    }

    void SetNotLiked()
    {
        _likeImage.sprite = DisabledLikeButton;
        IsActive = false;
    }
}
