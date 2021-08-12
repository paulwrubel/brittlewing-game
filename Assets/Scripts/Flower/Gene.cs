using System.Collections.Generic;

using ExtensionMethods;
[System.Serializable]
public class Gene
{

    public char symbolLower;
    public char symbolUpper;
    public Zygosity zygosity;
    public Gene(char symbol, Zygosity zygosity)
    {
        this.symbolLower = char.ToLowerInvariant(symbol);
        this.symbolUpper = char.ToUpperInvariant(symbol);
        this.zygosity = zygosity;
    }

    public Gene Cross(Gene b)
    {
        Gene a = this;
        Zygosity newZygosity;
        List<Zygosity> possibilities;
        switch (a.zygosity)
        {
            case Zygosity.HomozygousRecessive:
                switch (b.zygosity)
                {
                    case Zygosity.HomozygousRecessive:
                        newZygosity = Zygosity.HomozygousRecessive;
                        break;
                    case Zygosity.Heterozygous:
                        possibilities = new List<Zygosity>(){
                            Zygosity.HomozygousRecessive,
                            Zygosity.Heterozygous,
                        };
                        newZygosity = possibilities.RandomElement();
                        break;
                    case Zygosity.HomozygousDominant:
                        newZygosity = Zygosity.Heterozygous;
                        break;
                    default:
                        throw new System.Exception(string.Format("invalid zygosity ({0})", b.zygosity));
                }
                break;
            case Zygosity.Heterozygous:
                switch (b.zygosity)
                {
                    case Zygosity.HomozygousRecessive:
                        possibilities = new List<Zygosity>(){
                            Zygosity.HomozygousRecessive,
                            Zygosity.Heterozygous,
                        };
                        newZygosity = possibilities.RandomElement();
                        break;
                    case Zygosity.Heterozygous:
                        possibilities = new List<Zygosity>(){
                            Zygosity.HomozygousRecessive,
                            Zygosity.Heterozygous,
                            Zygosity.Heterozygous,
                            Zygosity.HomozygousDominant,
                        };
                        newZygosity = possibilities.RandomElement();
                        break;
                    case Zygosity.HomozygousDominant:
                        possibilities = new List<Zygosity>(){
                            Zygosity.Heterozygous,
                            Zygosity.HomozygousDominant,
                        };
                        newZygosity = possibilities.RandomElement();
                        break;
                    default:
                        throw new System.Exception(string.Format("invalid zygosity ({0})", b.zygosity));
                }
                break;
            case Zygosity.HomozygousDominant:
                switch (b.zygosity)
                {
                    case Zygosity.HomozygousRecessive:
                        newZygosity = Zygosity.Heterozygous;
                        break;
                    case Zygosity.Heterozygous:
                        possibilities = new List<Zygosity>(){
                            Zygosity.Heterozygous,
                            Zygosity.HomozygousDominant,
                        };
                        newZygosity = possibilities.RandomElement();
                        break;
                    case Zygosity.HomozygousDominant:
                        newZygosity = Zygosity.HomozygousDominant;
                        break;
                    default:
                        throw new System.Exception(string.Format("invalid zygosity ({0})", b.zygosity));
                }
                break;
            default:
                throw new System.Exception(string.Format("invalid zygosity ({0})", a.zygosity));
        }
        return new Gene(a.symbolLower, newZygosity);
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
                throw new System.Exception(string.Format("invalid zygosity ({0})", zygosity));
        }
    }

    public string GetGenotypeGeneric()
    {
        switch (zygosity)
        {
            case Zygosity.HomozygousRecessive:
                return "0";
            case Zygosity.Heterozygous:
                return "1";
            case Zygosity.HomozygousDominant:
                return "2";
            default:
                throw new System.Exception(string.Format("invalid zygosity ({0})", zygosity));
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
                throw new System.Exception(string.Format("invalid zygosity ({0})", zygosity));
        }
    }
    public string GetPhenotypeGeneric()
    {
        switch (zygosity)
        {
            case Zygosity.HomozygousRecessive:
                return "0";
            case Zygosity.HomozygousDominant:
            case Zygosity.Heterozygous:
                return "1";
            default:
                throw new System.Exception(string.Format("invalid zygosity ({0})", zygosity));
        }
    }

    public Zygosity GetZygosity()
    {
        return this.zygosity;
    }
}