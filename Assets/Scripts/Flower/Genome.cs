using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Genome
{

    public SpeciesType speciesType;
    public List<Gene> genes;
    public Genome(SpeciesType species, string genomeString)
    {
        this.speciesType = species;
        this.genes = ParseGenomeString(species, genomeString);
    }

    public Genome(SpeciesType species, List<Gene> genes)
    {
        this.speciesType = species;
        this.genes = genes;
    }


    public Genome Cross(Genome b)
    {
        Genome a = this;

        if (a.speciesType != b.speciesType)
        {
            throw new System.Exception(string.Format("genome A ({0}) is from a different species than genome B ({1})", a.speciesType, b.speciesType));
        }
        if (a.genes.Count != b.genes.Count)
        {
            throw new System.Exception(string.Format("genome A (len={0}) contains a different amount of genes from genome b (len={1})", a.genes.Count, b.genes.Count));
        }

        List<Gene> newGenes = a.genes.Zip(b.genes, (ag, bg) => ag.Cross(bg)).ToList<Gene>();
        return new Genome(a.speciesType, newGenes);
    }

    public string GetGenotype()
    {
        return string.Concat(genes.Select(gene => gene.GetGenotype()));
    }

    public string GetGenotypeGeneric()
    {
        return string.Concat(genes.Select(gene => gene.GetGenotypeGeneric()));
    }

    public string GetPhenotype()
    {
        return string.Concat(genes.Select(gene => gene.GetPhenotype()));
    }

    public string GetPhenotypeGeneric()
    {
        return string.Concat(genes.Select(gene => gene.GetPhenotypeGeneric()));
    }


    private List<Gene> ParseGenomeString(SpeciesType speciesType, string genomeString)
    {
        Debug.Log(speciesType);
        Debug.Log(GameManager.Instance.flowerDatabase.data.species
            .Find(s => EnumUtils.TryParse<SpeciesType>(s.name) == speciesType).traits);

        List<TraitEntry> traits = GameManager.Instance.flowerDatabase.data.species
            .Find(s => EnumUtils.TryParse<SpeciesType>(s.name) == speciesType).traits;

        Debug.Log(traits);

        if (genomeString.Length != traits.Count)
        {
            throw new System.Exception(string.Format("invalid length of genome string ({0}) for species ({1})", genomeString, speciesType));
        }

        List<Gene> genomeList = new List<Gene>(traits.Count);
        for (int i = 0; i < genomeString.Length; i++)
        {
            char geneChar = genomeString[i];
            if (geneChar != '0' && geneChar != '1' && geneChar != '2')
            {
                throw new System.Exception(string.Format("invalid gene number ({0}) provided to genome", geneChar.ToString()));
            }

            char symbol = traits[i].symbol[0];
            Zygosity zygosity;
            switch (geneChar)
            {
                case '0':
                    zygosity = Zygosity.HomozygousRecessive;
                    break;
                case '1':
                    zygosity = Zygosity.Heterozygous;
                    break;
                case '2':
                    zygosity = Zygosity.HomozygousDominant;
                    break;
                default:
                    throw new System.Exception(string.Format("invalid gene number ({0}) provided to genome", geneChar.ToString()));
            }

            genomeList.Add(new Gene(symbol, zygosity));
        }

        return genomeList;
    }
}