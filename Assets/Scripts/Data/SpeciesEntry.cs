using System.Collections.Generic;

[System.Serializable]
public struct SpeciesEntry
{
    public SpeciesType speciesType;
    public Rarity rarity;
    public List<TraitEntry> traits;
    public List<VariantEntry> variants;
}