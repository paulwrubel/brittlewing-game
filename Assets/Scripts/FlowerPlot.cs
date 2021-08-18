using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class FlowerPlot : MonoBehaviour
{

    public Vector2Int coordinates;
    public GameManager gameManager;
    public GameObject flowerPrefab;

    public PlantedFlower plantedFlower;

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
                AddFlower(new FlowerItem(gameManager.selectedSpeciesType,
                    new Genome(gameManager.selectedSpeciesType, gameManager.selectedGenomeString),
                    GrowthStage.Seedling));
            }
            else if (Input.GetMouseButtonDown(1) && ContainsFlower())
            {
                RemoveFlower();
            }
        }
    }

    public void AddFlower(FlowerItem flowerItem)
    {
        GameObject plantedFlowerGO = Instantiate(flowerPrefab, transform);
        plantedFlower = plantedFlowerGO.GetComponent<PlantedFlower>();
        plantedFlower.Initialize(flowerItem);
        text.text = plantedFlower.flowerItem.growthStage.ToString();
        plantedFlower.onGrowth.AddListener(() =>
        {
            text.text = plantedFlower.flowerItem.growthStage.ToString();
        });
    }

    public void RemoveFlower()
    {
        Destroy(plantedFlower);
        plantedFlower = null;
    }

    public bool ContainsFlower()
    {
        return plantedFlower != null;
    }
}
