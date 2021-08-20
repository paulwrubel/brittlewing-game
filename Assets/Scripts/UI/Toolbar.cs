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
    private List<ToolSlot> toolSlots = new List<ToolSlot>();

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
            toolSlots.Add(toolSlot);

            toolSlot.unselectedColor = this.unselectedSlotColor;
            toolSlot.selectedColor = this.selectedSlotColor;

            toolSlot.SetTool(tools[i]);
            toolSlot.SetToggleGroup(toggleGroup);
            toolSlot.TrySetupInternalListener();
        }

        for (int i = tools.Count - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                toolSlots[i].SetSelected(true);
            }
            else
            {
                // this is to trip the internal state of the trigger to 
                // recognize that it has "changed" (even though we do want
                // it to be disabled at the start)
                //
                // this will trigger the onValueChanged listeners, 
                // which setup sprites and whatnot
                toolSlots[i].SetSelected(true);
                toolSlots[i].SetSelected(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}