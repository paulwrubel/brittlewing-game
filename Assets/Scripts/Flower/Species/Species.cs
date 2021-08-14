using System.Collections.Generic;

public readonly struct Species
{
    public readonly SpeciesType type;
    public readonly Rarity rarity;
    public readonly List<Trait> traits;
    public readonly List<Variant> variants;

    public Species(SpeciesType speciesType, Rarity rarity, List<Trait> traits, List<Variant> variants)
    {
        this.type = speciesType;
        this.rarity = rarity;
        this.traits = traits;
        this.variants = variants;
    }
}