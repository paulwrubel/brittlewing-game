using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Inventory inventory;
    public int index;

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
        this.inventory.onItemChange.AddListener((int updatedIndex) =>
        {
            if (this.index == updatedIndex)
            {
                Item item = this.inventory.GetAt<Item>(updatedIndex);
                if (item == null)
                {
                    Empty();
                }
                else
                {
                    Fill(item);
                }
            }
        });

        button.onClick.AddListener(() =>
        {
            Cursor cursor = GameManager.Instance.cursor;
            // if there's an item here
            if (this.inventory.GetAt<Item>(index) != null)
            {
                // if we can pick a thing up
                switch (cursor.GetSelectedToolType())
                {
                    case ToolType.Spade:
                        FlowerItem heldFlower = cursor.GetHeldItem<FlowerItem>();

                        // if there's nothing being currently held
                        if (heldFlower == null)
                        {
                            FlowerItem itemToHold = this.inventory.GetAndEmptyAt<FlowerItem>(this.index);

                            cursor.SetHeldItem(itemToHold);
                        }
                        break;
                    case ToolType.Scanner:
                        cursor.SetSelectedItem(this.inventory.GetAt<FlowerItem>(this.index));
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
                        this.inventory.SetAt(this.index, heldFlower);
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
        text.text = item.name;
        spriteImage.sprite = item.GetSprite();
        spriteImage.color = filledColor;
    }

    private void Empty()
    {
        text.text = "";
        spriteImage.sprite = null;
        spriteImage.color = emptyColor;
    }
}
