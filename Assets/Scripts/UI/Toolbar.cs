using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Toolbar : MonoBehaviour
{
    public GameObject toolslotPrefab;
    public List<Tool> tools = new List<Tool>()
    {
        new Tool(ToolType.Picker, "Picker"),
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
            GameObject toolslotGO = Instantiate(toolslotPrefab, this.transform);

            Toolslot toolslot = toolslotGO.GetComponent<Toolslot>();

            toolslot.Initialize(tools[i], toggleGroup);
            toolslot.AddOnValueChangedListener(isNowToggled =>
            {
                if (isNowToggled)
                {
                    GameManager.Instance.selectedTool = toolslot.tool.type;
                    print(GameManager.Instance.selectedTool);
                }
            });

            if (i == 0)
            {
                toolslot.SetSelected(true);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}