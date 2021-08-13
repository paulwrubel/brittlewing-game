public readonly struct Trait
{
    public readonly string name;
    public readonly char symbol;
    public Trait(string name, char symbol)
    {
        this.name = name;
        this.symbol = char.ToLowerInvariant(symbol);
    }

}