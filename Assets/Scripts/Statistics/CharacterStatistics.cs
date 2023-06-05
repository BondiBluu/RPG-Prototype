using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatistics : MonoBehaviour
{
[System.Serializable]

//creating a custom class of statistics
public class CharacterStats
{
    public string name;
    public int level;
    public int currentHP;
    public int maxHP;
    public int currentMP;
    public int maxMP;
    public int attack;
    public int defense;
    public int magic;
    public int resistance;
    public int efficiency;
    public int skill;
    public int speed;
    public Sprite charaImage;
}

    //making an array of CharacterStats objects
    public CharacterStats[] stats = new CharacterStats[]
    {
        new CharacterStats
        {
            name = "Rosa",
            level = 15,
            currentHP = 10,
            maxHP = 20,
            currentMP = 30,
            maxMP = 50,
            attack = 2,
            defense = 3,
            magic = 4,
            resistance = 5,
            efficiency = 6,
            skill = 7,
            speed = 8,
            charaImage = null
        },
        new CharacterStats
    {
        name = "Kachina",
        level = 2,
        currentHP = 8,
        maxHP = 10,
        currentMP = 4,
        maxMP = 32,
        attack = 7,
        defense = 6,
        magic = 5,
        resistance = 4,
        efficiency = 3,
        skill = 2,
        speed = 1,
        charaImage = null // Assign the image separately in the Unity Editor
    },
    new CharacterStats
    {
        name = "Lola",
        level = 2,
        currentHP = 13,
        maxHP = 30,
        currentMP = 25,
        maxMP = 26,
        attack = 5,
        defense = 8,
        magic = 5,
        resistance = 0,
        efficiency = 1,
        skill = 3,
        speed = 7,
        charaImage = null // Assign the image separately in the Unity Editor
    },
    new CharacterStats
    {
        name = "Margot",
        level = 1,
        currentHP = 5,
        maxHP = 10,
        currentMP = 3,
        maxMP = 14,
        attack = 7,
        defense = 0,
        magic = 1,
        resistance = 6,
        efficiency = 8,
        skill = 7,
        speed = 3,
        charaImage = null // Assign the image separately in the Unity Editor
    }
    };
}
