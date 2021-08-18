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

        this.variantType = SpeciesDatabase.GetVariantTypeBySpeciesTypeAndPhenotype(speciesType, genome.GetPhenotypeGeneric());
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