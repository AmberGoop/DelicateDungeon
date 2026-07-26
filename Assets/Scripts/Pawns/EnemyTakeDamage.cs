using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private EnemyController p;
    private GameController gc;
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        p = transform.parent.gameObject.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="PlayerHitbox"&&p.invuln==0) {
            p.health--;
            if(p.health==0){
                gc.populations[p.species]-=1;
                Destroy(transform.parent.gameObject);

            }
            p.invuln=60;

        }
    }
}
