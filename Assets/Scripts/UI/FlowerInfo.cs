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
    private TextMeshProUGUI speciesText;
    private TextMeshProUGUI variantText;
    private TextMeshProUGUI genomeText;
    private TextMeshProUGUI valueText;

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

        speciesText = children
            .Find(t => t.gameObject.name.Contains("Species")).GetComponentsInChildren<TextMeshProUGUI>().ToList()
            .Find(t => t.gameObject.name.Contains("Value"));
        variantText = children
            .Find(t => t.gameObject.name.Contains("Variant")).GetComponentsInChildren<TextMeshProUGUI>().ToList()
            .Find(t => t.gameObject.name.Contains("Value"));
        genomeText = children
            .Find(t => t.gameObject.name.Contains("Genome")).GetComponentsInChildren<TextMeshProUGUI>().ToList()
            .Find(t => t.gameObject.name.Contains("Value"));
        valueText = children
            .Find(t => t.gameObject.name.Contains("FValue")).GetComponentsInChildren<TextMeshProUGUI>().ToList()
            .Find(t => t.gameObject.name.Contains("Value"));
    }

    // Start is called before the first frame update
    void Start()
    {

        flowerSideImage.sprite = null;
        flowerSideImage.color = emptyColor;
        flowerTopImage.sprite = null;
        flowerTopImage.color = emptyColor;

        speciesText.text = "";
        variantText.text = "";
        genomeText.text = "";
        valueText.text = "";

        GameManager.Instance.cursor.onSelectItem.AddListener((Item item) =>
        {
            if (item == null)
            {
                flowerSideImage.sprite = null;
                flowerSideImage.color = emptyColor;
                flowerTopImage.sprite = null;
                flowerTopImage.color = emptyColor;

                speciesText.text = "";
                variantText.text = "";
                genomeText.text = "";
                valueText.text = "";
            }
            else
            {
                FlowerItem flowerItem = item as FlowerItem;

                flowerSideImage.sprite = flowerItem.GetSideSprite();
                flowerSideImage.color = filledColor;
                flowerTopImage.sprite = flowerItem.GetTopSprite();
                flowerTopImage.color = filledColor;

                speciesText.text = flowerItem.speciesType.ToString();
                variantText.text = flowerItem.variantType.ToString();
                genomeText.text = flowerItem.genome.GetGenotype();
                valueText.text = string.Format("${0}", flowerItem.value.ToString());
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
