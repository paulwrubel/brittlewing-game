using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ToolSlot : MonoBehaviour
{
    public Tool tool;
    public Color unselectedColor;
    public Color selectedColor;
    // public Toggle.ToggleEvent toggleOnValueChanged;

    private Toggle toggle;
    private TextMeshProUGUI text;
    private Image spriteImage;
    private Image slotImage;
    private bool addedOnValueChangedListener = false;

    void Awake()
    {
        toggle = GetComponent<Toggle>();
        text = GetComponentInChildren<TextMeshProUGUI>();

        Image[] images = GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            if (image.gameObject.name.Contains("Sprite"))
            {
                spriteImage = image;
            }
            if (image.gameObject.name.Contains("Slot"))
            {
                slotImage = image;
            }
        }

        slotImage.color = unselectedColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.cursor.onHoldItem.AddListener((Item item) =>
        {
            if (item != null)
            {
                toggle.enabled = false;
            }
            else
            {
                toggle.enabled = true;
            }
        });

        TrySetupInternalListener();

        print("Setting up slot for tool: " + tool.type);

        text.text = tool.displayName;
        spriteImage.sprite = Resources.Load<Sprite>(tool.spriteFilePath);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTool(Tool tool)
    {
        this.tool = tool;
    }

    public void SetToggleGroup(ToggleGroup toggleGroup)
    {
        this.toggle.group = toggleGroup;
    }

    public void SetSelected(bool isSelected)
    {
        TrySetupInternalListener();
        toggle.isOn = isSelected;
        // slotImage.color = isSelected ? selectedColor : unselectedColor;
    }

    public void AddOnValueChangedListener(UnityAction<bool> call)
    {
        toggle.onValueChanged.AddListener(call);
    }

    public bool TrySetupInternalListener()
    {
        if (!addedOnValueChangedListener)
        {
            AddOnValueChangedListener(InternalOnValueChangedListener());
            addedOnValueChangedListener = true;
            return true;
        }
        return false;
    }

    private UnityAction<bool> InternalOnValueChangedListener()
    {
        return isNowToggled =>
        {
            if (isNowToggled)
            {
                Cursor cursor = GameManager.Instance.cursor;
                cursor.SetSelectedToolType(this.tool.type);
                print(cursor.GetSelectedToolType());
                if (this.tool.type != ToolType.Scanner)
                {
                    cursor.SetSelectedItem(null);
                }
            }
            slotImage.color = isNowToggled ? selectedColor : unselectedColor;
        };
    }
}
