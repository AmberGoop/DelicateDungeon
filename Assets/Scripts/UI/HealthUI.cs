using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private GameController gc;
    private TMPro.TextMeshProUGUI healthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        healthText = transform.Find("Health").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text=""+gc.playerHP;
    }
}
