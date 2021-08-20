using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Cursor : MonoBehaviour
{
    public UnityEvent<ToolType> onSelectToolType;
    public UnityEvent<Item> onSelectItem;
    public UnityEvent<Item> onHoldItem;
    private ToolType selectedToolType;
    private Item selectedItem;
    private Item heldItem;
    private Image itemImage;

    private Canvas canvas;
    private readonly Color filledColor = Color.white;
    private readonly Color emptyColor = new Color(
        Color.white.r,
        Color.white.g,
        Color.white.b,
        0);

    void Awake()
    {
        itemImage = GetComponent<Image>();
        canvas = GetComponentInParent<Canvas>();

        onSelectToolType = new UnityEvent<ToolType>();
        onSelectItem = new UnityEvent<Item>();
        onHoldItem = new UnityEvent<Item>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetSprite(null);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition, canvas.worldCamera,
            out movePos);

        transform.position = canvas.transform.TransformPoint(movePos);
    }

    public T GetSelectedItem<T>() where T : Item
    {
        return (T)this.selectedItem;
    }

    public void SetSelectedItem(Item item)
    {
        this.selectedItem = item;
        onSelectItem.Invoke(item);
    }

    public T GetHeldItem<T>() where T : Item
    {
        return (T)this.heldItem;
    }

    public void SetHeldItem(Item item)
    {
        this.heldItem = item;
        SetSprite(item == null ? null : item.GetSprite());
        onHoldItem.Invoke(item);
    }

    public ToolType GetSelectedToolType()
    {
        return this.selectedToolType;
    }

    public void SetSelectedToolType(ToolType toolType)
    {
        this.selectedToolType = toolType;
        onSelectToolType.Invoke(toolType);
    }

    private void SetSprite(Sprite sprite)
    {
        this.itemImage.sprite = sprite;
        this.itemImage.color = sprite == null ? emptyColor : filledColor;
    }
}
