using UnityEngine;

public class Flower : MonoBehaviour
{
    public Species species;
    public Genome genome;
    public VariantType variantType;

    private SpriteRenderer spriteRenderer;

    public void Initialize(Species species, Genome genome)
    {
        this.species = species;
        this.genome = genome;
        this.variantType = PhenomeDatabase.GetVariantTypeBySpeciesAndPhenotype(this.species, this.genome.GetPhenotypeGeneric());
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        string spriteFilePath = string.Format("Sprites/Flowers/{0}Sprite", species.ToString() + variantType.ToString());
        Sprite sprite = Resources.Load<Sprite>(spriteFilePath);
        spriteRenderer.sprite = sprite;
    }

    void Update()
    {

    }
}