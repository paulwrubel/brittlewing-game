# Brittlewing Game Design Document

## Preamble

TODO:

### Concept

TODO:

## Genre and Influences

- Animal Crossing flower breeding and genetics mechanic
- casual games
- puzzle games

## Mechanics

### Planting and Breeding Flowers

Flowers can be planted, watered, and picked. Flowers each have a genome which
consists of some number of genes. Two flowers can pollinate each other to create
a child, whose genome is determined from the genomes of its parents via a
punnett square.

There are differing classes of flowers, separated be the number of genes in
their genome:

- Common (2 Genes)
- Uncommon (3 Genes)
- Rare (4 Genes)
- Exotic (5 Genes)

Flowers can be planted at any stage, but can only be purchased and created as
seeds. There are four stages to a flower's life:

1. Seed/Seedling
   - A flower in this stage cannot be interacted with in any way, except to
     remove it from the planter
   - This is the stage flowers are always purchased in
2. Sprouting
   - A sprouting flower signifies that the flower can successfully grow
   - This stage is functionally identical to a seedling and simply signifies
     progress
3. Flowering
   - a flowering flower plant produces flowers, which allows the player to check
     the variant of flower
4. Pollinating
   - A pollinating flower can pollinate other flowers and produce offspring

### Selling Flowers and Purchasing Seeds

TODO: more details

Flower seeds can be purchased from a vendor

Flower seeds of a particular variant are always the same genetic code unless
otherwise indicated.

### Research

A tutorial character named FLORIA (Flower Laboratory Operational Research and
Improvement Assistant) will help guide the player through the initial stages of
the game, in introduce the mechanic of research, which drives much of the game's
progress

TODO: better name for Research Tokens

Flowers can be provided to a machine, which will sequence its genetic code to
produce "Research Tokens". These tokens can be redeemed for scientific
discoveries, which unlock new mechanics or flowers in order to progress.

#### Researchable Discoveries

- Ability to inspect genetic code of flowers
  - Lv 1: Inspect 1 Gene
  - Lv 2: Inspect 2 Gene
  - Lv 3: Inspect 3 Gene (for applicable flowers)
  - Lv 4: Inspect 4 Gene (for applicable flowers)
  - Lv 5: Inspect 5 Gene (for applicable flowers)
- Ability to pollinate across species to produce hybrid flowers
  - Lv 1: Can cross pollinate between flowers with 2 genes each
  - Lv 2: Can cross pollinate between flowers with 3 genes each
  - Lv 3: Can cross pollinate between flowers with 4 genes each
  - Lv 4: Can cross pollinate between flowers with 5 genes each
- Hybrid flowers are no longer sterile
  - Lv 1: Hybrid flowers can breed intra-species for 1 generations before
    becoming sterile
  - Lv 2: Hybrid flowers can breed intra-species for 2 generations before
    becoming sterile
  - Lv 3: Hybrid flowers can breed intra-species for 3 generations before
    becoming sterile
  - Lv 4: Hybrid flowers can breed intra-species for 4 generations before
    becoming sterile
  - Lv 5: Hybrid flowers can breed intra-species for 5 generations before
    becoming sterile
- Increased Pollination chance
  - Lv 1: Slightly increased pollination chance (% increase TBD)
  - Lv 2: Moderately increased pollination chance (% increase TBD)
  - Lv 3: Greatly increased pollination chance (% increase TBD)
  - Lv 4: Significantly increased pollination chance (% increase TBD)
  - Lv 5: Immensely increased pollination chance (% increase TBD)

## Story

The player is a scientist who just took ownership of a flower shop, and are
growing flowers to sell. The player discovers a secret research facility in the
basement of the shop, and utilize it to grow increasingly rare and beautiful
flowers to sell and display.

Use trail-and-error and logical deduction to quickly advance your discoveries,
or simply discover new flowers randomly at your leisure!

## Data

### Species

#### Planned

| Name     | Class    | Trait 1 | Trait 2 | Trait 3 | Trait 4 |
| -------- | -------- | ------- | ------- | ------- | ------- |
| Popper   | Common   | Red     | White   |         |         |
| Genie    | Common   | Yellow  | White   |         |         |
| Lull     | Common   | Blue    | White   |         |         |
| Frazzil  | Uncommon | Red     | Yellow  | White   |         |
| Thrombus | Uncommon | Blue    | Red     | White   |         |
| Zydrill  | Uncommon | Yellow  | Green   | White   |         |
| Seacomb  | Rare     | Blue    | Green   | Yellow  | White   |

#### Stretch Goal

| Name         | Class  | Trait 1 | Trait 2 | Trait 3 | Trait 4 | Trait 5 |
| ------------ | ------ | ------- | ------- | ------- | ------- | ------- |
| Marzipoly    | Rare   | Red     | Blue    | Green   | White   |         |
| Chrysalynn   | Rare   | Red     | Magenta | Cyan    | White   |         |
| Brittlewing  | Exotic | Red     | Green   | Blue    | White   | eXotic  |
| Nebularaven  | Exotic | Red     | Blue    | Magenta | White   | eXotic  |
| Zorastapodia | Exotic | Cyan    | Magenta | Yellow  | White   | eXotic  |

### Variants

#### Popper

| Phenotype | Variant |
| --------- | ------- |
| 00        | Black   |
| 01        | White   |
| 10        | Black   |
| 11        | Red     |

#### Genie

| Phenotype | Variant |
| --------- | ------- |
| 00        | Black   |
| 01        | White   |
| 10        | Orange  |
| 11        | Yellow  |

#### Lull

| Phenotype | Variant |
| --------- | ------- |
| 00        | Grey    |
| 01        | White   |
| 10        | Purple  |
| 11        | Blue    |

#### Frazzil

| Phenotype | Variant |
| --------- | ------- |
| 000       | Grey    |
| 001       | White   |
| 010       | Purple  |
| 011       | Blue    |
| 100       | Grey    |
| 101       | White   |
| 110       | Purple  |
| 111       | Blue    |

#### Thrombus

| Phenotype | Variant      |
| --------- | ------------ |
| 000       | Black        |
| 001       | White        |
| 010       | Red          |
| 011       | Pink         |
| 100       | Indigo       |
| 101       | Blue         |
| 110       | Purple       |
| 111       | BrightPurple |

#### Zydrill

| Phenotype | Variant |
| --------- | ------- |
| 000       | Black   |
| 001       | White   |
| 010       | Black   |
| 011       | Green   |
| 100       | Black   |
| 101       | Yellow  |
| 110       | Black   |
| 111       | Yellow  |

#### Seacomb

| Phenotype | Variant   |
| --------- | --------- |
| 0000      | Black     |
| 0001      | White     |
| 0010      | Orange    |
| 0011      | Yellow    |
| 0100      | Green     |
| 0101      | Green     |
| 0110      | Green     |
| 0111      | Green     |
| 1000      | Black     |
| 1001      | Blue      |
| 1010      | Green     |
| 1011      | Green     |
| 1100      | Turquoise |
| 1101      | Silver    |
| 1110      | White     |
| 1111      | White     |
