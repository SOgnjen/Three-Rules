using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private SceneController _sceneController;
    public void PressStart()
    {
        _sceneController.LoadScene("Level 1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
