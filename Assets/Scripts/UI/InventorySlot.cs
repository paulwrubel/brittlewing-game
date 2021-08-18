using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{

    public Item item;

    private TextMeshProUGUI text;
    private Image spriteImage;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        Image[] images = GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            if (image.gameObject.name.Contains("Sprite"))
            {
                spriteImage = image;
            }
            // if (image.gameObject.name.Contains("Slot"))
            // {
            //     slotImage = image;
            // }
        }

        text.text = "";
        spriteImage.sprite = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fill(FlowerItem f)
    {
        this.item = f;

        text.text = f.speciesType.ToString();
        spriteImage.sprite = null;
    }

    public Item GetItem()
    {
        return this.item;
    }

    public T GetItem<T>() where T : Item
    {
        return (T)this.item;
    }

    public T GetAndEmpty<T>() where T : Item
    {
        Item f = this.item;
        Empty();
        return (T)f;
    }

    private void Empty()
    {
        this.item = null;

        text.text = "";
        spriteImage.sprite = null;
    }
}
