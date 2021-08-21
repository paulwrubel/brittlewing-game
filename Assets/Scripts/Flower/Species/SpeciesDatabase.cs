// using System.Collections.Generic;
// using UnityEngine;

// public static class SpeciesDatabase
// {
//     public static Species GetSpeciesBySpeciesType(SpeciesType speciesType)
//     {
//         return species.Find(s => s.type == speciesType);
//     }

//     public static VariantType GetVariantTypeBySpeciesTypeAndPhenotype(SpeciesType speciesType, string phenotype)
//     {
//         return species.Find(s => s.type == speciesType)
//             .variants.Find(v => v.phenotype == phenotype).type;
//     }
// public static int GetValueBySpeciesTypeAndVariantType(SpeciesType speciesType, VariantType variantType)
// {
//     return species.Find(s => s.type == speciesType)
//         .variants.Find(v => v.phenotype == phenotype).type;
// }

// private static List<Species> species = new List<Species>() {
//     new Species(SpeciesType.Popper, Rarity.Common, new List<Trait>(){
//             new Trait("Red", 'r'),
//             new Trait("White", 'w'),
//     }, new List<Variant>(){
//         new Variant("00", VariantType.Black),
//         new Variant("01", VariantType.White),
//         new Variant("10", VariantType.Black),
//         new Variant("11", VariantType.Red),
//     }),
//     new Species(SpeciesType.Genie, Rarity.Common, new List<Trait>(){
//             new Trait("Yellow", 'y'),
//             new Trait("White", 'w'),
//     }, new List<Variant>(){
//         new Variant("00", VariantType.Black),
//         new Variant("01", VariantType.White),
//         new Variant("10", VariantType.Orange),
//         new Variant("11", VariantType.Yellow),
//     }),
//     new Species(SpeciesType.Lull, Rarity.Common, new List<Trait>(){
//             new Trait("Blue", 'b'),
//             new Trait("White", 'w'),
//     }, new List<Variant>(){
//         new Variant("00", VariantType.Grey),
//         new Variant("01", VariantType.White),
//         new Variant("10", VariantType.Purple),
//         new Variant("11", VariantType.Blue),
//     }),
//     new Species(SpeciesType.Frazzil, Rarity.Uncommon, new List<Trait>(){
//             new Trait("Red", 'r'),
//             new Trait("Yellow", 'y'),
//             new Trait("White", 'w'),
//     }, new List<Variant>(){
//         new Variant("000", VariantType.Grey),
//         new Variant("001", VariantType.White),
//         new Variant("010", VariantType.Purple),
//         new Variant("011", VariantType.Blue),
//         new Variant("100", VariantType.Grey),
//         new Variant("101", VariantType.White),
//         new Variant("110", VariantType.Purple),
//         new Variant("111", VariantType.Blue),
//     }),
//     new Species(SpeciesType.Thrombus, Rarity.Uncommon, new List<Trait>(){
//             new Trait("Blue", 'b'),
//             new Trait("Red", 'r'),
//             new Trait("White", 'w'),
//     }, new List<Variant>(){
//         new Variant("000", VariantType.Black),
//         new Variant("001", VariantType.White),
//         new Variant("010", VariantType.Red),
//         new Variant("011", VariantType.Pink),
//         new Variant("100", VariantType.Indigo),
//         new Variant("101", VariantType.Blue),
//         new Variant("110", VariantType.Purple),
//         new Variant("111", VariantType.BrightPurple),
//     }),
//     new Species(SpeciesType.Zydrill, Rarity.Uncommon, new List<Trait>(){
//             new Trait("Yellow", 'y'),
//             new Trait("Green", 'g'),
//             new Trait("White", 'w'),
//     }, new List<Variant>(){
//         new Variant("000", VariantType.Black),
//         new Variant("001", VariantType.White),
//         new Variant("010", VariantType.Black),
//         new Variant("011", VariantType.Green),
//         new Variant("100", VariantType.Black),
//         new Variant("101", VariantType.Yellow),
//         new Variant("110", VariantType.Black),
//         new Variant("111", VariantType.Yellow),
//     }),
//     new Species(SpeciesType.Seacomb, Rarity.Rare, new List<Trait>(){
//             new Trait("Blue", 'b'),
//             new Trait("Green", 'g'),
//             new Trait("Yellow", 'y'),
//             new Trait("White", 'w'),
//     }, new List<Variant>(){
//         new Variant("0000", VariantType.Black),
//         new Variant("0001", VariantType.White),
//         new Variant("0010", VariantType.Orange),
//         new Variant("0011", VariantType.Yellow),
//         new Variant("0100", VariantType.Green),
//         new Variant("0101", VariantType.Green),
//         new Variant("0110", VariantType.Green),
//         new Variant("0111", VariantType.Green),
//         new Variant("1000", VariantType.Black),
//         new Variant("1001", VariantType.Blue),
//         new Variant("1010", VariantType.Green),
//         new Variant("1011", VariantType.Green),
//         new Variant("1100", VariantType.Turquoise),
//         new Variant("1101", VariantType.Silver),
//         new Variant("1110", VariantType.White),
//         new Variant("1111", VariantType.White),
//     }),
// new Species(SpeciesType.Marzipoly, Rarity.Rare, new List<Trait>(){
//         new Trait("Red", 'r'),
//         new Trait("Blue", 'b'),
//         new Trait("Green", 'g'),
//         new Trait("White", 'w'),
// }, new List<Variant>(){
// new Variant("0000", VariantType.EMPTY),
// new Variant("0001", VariantType.EMPTY),
// new Variant("0010", VariantType.EMPTY),
// new Variant("0011", VariantType.EMPTY),
// new Variant("0100", VariantType.EMPTY),
// new Variant("0101", VariantType.EMPTY),
// new Variant("0110", VariantType.EMPTY),
// new Variant("0111", VariantType.EMPTY),
// new Variant("1000", VariantType.EMPTY),
// new Variant("1001", VariantType.EMPTY),
// new Variant("1010", VariantType.EMPTY),
// new Variant("1011", VariantType.EMPTY),
// new Variant("1100", VariantType.EMPTY),
// new Variant("1101", VariantType.EMPTY),
// new Variant("1110", VariantType.EMPTY),
// new Variant("1111", VariantType.EMPTY),
// }),
// new Species(SpeciesType.Chrysalynn, Rarity.Rare, new List<Trait>(){
//         new Trait("Red", 'r'),
//         new Trait("Magenta", 'm'),
//         new Trait("Cyan", 'c'),
//         new Trait("White", 'w'),
// }, new List<Variant>(){
// new Variant("0000", VariantType.EMPTY),
// new Variant("0001", VariantType.EMPTY),
// new Variant("0010", VariantType.EMPTY),
// new Variant("0011", VariantType.EMPTY),
// new Variant("0100", VariantType.EMPTY),
// new Variant("0101", VariantType.EMPTY),
// new Variant("0110", VariantType.EMPTY),
// new Variant("0111", VariantType.EMPTY),
// new Variant("1000", VariantType.EMPTY),
// new Variant("1001", VariantType.EMPTY),
// new Variant("1010", VariantType.EMPTY),
// new Variant("1011", VariantType.EMPTY),
// new Variant("1100", VariantType.EMPTY),
// new Variant("1101", VariantType.EMPTY),
// new Variant("1110", VariantType.EMPTY),
// new Variant("1111", VariantType.EMPTY),
// }),
// new Species(SpeciesType.Brittlewing, Rarity.Legendary, new List<Trait>(){
//         new Trait("Red", 'r'),
//         new Trait("Green", 'g'),
//         new Trait("Blue", 'b'),
//         new Trait("White", 'w'),
//         new Trait("Exotic", 'x'),
// }, new List<Variant>(){
// new Variant("00000", VariantType.EMPTY),
// new Variant("00001", VariantType.EMPTY),
// new Variant("00010", VariantType.EMPTY),
// new Variant("00011", VariantType.EMPTY),
// new Variant("00100", VariantType.EMPTY),
// new Variant("00101", VariantType.EMPTY),
// new Variant("00110", VariantType.EMPTY),
// new Variant("00111", VariantType.EMPTY),
// new Variant("01000", VariantType.EMPTY),
// new Variant("01001", VariantType.EMPTY),
// new Variant("01010", VariantType.EMPTY),
// new Variant("01011", VariantType.EMPTY),
// new Variant("01100", VariantType.EMPTY),
// new Variant("01101", VariantType.EMPTY),
// new Variant("01110", VariantType.EMPTY),
// new Variant("01111", VariantType.EMPTY),
// new Variant("10000", VariantType.EMPTY),
// new Variant("10001", VariantType.EMPTY),
// new Variant("10010", VariantType.EMPTY),
// new Variant("10011", VariantType.EMPTY),
// new Variant("10100", VariantType.EMPTY),
// new Variant("10101", VariantType.EMPTY),
// new Variant("10110", VariantType.EMPTY),
// new Variant("10111", VariantType.EMPTY),
// new Variant("11000", VariantType.EMPTY),
// new Variant("11001", VariantType.EMPTY),
// new Variant("11010", VariantType.EMPTY),
// new Variant("11011", VariantType.EMPTY),
// new Variant("11100", VariantType.EMPTY),
// new Variant("11101", VariantType.EMPTY),
// new Variant("11110", VariantType.EMPTY),
// new Variant("11111", VariantType.EMPTY),
// }),
// new Species(SpeciesType.Nebularaven, Rarity.Legendary, new List<Trait>(){
//         new Trait("Red", 'r'),
//         new Trait("Blue", 'b'),
//         new Trait("Magenta", 'm'),
//         new Trait("White", 'w'),
//         new Trait("Exotic", 'x'),
// }, new List<Variant>(){
// new Variant("00000", VariantType.EMPTY),
// new Variant("00001", VariantType.EMPTY),
// new Variant("00010", VariantType.EMPTY),
// new Variant("00011", VariantType.EMPTY),
// new Variant("00100", VariantType.EMPTY),
// new Variant("00101", VariantType.EMPTY),
// new Variant("00110", VariantType.EMPTY),
// new Variant("00111", VariantType.EMPTY),
// new Variant("01000", VariantType.EMPTY),
// new Variant("01001", VariantType.EMPTY),
// new Variant("01010", VariantType.EMPTY),
// new Variant("01011", VariantType.EMPTY),
// new Variant("01100", VariantType.EMPTY),
// new Variant("01101", VariantType.EMPTY),
// new Variant("01110", VariantType.EMPTY),
// new Variant("01111", VariantType.EMPTY),
// new Variant("10000", VariantType.EMPTY),
// new Variant("10001", VariantType.EMPTY),
// new Variant("10010", VariantType.EMPTY),
// new Variant("10011", VariantType.EMPTY),
// new Variant("10100", VariantType.EMPTY),
// new Variant("10101", VariantType.EMPTY),
// new Variant("10110", VariantType.EMPTY),
// new Variant("10111", VariantType.EMPTY),
// new Variant("11000", VariantType.EMPTY),
// new Variant("11001", VariantType.EMPTY),
// new Variant("11010", VariantType.EMPTY),
// new Variant("11011", VariantType.EMPTY),
// new Variant("11100", VariantType.EMPTY),
// new Variant("11101", VariantType.EMPTY),
// new Variant("11110", VariantType.EMPTY),
// new Variant("11111", VariantType.EMPTY),
// }),
// new Species(SpeciesType.Zorastapodia, Rarity.Legendary, new List<Trait>(){
//         new Trait("Cyan", 'c'),
//         new Trait("Magenta", 'm'),
//         new Trait("Yellow", 'y'),
//         new Trait("White", 'w'),
//         new Trait("Exotic", 'x'),
// }, new List<Variant>(){
// new Variant("00000", VariantType.EMPTY),
// new Variant("00001", VariantType.EMPTY),
// new Variant("00010", VariantType.EMPTY),
// new Variant("00011", VariantType.EMPTY),
// new Variant("00100", VariantType.EMPTY),
// new Variant("00101", VariantType.EMPTY),
// new Variant("00110", VariantType.EMPTY),
// new Variant("00111", VariantType.EMPTY),
// new Variant("01000", VariantType.EMPTY),
// new Variant("01001", VariantType.EMPTY),
// new Variant("01010", VariantType.EMPTY),
// new Variant("01011", VariantType.EMPTY),
// new Variant("01100", VariantType.EMPTY),
// new Variant("01101", VariantType.EMPTY),
// new Variant("01110", VariantType.EMPTY),
// new Variant("01111", VariantType.EMPTY),
// new Variant("10000", VariantType.EMPTY),
// new Variant("10001", VariantType.EMPTY),
// new Variant("10010", VariantType.EMPTY),
// new Variant("10011", VariantType.EMPTY),
// new Variant("10100", VariantType.EMPTY),
// new Variant("10101", VariantType.EMPTY),
// new Variant("10110", VariantType.EMPTY),
// new Variant("10111", VariantType.EMPTY),
// new Variant("11000", VariantType.EMPTY),
// new Variant("11001", VariantType.EMPTY),
// new Variant("11010", VariantType.EMPTY),
// new Variant("11011", VariantType.EMPTY),
// new Variant("11100", VariantType.EMPTY),
// new Variant("11101", VariantType.EMPTY),
// new Variant("11110", VariantType.EMPTY),
// new Variant("11111", VariantType.EMPTY),
// }),
//     };
// }