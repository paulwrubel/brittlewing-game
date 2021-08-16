using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public FlowerPlotGrid flowerPlotGrid;
    public SpeciesType selectedSpeciesType;
    public string selectedGenomeString;
    public ToolType selectedTool;

    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        selectedSpeciesType = SpeciesType.Popper;
        selectedGenomeString = "11";
        selectedTool = ToolType.Scanner;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
