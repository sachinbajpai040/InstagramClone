using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PostScript : MonoBehaviour
{
    public TMP_Text Name;
    public TMP_Text Location;
    public TMP_Text Tags;
    public TMP_Text Description;
    public TMP_Text Comment;
    public GameObject PostImage;
    public GameObject DpImage;
    public TMP_Text username;
    public void setter(GeneratePostScript.PostDatum postdata)
    {
        Name.text = postdata.Name;
        Location.text = postdata.Location;
        Tags.text = postdata.Tags;
        Description.text = postdata.Description;
        Comment.text = postdata.Comment;
        username.text = postdata.UserName;
        PostImage.GetComponent<ImageLoader>().load(postdata.PostImagePath);
        DpImage.GetComponent<ImageLoader>().load(postdata.UserDpPath);

        
    }
}