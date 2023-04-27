using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Health,
    Equip,
    DamagingTool,
    Default,
    StatRaise
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string desc;
    [TextArea(15, 20)]
    public string trueDesc;
    public float price;
    public bool ableToSell;
}
