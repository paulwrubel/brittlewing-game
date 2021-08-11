using System.Collections;
using System.Collections.Generic;

public class Genome
{

    private List<Gene> genome;
    public Genome(string genomeString)
    {
        this.genome = ParseGenomeString(genomeString);
    }

    private List<Gene> ParseGenomeString(string genomeString)
    {
        if (genomeString.Length % 2 != 0)
        {
            throw new System.Exception("odd-numbered length string provided to genome");
        }

        List<Gene> genomeList = new List<Gene>();
        for (int i = 0; i < genomeString.Length; i += 2)
        {
            char alleleA = genomeString[i];
            char alleleB = genomeString[i + 1];
            if (char.ToLowerInvariant(alleleA) != char.ToLowerInvariant(alleleB))
            {
                throw new System.Exception("non-matching symbols provided to genome: '" + alleleA + "' and '" + alleleB + "'");
            }

            char symbol = char.ToLowerInvariant(alleleA);
            Zygosity zygosity;
            if (char.IsLower(alleleA) && char.IsLower(alleleB))
            {
                zygosity = Zygosity.HomozygousRecessive;
            }
            else if (char.IsUpper(alleleA) && char.IsUpper(alleleB))
            {
                zygosity = Zygosity.HomozygousDominant;
            }
            else
            {
                zygosity = Zygosity.Heterozygous;
            }

            genomeList.Add(new Gene(symbol, zygosity));
        }

        return genomeList;
    }
}