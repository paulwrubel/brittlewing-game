using System.Collections.Generic;

public static class PhenomeDatabase
{

    public static VariantType GetVariantTypeBySpeciesAndPhenotype(Species species, string phenotype)
    {
        if (!phenomes.ContainsKey(species))
        {
            throw new System.Exception(string.Format("species ({0}) does not exist as key in phenomes", species));
        }
        if (!phenomes[species].ContainsKey(phenotype))
        {
            throw new System.Exception(string.Format("phenotype ({0}) does not exist as key for species ({1}) in phenomes", phenotype, species));
        }
        return phenomes[species][phenotype];
    }

    public static Dictionary<Species, Dictionary<string, VariantType>> phenomes = new Dictionary<Species, Dictionary<string, VariantType>>() {
        {
            Species.Popper, new Dictionary<string, VariantType>(){
                {"11", VariantType.Red},
                {"10", VariantType.Black},
                {"01", VariantType.White},
                {"00", VariantType.Black},
            }
        },
    };

    public static string GetTraitsBySpecies(Species species)
    {
        if (!traits.ContainsKey(species))
        {
            throw new System.Exception(string.Format("species ({0}) does not exist as key in traits", species));
        }
        return traits[species];
    }

    public static Dictionary<Species, string> traits = new Dictionary<Species, string>() {
        {Species.Popper, "rw"},
    };

}