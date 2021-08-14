using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public FlowerPlotGrid flowerPlotGrid;
    public SpeciesType selectedSpeciesType;
    public string selectedGenomeString;

    // Start is called before the first frame update
    void Start()
    {
        selectedSpeciesType = SpeciesType.Popper;
        selectedGenomeString = "11";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Generate"))
        {
            print("generating!");
            flowerPlotGrid.BreedAll();
        }
    }
}
