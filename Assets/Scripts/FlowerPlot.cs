using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPlot : MonoBehaviour
{

    public Vector2Int coordinates;

    private Flower flower;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (flower == null)
        {
            flower = new Flower(Species.Popper, "RrWw");
        }
    }
}
