using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : ItemObject
{
    public int atkBoost;
    public int defBoost;

    public void Awake()
    {
        type = ItemType.Weapon;
    }
}
