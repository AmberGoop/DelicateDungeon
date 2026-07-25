using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaSelect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void loadArea(string areaToLoad) {
        SceneManager.LoadScene("Scenes/Areas/"+areaToLoad, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Scenes/UI/AreaSelect");

    }
}
