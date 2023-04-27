using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equip Object", menuName = "Inventory System/Items/Equip")]

public class EquipObject : ItemObject
{
    public float hpBoost;
    public float mpBoost;
    public float atkBoost;
    public float defBoost;
    public float magBoost;
    public float resBoost;
    public float speedBoost;

    public void Awake()
    {
        type = ItemType.Equip;
    }
}
