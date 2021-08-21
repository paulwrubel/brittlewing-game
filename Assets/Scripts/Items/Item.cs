using UnityEngine;

[System.Serializable]
public abstract class Item
{
    public string name;
    public int value;

    public abstract Sprite GetSprite();
}