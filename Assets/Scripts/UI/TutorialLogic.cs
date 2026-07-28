using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialLogic : MonoBehaviour
{
    public void returnToTitle() {
        SceneManager.LoadScene("Scenes/Title");
    }
}
