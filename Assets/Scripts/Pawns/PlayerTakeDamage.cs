using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    private GameController gc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="EnemyHitbox") {
            gc.playerHP--;
        }
    }
}
