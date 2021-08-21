using System.Collections.Generic;

[System.Serializable]
public struct SpeciesEntry
{
    public string name;
    public string rarity;
    public List<TraitEntry> traits;
    public List<VariantEntry> variants;
}