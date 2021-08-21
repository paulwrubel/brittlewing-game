using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerDatabase : MonoBehaviour
{

    public FlowerEntry data;
    // public List<string> test;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Data/Flowers/data");
        // print(textAsset);
        // print(textAsset.text);
        data = JsonUtility.FromJson<FlowerEntry>(textAsset.text);

        // test = new List<string>();
        // foreach (SpeciesEntry entry in data.species)
        // {
        //     test.Add(entry.speciesType.ToString());
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
