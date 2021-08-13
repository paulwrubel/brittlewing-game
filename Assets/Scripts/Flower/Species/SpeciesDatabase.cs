using System.Collections.Generic;

public static class SpeciesDatabase
{
    public static Species GetSpeciesBySpeciesType(SpeciesType speciesType)
    {
        return species.Find(s => s.type == speciesType);
    }

    public static VariantType GetVariantTypeBySpeciesTypeAndPhenotype(SpeciesType speciesType, string phenotype)
    {
        return species.Find(s => s.type == speciesType)
            .variants.Find(v => v.phenotype == phenotype).type;
    }

    private static List<Species> species = new List<Species>() {
        new Species(SpeciesType.Popper, Rarity.Common, new List<Trait>(){
                new Trait("Red", 'r'),
                new Trait("White", 'w'),
        }, new List<Variant>(){
            new Variant("00", VariantType.Black),
            new Variant("01", VariantType.White),
            new Variant("10", VariantType.Black),
            new Variant("11", VariantType.Red),
        }),
        new Species(SpeciesType.Genie, Rarity.Common, new List<Trait>(){
                new Trait("Yellow", 'y'),
                new Trait("White", 'w'),
        }, new List<Variant>(){

        }),
        new Species(SpeciesType.Lull, Rarity.Common, new List<Trait>(){
                new Trait("Yellow", 'y'),
                new Trait("White", 'w'),
        }, new List<Variant>(){

        }),
        new Species(SpeciesType.Frazzil, Rarity.Uncommon, new List<Trait>(){
                new Trait("Red", 'r'),
                new Trait("Yellow", 'y'),
                new Trait("White", 'w'),
        }, new List<Variant>(){

        }),
        new Species(SpeciesType.Thrombus, Rarity.Uncommon, new List<Trait>(){
                new Trait("Blue", 'b'),
                new Trait("Red", 'r'),
                new Trait("White", 'w'),
        }, new List<Variant>(){

        }),
        new Species(SpeciesType.Zydrill, Rarity.Uncommon, new List<Trait>(){
                new Trait("Yellow", 'y'),
                new Trait("Green", 'g'),
                new Trait("White", 'w'),
        }, new List<Variant>(){

        }),
        new Species(SpeciesType.Seacomb, Rarity.Rare, new List<Trait>(){
                new Trait("Blue", 'b'),
                new Trait("Green", 'g'),
                new Trait("Yellow", 'y'),
                new Trait("White", 'w'),
        }, new List<Variant>(){

        }),
        new Species(SpeciesType.Marzipoly, Rarity.Rare, new List<Trait>(){
                new Trait("Red", 'r'),
                new Trait("Blue", 'b'),
                new Trait("Green", 'g'),
                new Trait("White", 'w'),
        }, new List<Variant>(){

        }),
        new Species(SpeciesType.Chrysalynn, Rarity.Rare, new List<Trait>(){
                new Trait("Red", 'r'),
                new Trait("Magenta", 'm'),
                new Trait("Cyan", 'c'),
                new Trait("White", 'w'),
        }, new List<Variant>(){

        }),
        new Species(SpeciesType.Brittlewing, Rarity.Legendary, new List<Trait>(){
                new Trait("Red", 'r'),
                new Trait("Green", 'g'),
                new Trait("Blue", 'b'),
                new Trait("White", 'w'),
                new Trait("Exotic", 'x'),
        }, new List<Variant>(){

        }),
        new Species(SpeciesType.Nebularaven, Rarity.Legendary, new List<Trait>(){
                new Trait("Red", 'r'),
                new Trait("Blue", 'b'),
                new Trait("Magenta", 'm'),
                new Trait("White", 'w'),
                new Trait("Exotic", 'x'),
        }, new List<Variant>(){

        }),
        new Species(SpeciesType.Zorastapodia, Rarity.Legendary, new List<Trait>(){
                new Trait("Cyan", 'c'),
                new Trait("Magenta", 'm'),
                new Trait("Yellow", 'y'),
                new Trait("White", 'w'),
                new Trait("Exotic", 'x'),
        }, new List<Variant>(){

        }),
    };
}