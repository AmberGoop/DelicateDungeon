using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate=60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame() {
        SceneManager.LoadScene("Scenes/Controller");
    }
    public void tutorial() {
        SceneManager.LoadScene("Scenes/UI/Tutorial");
    }
    public void quitGame() {
        Application.Quit();
    }
}
