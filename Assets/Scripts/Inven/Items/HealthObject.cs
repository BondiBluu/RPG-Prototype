using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health Object", menuName = "Inventory System/Items/Health")]
public class HealthObject : ItemObject
{
    public int hpRestoreAmount;
    public int mpRestoreAmount;

    public void Awake()
    {
        Type = ItemType.Health;
    }
}
