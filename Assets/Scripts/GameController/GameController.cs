using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public Dictionary<string, int> populations = new Dictionary<string,int>();
    public Dictionary<string, int> maxPopulations = new Dictionary<string,int>();
    public Dictionary<string, int> oldPopulations = new Dictionary<string,int>();
    public Dictionary<string, string> relationships = new Dictionary<string,string>{
    {"dragon","undine"},
    {"dragon","hellbat"},
    {"hellbat","slime"},
    {"mimic","wraith"},
    {"talus","wraith"},
    {"undine","hellbat"}
    };

    public int playerHP = 15;
    public int playerG = 0;




    public int timeOfDay = 0;

    void Start()
    {
        SceneManager.LoadScene("Scenes/UI/AreaSelect", LoadSceneMode.Additive);
        maxPopulations.Add("slime",300);
        maxPopulations.Add("talus",100);
        maxPopulations.Add("wraith",100);
        maxPopulations.Add("undine",100);
        maxPopulations.Add("mimic",100);
        maxPopulations.Add("hellbat",100);
        maxPopulations.Add("dragon",100);

        foreach(var (species,population) in maxPopulations) {
            populations.Add(species,population);
            oldPopulations.Add(species,population);
        }


        
    }





}
