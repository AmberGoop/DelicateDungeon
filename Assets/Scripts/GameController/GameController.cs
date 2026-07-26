using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public Dictionary<string, int> populations = new Dictionary<string,int>();
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
        populations.Add("slime",300);
        populations.Add("talus",100);
        populations.Add("wraith",100);
        populations.Add("undine",100);
        populations.Add("mimic",100);
        populations.Add("hellbat",100);
        populations.Add("dragon",100);
        
    }



}
