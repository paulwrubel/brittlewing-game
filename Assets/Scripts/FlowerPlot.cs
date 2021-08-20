using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class FlowerPlot : MonoBehaviour
{

    public Vector2Int coordinates;
    public GameManager gameManager;
    public GameObject flowerPrefab;

    public PlantedFlower plantedFlower;
    private bool isWatered;

    private BoxCollider2D boxCollider2D;
    private TextMeshProUGUI text;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        text.text = "";
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if the cursor is above this GO
        if (boxCollider2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            Cursor cursor = GameManager.Instance.cursor;
            // if the mouse was clicked and there's not already a flower
            if (Input.GetMouseButtonDown(0))
            {
                switch (cursor.GetSelectedToolType())
                {
                    case ToolType.Spade:
                        FlowerItem heldFlower = cursor.GetHeldItem<FlowerItem>();
                        if (!ContainsFlower() && heldFlower != null)
                        {
                            AddFlower(heldFlower);
                            cursor.SetHeldItem(null);
                        }
                        else if (ContainsFlower() && heldFlower == null)
                        {
                            cursor.SetHeldItem(this.plantedFlower.flowerItem);
                            RemoveFlower();
                        }
                        break;
                    case ToolType.WateringCan:
                        if (!isWatered)
                        {
                            SetIsWatered(true);
                        }
                        break;
                    case ToolType.Scanner:
                        if (ContainsFlower())
                        {
                            cursor.SetSelectedItem(this.plantedFlower.flowerItem);
                        }
                        break;
                }
            }
        }
    }

    public void AddFlower(FlowerItem flowerItem)
    {
        GameObject plantedFlowerGO = Instantiate(flowerPrefab, transform);
        plantedFlower = plantedFlowerGO.GetComponent<PlantedFlower>();
        plantedFlower.flowerItem = flowerItem;
        text.text = plantedFlower.flowerItem.growthStage.ToString();
        plantedFlower.onGrowth.AddListener(() =>
        {
            text.text = plantedFlower.flowerItem.growthStage.ToString();
        });
    }

    public void RemoveFlower()
    {
        Destroy(this.plantedFlower.gameObject);
        this.text.text = "";
        this.plantedFlower = null;
    }

    public bool ContainsFlower()
    {
        return plantedFlower != null;
    }

    public bool IsWatered()
    {
        return isWatered;
    }

    public void SetIsWatered(bool isWatered)
    {
        this.isWatered = isWatered;
        this.spriteRenderer.sprite = Resources.Load<Sprite>(
            string.Format("Sprites/FlowerPlot/FlowerPlot{0}Sprite", isWatered ? "Wet" : "Dry"));
    }

    public bool CanPollinate()
    {
        return this.IsWatered() && this.ContainsFlower() && this.plantedFlower.flowerItem.CanPollinate();
    }

    public bool CanGrow()
    {
        return this.IsWatered() && this.ContainsFlower() && this.plantedFlower.flowerItem.CanGrow();
    }
}
