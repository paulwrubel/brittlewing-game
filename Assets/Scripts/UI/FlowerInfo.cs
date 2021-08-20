using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlowerInfo : MonoBehaviour
{
    private FlowerItem flowerItem;
    private Image flowerSideImage;
    private Image flowerTopImage;
    private TextMeshProUGUI speciesValueText;
    private TextMeshProUGUI variantValueText;
    private TextMeshProUGUI genomeValueText;

    private readonly Color filledColor = Color.white;
    private readonly Color emptyColor = new Color(
        Color.white.r,
        Color.white.g,
        Color.white.b,
        0);

    void Awake()
    {
        List<Transform> children = GetComponentsInChildren<Transform>().ToList();

        flowerSideImage = children
            .Find(t => t.gameObject.name.Contains("Flower Images")).GetComponentsInChildren<Image>().ToList()
            .Find(t => t.gameObject.name.Contains("Side"));
        flowerTopImage = children
            .Find(t => t.gameObject.name.Contains("Flower Images")).GetComponentsInChildren<Image>().ToList()
            .Find(t => t.gameObject.name.Contains("Top"));

        speciesValueText = children
            .Find(t => t.gameObject.name.Contains("Species")).GetComponentsInChildren<TextMeshProUGUI>().ToList()
            .Find(t => t.gameObject.name.Contains("Value"));
        variantValueText = children
            .Find(t => t.gameObject.name.Contains("Variant")).GetComponentsInChildren<TextMeshProUGUI>().ToList()
            .Find(t => t.gameObject.name.Contains("Value"));
        genomeValueText = children
            .Find(t => t.gameObject.name.Contains("Genome")).GetComponentsInChildren<TextMeshProUGUI>().ToList()
            .Find(t => t.gameObject.name.Contains("Value"));
    }

    // Start is called before the first frame update
    void Start()
    {

        flowerSideImage.sprite = null;
        flowerSideImage.color = emptyColor;
        flowerTopImage.sprite = null;
        flowerTopImage.color = emptyColor;

        speciesValueText.text = "";
        variantValueText.text = "";
        genomeValueText.text = "";

        GameManager.Instance.cursor.onSelectItem.AddListener((Item item) =>
        {
            if (item == null)
            {
                flowerSideImage.sprite = null;
                flowerSideImage.color = emptyColor;
                flowerTopImage.sprite = null;
                flowerTopImage.color = emptyColor;

                speciesValueText.text = "";
                variantValueText.text = "";
                genomeValueText.text = "";
            }
            else
            {
                FlowerItem flowerItem = item as FlowerItem;

                flowerSideImage.sprite = flowerItem.GetSideSprite();
                flowerSideImage.color = filledColor;
                flowerTopImage.sprite = flowerItem.GetTopSprite();
                flowerTopImage.color = filledColor;

                speciesValueText.text = flowerItem.speciesType.ToString();
                variantValueText.text = flowerItem.variantType.ToString();
                genomeValueText.text = flowerItem.genome.GetGenotype();
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
