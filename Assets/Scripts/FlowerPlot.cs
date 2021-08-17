using UnityEngine;
using TMPro;

public class FlowerPlot : MonoBehaviour
{

    public Vector2Int coordinates;
    public GameManager gameManager;
    public GameObject flowerPrefab;

    public Flower flower;

    private BoxCollider2D boxCollider2D;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (Input.GetMouseButtonDown(0) && !ContainsFlower())
            {
                AddFlower(gameManager.selectedSpeciesType,
                    new Genome(gameManager.selectedSpeciesType, gameManager.selectedGenomeString),
                    GrowthStage.Seedling);
            }
            else if (Input.GetMouseButtonDown(1) && ContainsFlower())
            {
                RemoveFlower();
            }
        }
    }

    public void AddFlower(SpeciesType speciesType, Genome genome, GrowthStage growthStage)
    {
        GameObject flowerGO = Instantiate(flowerPrefab, transform);
        flower = flowerGO.GetComponent<Flower>();
        flower.Initialize(speciesType, genome, growthStage);
        text.text = flower.growthStage.ToString();
        flower.onGrowth.AddListener(() =>
        {
            text.text = flower.growthStage.ToString();
        });
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
