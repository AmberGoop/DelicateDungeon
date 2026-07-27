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
        if(other.tag=="PlayerHitbox"&&p.invuln==0&&p.health!=0) {
            p.health--;
            p.invuln=60;
            if(p.health==0){
                gc.populations[p.species]-=1;
                double gToAdd = p.maxHealth*1.5;
                gc.playerG+=(int) gToAdd;
                p.invuln=0;
                p.timer=80;

            }


        }
    }
}
