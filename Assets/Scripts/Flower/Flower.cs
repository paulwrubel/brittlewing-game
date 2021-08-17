using UnityEngine;
using UnityEngine.Events;

public class Flower : MonoBehaviour
{
    public SpeciesType speciesType;
    public Genome genome;
    public VariantType variantType;
    public GrowthStage growthStage;
    public UnityEvent onGrowth;
    public float pollinationChance = 0.2f;

    private SpriteRenderer spriteRenderer;

    public void Initialize(SpeciesType speciesType, Genome genome, GrowthStage growthStage)
    {
        this.speciesType = speciesType;
        this.genome = genome;
        this.variantType = SpeciesDatabase.GetVariantTypeBySpeciesTypeAndPhenotype(this.speciesType, this.genome.GetPhenotypeGeneric());
        this.growthStage = growthStage;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        string spriteFilePath = string.Format("Sprites/Flowers/{0}Sprite", speciesType.ToString() + variantType.ToString());
        Sprite sprite = Resources.Load<Sprite>(spriteFilePath);
        spriteRenderer.sprite = sprite;
    }

    void Update()
    {

    }

    public bool CanPollinate()
    {
        return this.growthStage == GrowthStage.Pollinating;
    }

    public bool CanGrow()
    {
        return this.growthStage == GrowthStage.Seedling ||
            this.growthStage == GrowthStage.Sprouting ||
            this.growthStage == GrowthStage.Flowering;
    }

    public bool AdvanceGrowthStage()
    {
        switch (this.growthStage)
        {
            case GrowthStage.Seedling:
                this.growthStage = GrowthStage.Sprouting;
                onGrowth.Invoke();
                return true;
            case GrowthStage.Sprouting:
                this.growthStage = GrowthStage.Flowering;
                onGrowth.Invoke();
                return true;
            case GrowthStage.Flowering:
                this.growthStage = GrowthStage.Pollinating;
                onGrowth.Invoke();
                return true;
            case GrowthStage.Pollinating:
                return false;
            default:
                return false;
        }
    }
}