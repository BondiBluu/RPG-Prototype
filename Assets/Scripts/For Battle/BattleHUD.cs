using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    [Header("Player Names and Levels")]
    public TMP_Text[] nameTextPlayers;
    [SerializeField] TMP_Text[] levelTextPlayers;

    [Header("Player HP")]
    public TMP_Text[] currentHPPlayers;
    public TMP_Text[] maxHPPlayers;
    public Slider[] sliderHPPlayers;

    [Header("Player MP")]
    public TMP_Text[] currentMPPlayers;
    public TMP_Text[] maxMPPlayers;
    public Slider[] sliderMPPlayers;

    [Header("Enemy Names")]
    public TMP_Text[] nameTextEnemies;

    [Header("Enemy HP Sliders")]
    public Slider[] sliderEnemies;

    //Setting the HUD
    public void SetPlayerHUD(Unit[] units)
    {
        for (int i = 0; i < units.Length; i++)
        {
            //displaying name, lvl, max and current hp and mp of players
            nameTextPlayers[i].text = units[i].characterStats.characterName;
            levelTextPlayers[i].text = units[i].characterStats.level.ToString();
            maxHPPlayers[i].text = units[i].characterStats.maxHP.ToString();
            currentHPPlayers[i].text = units[i].characterStats.currentHP.ToString();
            maxMPPlayers[i].text = units[i].characterStats.maxMP.ToString();
            currentMPPlayers[i].text = units[i].characterStats.currentMP.ToString();

            //sliders have built in max values and vaues in general
            sliderHPPlayers[i].maxValue = units[i].characterStats.maxHP; 
            sliderMPPlayers[i].maxValue = units[i].characterStats.maxMP; 
            sliderHPPlayers[i].value = units[i].characterStats.currentHP;
            sliderMPPlayers[i].value = units[i].characterStats.currentMP;
        }
    }

    public void SetEnemyHUD(EnemyUnit[] units)
    {
        for (int i = 0; i < units.Length; i++)
        {
            //displaying name and current hp of enemies
            nameTextEnemies[i].text = units[i].enemyStats.enemyName;
            sliderEnemies[i].maxValue = units[i].enemyStats.maxHP;
            sliderEnemies[i].value = units[i].enemyStats.currentHP;
        }
    }

    //updating player hp
    public void SetHP(int hP)
    {
        sliderHPPlayers[0].value = hP;
    }

}
