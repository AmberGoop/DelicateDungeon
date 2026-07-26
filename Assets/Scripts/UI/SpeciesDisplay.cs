using UnityEngine;

public class SpeciesDisplay : MonoBehaviour
{
    public string species;
    public string speciesFriendlyName;



    private GameController gc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Find("SpeciesLabel").GetComponent<TMPro.TextMeshProUGUI>().text = speciesFriendlyName;
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        updateLabels();
    }

    // Update is called once per frame
    public void updateLabels() {
        transform.Find("SpeciesCount").GetComponent<TMPro.TextMeshProUGUI>().text = gc.populations[species] + "/" + gc.maxPopulations[species];
        transform.Find("SpeciesDiff").GetComponent<TMPro.TextMeshProUGUI>().text =  ((gc.populations[species]-gc.oldPopulations[species])<0 ?  "": "+" )+(gc.populations[species]-gc.oldPopulations[species]);
    }


}
