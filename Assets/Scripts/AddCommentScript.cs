using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddCommentScript : MonoBehaviour
{
    public GameObject CommentPrefab;
    public GameObject CommentSection;
    public TMP_InputField CommentText;
    public Button SendButton;
    private void Start()
    {
        CommentText.text = "";
        SendButton.onClick.AddListener(AddComment);
    }

    void AddComment()
    {
        if (CommentText.text != "")
        {
            GameObject Comment = Instantiate(CommentPrefab, CommentSection.transform);
            Comment.GetComponent<TMP_Text>().text = CommentText.text;
            CommentText.text = "";
        }
    }
    private void Update()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(CommentSection.transform as RectTransform);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AddComment();
        }
    }
}
