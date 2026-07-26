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
    {"hellbat","slime"},
    {"mimic","wraith"},
    {"talus","mimic"},
    {"undine","hellbat"}
    };
    /*
     i f one species predates on another *species, then at the end of a day,
     it will decrease its prey species count based on its own count.
     this variable controls how strong this interaction is.
     */
    public float relationMultiplier = 0.8f;

    public int playerMaxHP = 15;
    public int playerHP;
    public int playerG = 0;



    public string selectedArea;
    public int timeOfDay = 0;

    void Start()
    {
        playerHP = playerMaxHP;
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

    public void calculatePopulations() {

        foreach(var (predator,prey) in relationships) {
            float predQ = populations[predator];
            float predF = populations[predator];
            float preyQ = populations[prey];
            float preyF = populations[prey];

            if(prey=="slime") {
               print("predQ: "+predQ+"    STORED pred: " + populations[predator]);


            }
            //define species quotient (deviation from their "healthy" population)
            predQ /= maxPopulations[predator];
            preyQ /= maxPopulations[prey];

            //apply relation multiplier
            predQ--;
            predQ*=relationMultiplier;
            predQ++;

            preyQ--;
            preyQ*=relationMultiplier;
            preyQ++;

            //multiply final species count by its calculated quotient
            predF*=preyQ; //as predators feed on their prey, increase pred population if prey is over a healthy population (quotient>1), or decrease if prey is under a healthy population (quotient<1)
            preyF/=predQ; //as prey are eaten, decrease prey population if pred is over a healthy population (quotient>1), or increase if pred is under a healthy population (quotient<1)

            if(prey=="slime") {
                print("AFTER FINAL CALCULATION");
                print("predQ: "+predQ+"    predF:"+ predF + "      CASTED INT predF: "+ (int) predF);


            }

            //cast final species count to their actual population
            populations[predator] = (int) predF;
            populations[prey] = (int) preyF;

            if(prey=="slime") {
                print("AFTER APPLICATION");
                print("predQ: "+predQ+"    STORED pred: " + populations[predator]);


            }

        }


    }

    public void die() {
        SceneManager.LoadScene("Scenes/UI/Intermission", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Scenes/Areas/"+selectedArea);
    }



}
