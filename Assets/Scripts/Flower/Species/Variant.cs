public readonly struct Variant
{
    public readonly string phenotype;
    public readonly VariantType type;

    public Variant(string phenotype, VariantType variantType)
    {
        this.phenotype = phenotype;
        this.type = variantType;
    }

}