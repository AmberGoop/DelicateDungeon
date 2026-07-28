using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndLogic : MonoBehaviour
{
    private GameController gc;
    public string gameEndString;
    public string gameEndNarrative;
    public string gameEndStats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        switch(gc.gameEndState) {
            case 1:
                gameEndString = "You lost!";
                gameEndNarrative = "As a result of your reckless killing of monsters in the dungeon, you've been labelled an ecoterrorist and incarcerated. At least prison food is better than nothing...";
                break;
            case 2:
                gameEndString = "You Lost!";
                gameEndNarrative = "The loot from the dungeon wasn't enough to break even - not even close. You find yourself in the streets, begging.";
                break;
            case 3:
                gameEndString = "You Won!";
                gameEndNarrative = "You made it through this hardship and saved enough of the loot you attained in the dungeon to save up for College! A bright future with a fulfilling job and life awaits you!";
                break;
        }
        gameEndStats = "Final G: "+gc.playerG+"<br>Days Passed: "+gc.dayCounter;

        transform.Find("WonOrLost").GetComponent<TMPro.TextMeshProUGUI>().text = gameEndString;
        transform.Find("Narration").GetComponent<TMPro.TextMeshProUGUI>().text = gameEndNarrative;
        transform.Find("Stats").GetComponent<TMPro.TextMeshProUGUI>().text = gameEndStats;


    }
    public void returnToTitle() {
        SceneManager.LoadScene("Scenes/Title");
    }


}
