using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public Dictionary<string, int> populations = new Dictionary<string,int>();
    public Dictionary<string, int> maxPopulations = new Dictionary<string,int>();
    public Dictionary<string, int> oldPopulations = new Dictionary<string,int>();

    public int playerHP = 15;
    public int playerG = 0;


    /*
       if one species predates on another species, then at the end of a day,
       it will decrease its prey species count based on its own count.
       this variable controls how strong this interaction is.
    */
    public float relationMultiplier = 1.2f;

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

        populations.Add("slime",300);
        populations.Add("talus",100);
        populations.Add("wraith",100);
        populations.Add("undine",100);
        populations.Add("mimic",100);
        populations.Add("hellbat",100);
        populations.Add("dragon",100);

        oldPopulations.Add("slime",300);
        oldPopulations.Add("talus",100);
        oldPopulations.Add("wraith",100);
        oldPopulations.Add("undine",100);
        oldPopulations.Add("mimic",100);
        oldPopulations.Add("hellbat",100);
        oldPopulations.Add("dragon",100);
        
    }



}
