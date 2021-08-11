public class Gene
{

    private char symbolLower;
    private char symbolUpper;
    private Zygosity zygosity;
    public Gene(char symbol, Zygosity zygosity)
    {
        this.symbolLower = char.ToLowerInvariant(symbol);
        this.symbolUpper = char.ToUpperInvariant(symbol);
        this.zygosity = zygosity;
    }

    public string GetGenotype()
    {
        switch (zygosity)
        {
            case Zygosity.HomozygousDominant:
                return symbolUpper.ToString() + symbolUpper.ToString();
            case Zygosity.HomozygousRecessive:
                return symbolLower.ToString() + symbolLower.ToString();
            case Zygosity.Heterozygous:
                return symbolUpper.ToString() + symbolLower.ToString();
            default:
                throw new System.Exception("invalid zygosity");
        }
    }

    public string GetPhenotype()
    {
        switch (zygosity)
        {
            case Zygosity.HomozygousDominant:
            case Zygosity.Heterozygous:
                return symbolUpper.ToString();
            case Zygosity.HomozygousRecessive:
                return symbolLower.ToString();
            default:
                throw new System.Exception("invalid zygosity");
        }
    }

    public Zygosity GetZygosity()
    {
        return this.zygosity;
    }
}