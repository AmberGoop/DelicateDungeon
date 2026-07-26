using UnityEngine;

public class DEBUG : MonoBehaviour
{
    private GameController gc;
    public SpeciesDisplay[] displays;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TEST() {
    gc.calculatePopulations();
    GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("SpeciesDisplay");
    displays = new SpeciesDisplay[gameObjects.Length];
    for (int i = 0; i<gameObjects.Length;i++) {
        displays[i] = gameObjects[i].GetComponent<SpeciesDisplay>();
    }
    foreach(SpeciesDisplay display in displays) {
        display.updateLabels();
    }
    }
}
