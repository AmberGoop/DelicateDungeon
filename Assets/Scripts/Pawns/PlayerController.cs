using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRB;
    private BoxCollider hitbox;
    public float moveSpeed;
    public Sprite[] idle;
    public Sprite[] walk;
    public Sprite[] atk;
    public int animationTimer;
    private string currentAnimation;
    private Animator animator;
    private SpriteRenderer sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        hitbox = transform.GetChild(1).gameObject.GetComponent<BoxCollider>();
        animator = transform.Find("Sprite").GetComponent<Animator>();
        sprite = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        changeAnimation("turnCCW");
    }

    // Update is called once per frame
    void Update()
    {
        animationTimer++;
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        if(hitbox.enabled==false){playerRB.AddForce(direction.normalized*moveSpeed*Time.deltaTime);}
        if(Input.GetMouseButtonDown(0)&&hitbox.enabled==false) {
            hitbox.enabled=true;
            Invoke(nameof(disableHitbox), 0.5f);
        }
        if(direction.x<0&&hitbox.enabled==false) {
            changeAnimation("turnCW");
            hitbox.center = new Vector3(-0.6f,0,0);
        } else if (direction.x>0&&hitbox.enabled==false){
            changeAnimation("turnCCW");
            hitbox.center = new Vector3(0.6f,0,0);
        }
        if(direction.magnitude==0&&hitbox.enabled==false) {
            sprite.sprite = idle[(animationTimer/30)%2];
        } else if(direction.magnitude>0&&hitbox.enabled==false) {
            sprite.sprite = walk[(animationTimer/20)%4];
        } else {
            sprite.sprite = atk[(animationTimer/10)%2];
        }
    }

    private void disableHitbox() {
        hitbox.enabled=false;
    }
    private void changeAnimation(string animation) {
        if(currentAnimation!=animation) {
            currentAnimation=animation;
            animator.Play(animation);
        }
    }
}
