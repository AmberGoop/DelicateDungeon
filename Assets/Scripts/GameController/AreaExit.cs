using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string currentArea;
    private GameController gc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
     gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if(other.tag=="Player") {
            gc.timeOfDay+=1;
            if(gc.timeOfDay==3) {
                SceneManager.LoadScene("Scenes/UI/Intermission", LoadSceneMode.Additive);
            } else {
                SceneManager.LoadScene("Scenes/UI/AreaSelect", LoadSceneMode.Additive);
            }
            SceneManager.UnloadSceneAsync("Scenes/Areas/"+currentArea);

        }
    }
}
