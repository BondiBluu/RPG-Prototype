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


/*[Header("Enemy Names")]
public TMP_Text[] nameTextEnemies;
public TMP_Text nameTextEnemy1;
public TMP_Text nameTextEnemy2;
public TMP_Text nameTextEnemy3;
public TMP_Text nameTextEnemy4;

[Header("Player Levels")]
public TMP_Text[] levelTextPlayers;
public TMP_Text levelTextPlayer1;
public TMP_Text levelTextPlayer2;
public TMP_Text levelTextPlayer3;
public TMP_Text levelTextPlayer4;

[Header("Enemy Levels")]
public TMP_Text[] levelTextEnemies;
public TMP_Text levelTextEnemy1;
public TMP_Text levelTextEnemy2;
public TMP_Text levelTextEnemy3;
public TMP_Text levelTextEnemy4;

[Header("Player HP Sliders")]
public TMP_Text[] sliderHPPlayers;
public TMP_Text sliderHPPlayer1;
public TMP_Text sliderHPPlayer2;
public TMP_Text sliderHPPlayer3;
public TMP_Text sliderHPPlayer4;

[Header("Player HP Sliders")]
public TMP_Text[] sliderMPPlayers;
public TMP_Text sliderMPPlayer1;
public TMP_Text sliderMPPlayer2;
public TMP_Text sliderMPPlayer3;
public TMP_Text sliderMPPlayer4;

[Header("Enemy HP Sliders")]
public TMP_Text[] sliderEnemies;
public TMP_Text sliderEnemy1;
public TMP_Text sliderEnemy2;
public TMP_Text sliderEnemy3;
public TMP_Text sliderEnemy4;

     public void SetEnemies(EnemyUnit enemy)
    {
        nameTextEnemy1.text = enemy.enemyStats.enemyName;
        nameTextEnemy2.text = enemy.enemyStats.enemyName;
        nameTextEnemy3.text = enemy.enemyStats.enemyName;
        nameTextEnemy4.text = enemy.enemyStats.enemyName;
    }


//nameTextPlayer1.text = unit.characterStats.characterName;
        //nameTextPlayer2.text = unit.characterStats.characterName;
        //nameTextPlayer3.text = unit.characterStats.characterName;
        //nameTextPlayer4.text = unit.characterStats.characterName;

        //using battleSystem.playerPrefabs.Length to keep consistent with the other script
        /*for (int i = 0; i < battleSystem.playerPrefabs.Length; i++)
        {
            //nameText = nameTextPlayers[i];
            //Unit unit = units[i];
            nameTextPlayers[i].text= units[i].characterStats.characterName;
        }*/


//levelTextPlayer1.text = unit.characterStats.level.ToString();
//levelTextPlayer2.text = unit.characterStats.level.ToString();
//levelTextPlayer3.text = unit.characterStats.level.ToString();
//levelTextPlayer4.text = unit.characterStats.level.ToString();

//sliders have both a maxvalue and vaue full stop

