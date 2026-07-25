using UnityEngine;

public class GameController : MonoBehaviour
{
    public int enemySlimeCount = 300;
    public int enemyGolemCount = 100;
    public int enemyWraithCount = 100;
    public int enemyUndineCount = 100;
    public int enemyMimicCount = 100;
    public int enemyHellbatCount = 100;
    public int enemyDragonCount = 100;


    /*
       if one species predates on another species, then at the end of a day,
       it will decrease its prey species count based on its own count.
       this variable controls how strong this interaction is.
    */
    public float relationMultiplier = 1.2f;

    void Start()
    {
        
    }



}
