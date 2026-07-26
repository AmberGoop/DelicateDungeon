using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRB;
    private BoxCollider hitbox;
    public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        hitbox = transform.GetChild(1).gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        if(hitbox.enabled==false){playerRB.AddForce(direction.normalized*moveSpeed*Time.deltaTime);}
        if(Input.GetMouseButtonDown(0)&&hitbox.enabled==false) {
            hitbox.enabled=true;
            Invoke(nameof(disableHitbox), 0.5f);
        }

    }

    private void disableHitbox() {
        hitbox.enabled=false;
    }
}
