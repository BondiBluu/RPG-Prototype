using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleStats : MonoBehaviour
{
    [SerializeField] CharacterStatistics characterStatistics;

    private void Start()
    {
        ShowStatsForBattle(characterStatistics);
    }

    [SerializeField] GameObject charaImage;
    [SerializeField] TMP_Text abilityText;
    [SerializeField] TMP_Text descAbilityText;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text hPText;
    [SerializeField] TMP_Text mPText;
    [SerializeField] TMP_Text atkText;
    [SerializeField] TMP_Text defText;
    [SerializeField] TMP_Text magText;
    [SerializeField] TMP_Text resText;
    [SerializeField] TMP_Text effText;
    [SerializeField] TMP_Text skiText;
    [SerializeField] TMP_Text speText;
    [SerializeField] TMP_Text pointsToLevelText;
    [SerializeField] Button nextButton;

    //showing the character statistics
    public void ShowStatsForBattle(CharacterStatistics characterStatistics)
    {
        charaImage.GetComponent<Image>().sprite = characterStatistics.Image;
        abilityText.text = characterStatistics.Ability;
        descAbilityText.text = characterStatistics.AbilityDesc;
        nameText.text = characterStatistics.CharacterName;
        levelText.text = characterStatistics.Level.ToString();
        hPText.text = $"{characterStatistics.CurrentHP}/{characterStatistics.MaxHP}";
        mPText.text = $"{characterStatistics.CurrentMP}/{characterStatistics.MaxMP}";
        SetStatTexts(atkText, characterStatistics.CurrentAttack, characterStatistics.BaseAttack);
        SetStatTexts(defText, characterStatistics.CurrentDefense, characterStatistics.BaseDefense);
        SetStatTexts(magText, characterStatistics.CurrentMagic, characterStatistics.BaseMagic);
        SetStatTexts(resText, characterStatistics.CurrentResistance, characterStatistics.BaseResistance);
        SetStatTexts(effText, characterStatistics.CurrentEfficiency, characterStatistics.BaseEfficiency);
        SetStatTexts(skiText, characterStatistics.CurrentSkill, characterStatistics.BaseSkill);
        SetStatTexts(speText, characterStatistics.CurrentSpeed, characterStatistics.BaseSpeed);
    }

    public void SetStatTexts(TMP_Text textElement, int currentValue, int baseValue)
    {
        //finding what was lowered or raised in the base
        int statsDifference = currentValue - baseValue;

        //blue + or red - plus the stats difference will appear based on if the stats difference is a positive or negative value
        string sign = (statsDifference >= 0 ) ? $"<color=#6EFFFF>+{statsDifference}</color>" : $"<color=#FF1100>{statsDifference}</color>";

        textElement.text = $"{baseValue}({sign})";
    }


}
