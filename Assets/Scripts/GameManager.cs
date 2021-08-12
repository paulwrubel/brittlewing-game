using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public FlowerPlotGrid flowerPlotGrid;

    // Start is called before the first frame update
    void Start()
    {

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
