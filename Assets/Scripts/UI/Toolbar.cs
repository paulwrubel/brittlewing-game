using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Toolbar : MonoBehaviour
{
    public GameObject toolslotPrefab;
    public int padding = 10;
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

        Vector2 toolslotSize = new Vector2(
            rectTransform.sizeDelta.y - padding * 2,
            rectTransform.sizeDelta.y - padding * 2);
        rectTransform.sizeDelta = new Vector2((padding * (tools.Count + 1)) + (toolslotSize.x * tools.Count), rectTransform.sizeDelta.y);

        for (int i = 0; i < tools.Count; i++)
        {
            GameObject toolslotGO = Instantiate(toolslotPrefab, this.transform);
            RectTransform toolslotTransform = (RectTransform)toolslotGO.transform;
            toolslotTransform.sizeDelta = toolslotSize;

            Toolslot toolslot = toolslotGO.GetComponent<Toolslot>();
            Toggle toolslotToggle = toolslotGO.GetComponent<Toggle>();
            TextMeshProUGUI toolslotTMP = toolslotGO.GetComponentInChildren<TextMeshProUGUI>();

            if (i == 0)
            {
                toolslotToggle.isOn = true;
            }

            toolslotTransform.anchoredPosition = new Vector2(padding, -padding) + (new Vector2(toolslotSize.x + padding, 0) * i);
            toolslot.tool = tools[i];

            toolslotTMP.text = toolslot.tool.displayName;

            toolslotToggle.group = toggleGroup;
            toolslotToggle.onValueChanged.AddListener(delegate (bool isNowToggled)
            {
                if (isNowToggled)
                {
                    GameManager.Instance.selectedTool = toolslot.tool.type;
                    print(GameManager.Instance.selectedTool);
                }
            });
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}