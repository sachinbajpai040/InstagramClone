using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfileButtonScript : MonoBehaviour
{
    public Button ProfileButton;
    void Start()
    {
        ProfileButton.onClick.AddListener(GoToProfile);
    }
    void GoToProfile()
    {
        if (SceneManager.GetActiveScene().name != "Profile")
            SceneManager.LoadScene("Profile");
    }
}
