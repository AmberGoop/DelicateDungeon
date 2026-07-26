using UnityEngine;
using UnityEngine.SceneManagement;

public class IntermissionLogic : MonoBehaviour
{
    public SpeciesDisplay[] displays;
    public int foodCost = 4;
    public int revivalCost = 20;
    private GameController gc;
    private GameObject moneyUI;
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        moneyUI = transform.Find("MoneyUI").gameObject;

        string losses = gc.playerG+" G<br>Food & Shelter: -"+foodCost;
        if(gc.playerHP==0) {
            gc.playerG-=revivalCost;
            losses+=" G<br>Revival Fees: -"+revivalCost;
        }
        gc.playerG-=foodCost;
        moneyUI.transform.Find("CurrentMoney").GetComponent<TMPro.TextMeshProUGUI>().text = gc.playerG+" G";
        moneyUI.transform.Find("Losses").GetComponent<TMPro.TextMeshProUGUI>().text = losses+" G";
        gc.calculatePopulations();
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("SpeciesDisplay");
        displays = new SpeciesDisplay[gameObjects.Length];
        for (int i = 0; i<gameObjects.Length;i++) {
            displays[i] = gameObjects[i].GetComponent<SpeciesDisplay>();
        }
        foreach(SpeciesDisplay display in displays) {
            display.updateLabels();
        }

        gc.playerHP = gc.playerMaxHP;
        gc.timeOfDay = 0;
    }

    public void backToAreaSelect() {
        SceneManager.LoadScene("Scenes/UI/AreaSelect", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Scenes/UI/Intermission");
    }
}
