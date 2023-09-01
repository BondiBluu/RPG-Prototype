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
    [SerializeField] GameObject prefab;
    [SerializeField] ItemType type;
    [SerializeField] string itemName;
    [SerializeField] string namePlural;
    [SerializeField] string invenItemName;
    [TextArea(15,20)]
    [SerializeField] string desc;
    [TextArea(15, 20)]
    [SerializeField] string trueDesc;
    [SerializeField] float price;
    [SerializeField] bool ableToSell;

    public GameObject Prefab
    {
        get { return prefab; }
        set { prefab = value; }
    }

    public ItemType Type
    {
        get { return type; }
        set { type = value; }
    }

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public string NamePlural
    {
        get { return namePlural; }
        set { namePlural = value; }
    }

    public string InvenItemName
    {
        get { return invenItemName; }
        set { invenItemName = value; }
    }

    public string Desc
    {
        get { return desc; }
        set { desc = value; }
    }

    public string TrueDesc
    {
        get { return trueDesc; }
        set { trueDesc = value; }
    }

    public float Price
    {
        get { return price; }
        set { price = value; }
    }

    public bool AbleToSell
    {
        get { return ableToSell; }
        set { ableToSell = value; }
    }
}
