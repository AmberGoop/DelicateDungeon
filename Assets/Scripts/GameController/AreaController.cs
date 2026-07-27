using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaController : MonoBehaviour
{
    public string currentArea;
    public GameObject[] enemies;
    public Vector2 spawnCorner1;
    public Vector2 spawnCorner2;
    private GameController gc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
    gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scenes/Areas/"+currentArea));
    spawnMonsters();
    }

    private void OnTriggerEnter(Collider other)
    {
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
    private void spawnMonsters() {
        foreach(GameObject enemy in enemies) {
            for(int i =0; i<gc.populations[enemy.GetComponent<EnemyController>().species]&&i<4;i++) {
                Instantiate(enemy, new Vector3(
                    Random.Range(spawnCorner1.x, spawnCorner2.x),
                    2,
                    Random.Range(spawnCorner1.y, spawnCorner2.y)
                ),  Quaternion.identity);
            }
        }
    }
}
