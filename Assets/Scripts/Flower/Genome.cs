using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class Genome
{

    public Species species;
    public List<Gene> genes;
    public Genome(Species species, string genomeString)
    {
        this.species = species;
        this.genes = ParseGenomeString(species, genomeString);
    }

    public Genome(Species species, List<Gene> genes)
    {
        this.species = species;
        this.genes = genes;
    }


    public Genome Cross(Genome b)
    {
        Genome a = this;

        if (a.species != b.species)
        {
            throw new System.Exception(string.Format("genome A ({0}) is from a different species than genome B ({1})", a.species, b.species));
        }
        if (a.genes.Count != b.genes.Count)
        {
            throw new System.Exception(string.Format("genome A (len={0}) contains a different amount of genes from genome b (len={1})", a.genes.Count, b.genes.Count));
        }

        List<Gene> newGenes = a.genes.Zip(b.genes, (ag, bg) => ag.Cross(bg)).ToList<Gene>();
        return new Genome(a.species, newGenes);
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


    private List<Gene> ParseGenomeString(Species species, string genomeString)
    {
        string traits = PhenomeDatabase.GetTraitsBySpecies(species);
        if (genomeString.Length != traits.Length)
        {
            throw new System.Exception(string.Format("invalid length of genome string ({0}) for species ({1})", genomeString, species));
        }

        List<Gene> genomeList = new List<Gene>(traits.Length);
        for (int i = 0; i < genomeString.Length; i++)
        {
            char geneChar = genomeString[i];
            if (geneChar != '0' && geneChar != '1' && geneChar != '2')
            {
                throw new System.Exception(string.Format("invalid gene number ({0}) provided to genome", geneChar.ToString()));
            }

            char symbol = char.ToLowerInvariant(traits[i]);
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