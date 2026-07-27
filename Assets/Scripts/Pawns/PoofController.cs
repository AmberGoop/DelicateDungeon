using UnityEngine;

public class PoofController : MonoBehaviour
{
    public int lifetime = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        lifetime--;
        if(lifetime<1){
            Destroy(gameObject);
        }
    }
}
