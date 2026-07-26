using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public Dictionary<string, int> populations = new Dictionary<string,int>();
    public Dictionary<string, int> oldPopulations = new Dictionary<string,int>();
    public string[] speciesTypes = {"dragon","talus","undine","hellbat","mimic","wraith","slime"};
    public Dictionary<string, string> relationships = new Dictionary<string,string>{
    {"undine", "dragon"},
    {"slime", "hellbat"},
    {"wraith","mimic"},
    {"mimic","talus"},
    {"hellbat","undine"}
    };

    public int playerMaxHP = 15;
    public int playerHP;
    public int playerG = 0;


    public int healthyPopulation = 10;
    public string selectedArea;
    public int timeOfDay = 0;

    void Start()
    {
        playerHP = playerMaxHP;
        SceneManager.LoadScene("Scenes/UI/AreaSelect", LoadSceneMode.Additive);
        foreach(string species in speciesTypes) {
            populations.Add(species,healthyPopulation);
            oldPopulations.Add(species,healthyPopulation);
        }

    }

    public void calculatePopulations() {
        foreach(string species in speciesTypes) {
            if(populations[species]<12) {
                if(relationships.ContainsKey(species)){
                    if(populations[relationships[species]]<=healthyPopulation) {
                        populations[species]++;
                    }
                } else {
                    populations[species]++;
                }
                }
        }
    }

    public void die() {
        SceneManager.LoadScene("Scenes/UI/Intermission", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Scenes/Areas/"+selectedArea);
    }



}
