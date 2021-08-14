using UnityEngine;

public class FlowerPlot : MonoBehaviour
{

    public Vector2Int coordinates;
    public GameManager gameManager;
    public GameObject flowerPrefab;

    public Flower flower;

    private BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (Input.GetMouseButtonDown(0) && !ContainsFlower())
            {
                AddFlower(gameManager.selectedSpeciesType, new Genome(gameManager.selectedSpeciesType, gameManager.selectedGenomeString));
            }
            else if (Input.GetMouseButtonDown(1) && ContainsFlower())
            {
                RemoveFlower();
            }
        }
    }

    public void AddFlower(SpeciesType speciesType, Genome genome)
    {
        GameObject flowerGO = Instantiate(flowerPrefab, transform);
        flower = flowerGO.GetComponent<Flower>();
        flower.Initialize(speciesType, genome);
    }

    public void RemoveFlower()
    {
        Destroy(flower.gameObject);
        flower = null;
    }

    public bool ContainsFlower()
    {
        return flower != null;
    }
}
