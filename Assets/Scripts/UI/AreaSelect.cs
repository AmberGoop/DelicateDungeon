using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaSelect : MonoBehaviour
{
    private GameController gc;
    void Start() {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    public void loadArea(string areaToLoad) {
        SceneManager.LoadScene("Scenes/Areas/"+areaToLoad, LoadSceneMode.Additive);
        gc.selectedArea=areaToLoad;
        SceneManager.UnloadSceneAsync("Scenes/UI/AreaSelect");

    }
}
