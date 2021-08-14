using UnityEngine;

public class Flower : MonoBehaviour
{
    public SpeciesType speciesType;
    public Genome genome;
    public VariantType variantType;

    private SpriteRenderer spriteRenderer;

    public void Initialize(SpeciesType speciesType, Genome genome)
    {
        this.speciesType = speciesType;
        this.genome = genome;
        this.variantType = SpeciesDatabase.GetVariantTypeBySpeciesTypeAndPhenotype(this.speciesType, this.genome.GetPhenotypeGeneric());
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        string spriteFilePath = string.Format("Sprites/Flowers/{0}Sprite", speciesType.ToString() + variantType.ToString());
        Sprite sprite = Resources.Load<Sprite>(spriteFilePath);
        spriteRenderer.sprite = sprite;
    }

    void Update()
    {

    }
}