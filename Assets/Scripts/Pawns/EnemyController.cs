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
    private SpriteRenderer sprite;
    private Animator animator;
    public int animationTimer=0;
    private string currentAnimation= "";
    public Sprite spriteIdle1;
    public Sprite spriteIdle2;
    public Sprite spriteWalk1;
    public Sprite spriteWalk2;
    public Sprite spriteAtk1;
    public Sprite spriteAtk2;

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
    private TMPro.TextMeshProUGUI healthDisplay;
    private Rigidbody enemyRB;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        enemyRB = GetComponent<Rigidbody>();
        sprite = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        animator = transform.Find("Sprite").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        hitbox = transform.GetChild(0).gameObject.GetComponent<BoxCollider>();
        healthDisplay = transform.Find("HealthDisplay").Find("HealthNum").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        animationTimer++;

        healthDisplay.text = ""+health;
        if(invuln>0){invuln--;}
        toPlayer=player.transform.position-transform.position;
        toPlayer.y=0;
        switch(currentState){
            case State.Idle:
                if((animationTimer/30)%2==0) {
                    sprite.sprite=spriteIdle1;
                } else {
                    sprite.sprite=spriteIdle2;
                }
                timer-=1;
                if(timer<1){
                    currentState=State.Roam;
                    moveDirection= new Vector3(Random.Range(-1f,1f),0,Random.Range(-1f,1f));
                    timer = Random.Range(60,180);
                }
                break;
            case State.Roam:
                if((animationTimer/30)%2==0) {
                    sprite.sprite=spriteWalk1;
                } else {
                    sprite.sprite=spriteWalk2;
                }
                timer-=1;
                enemyRB.AddForce(moveDirection.normalized*baseMoveSpeed*Time.deltaTime);
                if(timer<1){
                    currentState=State.Idle;
                    timer = Random.Range(120,480);;
                }
                break;
            case State.Aggro:
                if((animationTimer/30)%2==0) {
                    sprite.sprite=spriteWalk1;
                } else {
                    sprite.sprite=spriteWalk2;
                }
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
                if(timer==119) {
                    sprite.sprite=spriteAtk1;
                }
                if(timer==105){
                    hitbox.enabled=true;
                    sprite.sprite=spriteAtk2;
                }
                if(timer==100){
                    hitbox.enabled=false;
                }
                if(timer<50){
                    if(toPlayer.magnitude>atkRange){
                        currentState=State.Aggro;
                    }
                    sprite.sprite=spriteIdle1;
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
        if(moveDirection.x>0){
            changeAnimation("turnCCW");
        } else {
            changeAnimation("turnCW");
        }


    }

    private void changeAnimation(string animation) {
        if(currentAnimation!=animation) {
            currentAnimation=animation;
            animator.Play(animation);
        }
    }

}
