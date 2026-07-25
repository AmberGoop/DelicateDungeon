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
    private BoxCollider leftHitbox;
    private BoxCollider rightHitbox;
    private Rigidbody enemyRB;

    public int moveSpeed = 5000;
    public Vector3 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState){
            case State.Idle:
                timer-=1;
                if(timer<1){
                    currentState=State.Roam;
                    moveDirection= new Vector3(Random.Range(-1f,1f),0,Random.Range(-1f,1f)).normalized;
                    timer = 60;
                }
                break;
            case State.Roam:
                timer-=1;
                enemyRB.AddForce(moveDirection*moveSpeed*Time.deltaTime);
                if(timer<1){
                    currentState=State.Idle;
                    timer = 60;
                }
                break;

        }
    }
}
