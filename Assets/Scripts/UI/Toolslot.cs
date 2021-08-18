using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Toolslot : MonoBehaviour
{
    public Tool tool;
    public Toggle.ToggleEvent toggleOnValueChanged;

    private Toggle toggle;
    private TextMeshProUGUI text;

    public void Initialize(Tool tool, ToggleGroup toggleGroup)
    {
        this.tool = tool;

        toggle = GetComponent<Toggle>();
        toggle.group = toggleGroup;
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();

        toggleOnValueChanged = toggle.onValueChanged;

        text.text = tool.displayName;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSelected(bool isSelected)
    {
        toggle.isOn = isSelected;
    }

    public void AddOnValueChangedListener(UnityAction<bool> call)
    {
        toggle.onValueChanged.AddListener(call);
    }
}
