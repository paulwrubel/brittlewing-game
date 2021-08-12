using UnityEngine;

public class FlowerPlot : MonoBehaviour
{

    public Vector2Int coordinates;
    public GameObject flowerPrefab;

    public Flower flower;

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
            AddFlower(Species.Popper, new Genome(Species.Popper, "11"));
        }
    }

    public void AddFlower(Species species, Genome genome)
    {
        GameObject flowerGO = Instantiate(flowerPrefab, transform);
        flower = flowerGO.GetComponent<Flower>();
        flower.Initialize(species, genome);
    }

    public bool ContainsFlower()
    {
        return flower != null;
    }
}
