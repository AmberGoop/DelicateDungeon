using UnityEngine;

public class SpeciesDisplay : MonoBehaviour
{
    public string species;
    public string speciesFriendlyName;

    /*
        if one species predates on another species, then at the end of a day,
        it will decrease its prey species count based on its own count.
        this variable controls how strong this interaction is.
    */
    public float relationMultiplier = 1.2f;

    private GameController gc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Find("SpeciesLabel").GetComponent<TMPro.TextMeshProUGUI>().text = speciesFriendlyName;
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        updateLabels();
    }

    // Update is called once per frame
    private void updateLabels() {
        transform.Find("SpeciesCount").GetComponent<TMPro.TextMeshProUGUI>().text = gc.populations[species] + "/" + gc.maxPopulations[species];
        transform.Find("SpeciesDiff").GetComponent<TMPro.TextMeshProUGUI>().text =  ((gc.populations[species]-gc.oldPopulations[species])<0 ?  "": "+" )+(gc.populations[species]-gc.oldPopulations[species]);
    }

    private void calculatePopulations() {

        foreach(var (predator,prey) in gc.relationships) {
            float predQ = gc.populations[predator];
            float predF = gc.populations[predator];
            float preyQ = gc.populations[prey];
            float preyF = gc.populations[prey];

            //define species quotient (deviation from their "healthy" population)
            predQ /= gc.maxPopulations[predator];
            preyQ /= gc.maxPopulations[prey];

            //apply relation multiplier
            predQ--;
            predQ*=relationMultiplier;
            predQ++;

            preyQ--;
            preyQ*=relationMultiplier;
            preyQ++;

            //multiply final species count by its calculated quotient
            predF*=preyQ; //as predators feed on their prey, increase pred population if prey is over a healthy population (quotient>1), or decrease if prey is under a healthy population (quotient<1)
            preyF/=predQ; //as prey are eaten, decrease prey population if pred is over a healthy population (quotient>1), or increase if pred is under a healthy population (quotient<1)

            //cast final species count to their actual population
            gc.populations[predator] = (int) predF;
            gc.populations[prey] = (int) preyF;

        }
    }
}
