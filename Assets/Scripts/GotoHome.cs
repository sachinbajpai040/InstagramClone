using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GotoHome : MonoBehaviour
{
    public Button HomeButton;
    void Start()
    {
        HomeButton.onClick.AddListener(SwitchScene);
    }
    void SwitchScene()
    {
        if (SceneManager.GetActiveScene().name != "Home")
            SceneManager.LoadScene("Home");
    }
}
