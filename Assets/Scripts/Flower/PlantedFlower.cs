using UnityEngine;
using UnityEngine.Events;

public class PlantedFlower : MonoBehaviour
{
    public FlowerItem flowerItem;
    public UnityEvent onGrowth;
    public float pollinationChance = 0.2f;

    private SpriteRenderer spriteRenderer;

    public void Initialize(FlowerItem item)
    {
        this.flowerItem = item;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        string spriteFilePath = string.Format("Sprites/Flowers/{0}{1}Sprite",
            flowerItem.speciesType.ToString(),
            flowerItem.variantType.ToString());
        Sprite sprite = Resources.Load<Sprite>(spriteFilePath);
        spriteRenderer.sprite = sprite;
    }

    void Update()
    {

    }

    public bool AdvanceGrowthStage()
    {
        if (this.flowerItem == null)
        {
            return false;
        }

        switch (this.flowerItem.growthStage)
        {
            case GrowthStage.Seedling:
                this.flowerItem = new FlowerItem(this.flowerItem.speciesType,
                    this.flowerItem.genome,
                    GrowthStage.Sprouting
                );
                onGrowth.Invoke();
                return true;
            case GrowthStage.Sprouting:
                this.flowerItem = new FlowerItem(this.flowerItem.speciesType,
                    this.flowerItem.genome,
                    GrowthStage.Flowering
                );
                onGrowth.Invoke();
                return true;
            case GrowthStage.Flowering:
                this.flowerItem = new FlowerItem(this.flowerItem.speciesType,
                    this.flowerItem.genome,
                    GrowthStage.Pollinating
                );
                onGrowth.Invoke();
                return true;
            case GrowthStage.Pollinating:
                return false;
            default:
                return false;
        }
    }
}