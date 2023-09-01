using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New StatRaising Object", menuName = "Inventory System/Items/Stat Raising")]
public class StatRaisingObject : ItemObject
{
    public int hpBoostPerm;
    public int mpBoostPerm;
    public int atkBoostPerm;
    public int magBoostPerm;
    public int defBoostPerm;
    public int resBoostPerm;
    public int skillBoostPerm;
    public int effBoostPerm;
    public int speedBoostPerm;


    public void Awake()
    {
        Type = ItemType.StatRaise;
    }
}
