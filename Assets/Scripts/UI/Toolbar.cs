using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Toolbar : MonoBehaviour
{
    public GameObject toolslotPrefab;
    public Color unselectedSlotColor;
    public Color selectedSlotColor;

    private List<Tool> tools = new List<Tool>()
    {
        new Tool(ToolType.Spade, "Spade"),
        new Tool(ToolType.WateringCan, "Watering Can"),
        new Tool(ToolType.Scanner, "Scanner"),
    };

    private RectTransform rectTransform;
    private ToggleGroup toggleGroup;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        toggleGroup = GetComponent<ToggleGroup>();

        for (int i = 0; i < tools.Count; i++)
        {
            GameObject toolSlotGO = Instantiate(toolslotPrefab, this.transform);

            ToolSlot toolSlot = toolSlotGO.GetComponent<ToolSlot>();

            toolSlot.unselectedColor = this.unselectedSlotColor;
            toolSlot.selectedColor = this.selectedSlotColor;

            toolSlot.SetTool(tools[i]);
            toolSlot.SetToggleGroup(toggleGroup);

            if (i == 0)
            {
                toolSlot.SetSelected(true);
            }
            else
            {
                toolSlot.SetSelected(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}