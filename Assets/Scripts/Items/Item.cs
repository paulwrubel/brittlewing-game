using UnityEngine;

[System.Serializable]
public abstract class Item
{
    public string name;

    public abstract Sprite GetSprite();
}