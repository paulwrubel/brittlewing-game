using UnityEngine;

[System.Serializable]
public readonly struct Tool
{
    public readonly string displayName;
    public readonly ToolType type;
    public readonly string spriteFilePath;

    public Tool(ToolType toolType, string displayName)
    {
        this.type = toolType;
        this.displayName = displayName;

        this.spriteFilePath = string.Format("Sprites/Tools/{0}Sprite", toolType.ToString());
    }
}