

[System.Serializable]
public readonly struct Tool
{
    public readonly string displayName;
    public readonly ToolType type;

    public Tool(ToolType toolType, string displayName)
    {
        this.type = toolType;
        this.displayName = displayName;
    }
}