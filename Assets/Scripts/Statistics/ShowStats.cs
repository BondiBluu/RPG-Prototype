using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStats : MonoBehaviour
{


    /*Name, charaImage, Level, currentHP, maxHP, currentMP, maxMP Attack, Defense, Magic, Resistance, Efficiency, Skill, Speed*/
    [SerializeField] public string[] charaNames = new string[] { "Rosa", "Kachina", "Lola", "Margot" };
    [SerializeField] public int[] chara1Stats = new int[] {
        15, //level
        10, //current hp 
        20, //max hp
        30, //current mp
        50, //max mp
        2, //atk
        3, //def
        4, //mag 
        5, //res
        6, //eff
        7, //skill
        8 //speed
    };
    [SerializeField] public int[] chara2Stats = new int[]{2, 8, 10, 4, 32, 7, 6, 5, 4, 3, 2, 1};
    [SerializeField] public int[] chara3Stats = new int[] {2, 13, 30, 25, 26, 5, 8, 5, 0, 1, 3, 7};
    [SerializeField] public int[] chara4Stats = new int[] {1, 5, 10, 3, 14, 7, 0, 1, 6, 8, 7, 3};
    [SerializeField] public Sprite[] charaImage = new Sprite[4];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}


    [System.Serializable]
    public class CharacterStats
    {
        public string charaName;
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
        public Image image;
    }

    /*[SerializeField]
    public CharacterStats[] characters = new CharacterStats[]
{
    new CharacterStats
    {
        charaName = "Rosa",
        image = null, // Assign the image separately in the Unity Editor
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
        speed = 8
    },
    // Add more character stats objects here if needed
};*/
