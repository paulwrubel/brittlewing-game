using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{

    public Item item;

    private Button button;
    private TextMeshProUGUI text;
    private Image spriteImage;
    private readonly Color filledColor = Color.white;
    private readonly Color emptyColor = new Color(
        Color.white.r,
        Color.white.g,
        Color.white.b,
        0);

    void Awake()
    {
        this.button = GetComponent<Button>();
        this.text = GetComponentInChildren<TextMeshProUGUI>();

        Image[] images = GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            if (image.gameObject.name.Contains("Sprite"))
            {
                this.spriteImage = image;
            }
            // if (image.gameObject.name.Contains("Slot"))
            // {
            //     slotImage = image;
            // }
        }

        Empty();
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() =>
        {
            Cursor cursor = GameManager.Instance.cursor;
            // if there's an item here
            if (this.item != null)
            {
                // if we can pick a thing up
                switch (cursor.GetSelectedToolType())
                {
                    case ToolType.Spade:
                        FlowerItem heldFlower = cursor.GetHeldItem<FlowerItem>();

                        // if there's nothing being currently held
                        if (heldFlower == null)
                        {
                            FlowerItem itemToHold = GetAndEmpty<FlowerItem>();

                            cursor.SetHeldItem(itemToHold);
                        }
                        break;
                    case ToolType.Scanner:
                        cursor.SetSelectedItem(GetItem<FlowerItem>());
                        break;
                }

            }
            else // if there's not an item in this slot
            {
                // if we can place a thing here
                if (cursor.GetSelectedToolType() == ToolType.Spade)
                {
                    FlowerItem heldFlower = cursor.GetHeldItem<FlowerItem>();

                    // if there's nothing being currently held
                    if (heldFlower != null)
                    {
                        Fill(heldFlower);
                        cursor.SetHeldItem(null);
                    }
                }
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fill(Item item)
    {
        this.item = item;

        text.text = item.name;
        spriteImage.sprite = item.GetSprite();
        spriteImage.color = filledColor;
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
        spriteImage.color = emptyColor;
    }
}
