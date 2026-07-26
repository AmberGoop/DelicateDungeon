using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum State {
        Idle,
        Roam,
        Aggro,
        Attack
    };
    public State currentState = State.Idle;
    public int timer = 60;
    public bool facingLeft = true;

    public int baseMoveSpeed = 3000;
    public int fastMoveSpeed = 4500;
    public int atkRange = 2;
    public int visRange = 10;
    public int loseRange = 20;
    public Vector3 moveDirection;
    public Vector3 toPlayer;

    public string species;
    public int invuln = 0;
    public int maxHealth = 3;
    public int health;

    private BoxCollider hitbox;
    private Rigidbody enemyRB;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        hitbox = transform.GetChild(0).gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invuln>0){invuln--;}
        toPlayer=player.transform.position-transform.position;
        toPlayer.y=0;
        switch(currentState){
            case State.Idle:
                timer-=1;
                if(timer<1){
                    currentState=State.Roam;
                    moveDirection= new Vector3(Random.Range(-1f,1f),0,Random.Range(-1f,1f));
                    timer = Random.Range(60,180);
                }
                break;
            case State.Roam:
                timer-=1;
                enemyRB.AddForce(moveDirection.normalized*baseMoveSpeed*Time.deltaTime);
                if(timer<1){
                    currentState=State.Idle;
                    timer = Random.Range(120,480);;
                }
                break;
            case State.Aggro:
                moveDirection=toPlayer;
                if(timer>0){timer-=1;}
                if(toPlayer.magnitude<atkRange) {
                    if(timer<1) {
                        currentState = State.Attack;
                        timer=120;
                    }
                } else {
                    enemyRB.AddForce(moveDirection.normalized*fastMoveSpeed*Time.deltaTime);
                }
                break;
            case State.Attack:
                timer-=1;
                if(timer==105){
                    hitbox.enabled=true;
                }
                if(timer==100){
                    hitbox.enabled=false;
                }
                if(timer<50){
                    if(toPlayer.magnitude>atkRange){
                        currentState=State.Aggro;
                    }
                }
                if(timer<1){
                    timer=120;
                }
                break;

        }



        if((currentState==State.Idle||currentState==State.Roam)&&toPlayer.magnitude<=visRange) {
            currentState=State.Aggro;
            timer=0;
        }
        if(currentState==State.Aggro&&toPlayer.magnitude>=loseRange) {
            currentState=State.Idle;
        }



    }

}
