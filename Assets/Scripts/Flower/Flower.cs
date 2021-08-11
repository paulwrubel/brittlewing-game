using UnityEngine;

public class Flower
{
    private Species species;
    private Genome genome;

    public Flower(Species species, string genomeString)
    {
        this.species = species;
        this.genome = new Genome(genomeString);
    }
}