using UnityEngine;

[System.Serializable]
public class FlowerItem : Item
{
    public readonly SpeciesType speciesType;
    public readonly Genome genome;
    public readonly VariantType variantType;
    public readonly GrowthStage growthStage;

    public FlowerItem(SpeciesType speciesType, Genome genome, GrowthStage growthStage)
    {
        this.speciesType = speciesType;
        this.genome = genome;
        this.growthStage = growthStage;

        this.variantType = GameManager.Instance.flowerDatabase.data.species
            .Find(s => s.speciesType == speciesType).variants
            .Find(v => v.phenotype == genome.GetPhenotypeGeneric()).variantType;

        this.name = string.Format("{0} {1}", variantType, speciesType.ToString());
        this.value = GameManager.Instance.flowerDatabase.data.species
            .Find(s => s.speciesType == speciesType).variants
            .Find(v => v.phenotype == genome.GetPhenotypeGeneric()).value;
    }

    public override Sprite GetSprite()
    {
        return GetTopSprite();
    }

    public Sprite GetSideSprite()
    {
        return Resources.Load<Sprite>(string.Format("Sprites/Flowers/{0}/{2}/{0}{1}{2}Sprite",
            this.speciesType.ToString(),
            this.variantType.ToString(),
            "Side"));
    }

    public Sprite GetTopSprite()
    {
        return Resources.Load<Sprite>(string.Format("Sprites/Flowers/{0}/{2}/{0}{1}{2}Sprite",
            this.speciesType.ToString(),
            this.variantType.ToString(),
            "Top"));
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
}