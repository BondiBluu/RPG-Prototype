using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool Object", menuName = "Inventory System/Items/Tool")]
public class DamagingToolObject : ItemObject
{
    //consumable weapon. can be used instead of an attack to damage enemies. depends on efficiency

    public float atkPower;
    public float magPower;


    public void Awake()
    {
        type = ItemType.DamagingTool;
    }
}
