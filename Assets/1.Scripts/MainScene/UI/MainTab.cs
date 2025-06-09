using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainTab : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI atkText;
    [SerializeField] private TextMeshProUGUI defText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private Slider expBar;
    
    public void UpdateGoldText(int gold)
    {
        goldText.text = $"{gold} G";
    }

    public void UpdateLevelText(int level)
    {
        levelText.text = $"Lv {level}";
    }
    
    public void UpdateExp(int currentExp, int totalExp)
    {
        expText.text = $"{currentExp}/{totalExp}";
        expBar.value = (float)currentExp / totalExp;
    }

    public void UpdateStatText(float currentAtk, float currentDef)
    {
        atkText.text = $"{currentAtk}";
        defText.text = $"{currentDef}";
    }
    
    public void OnClickCrystal()
    {
        BattleManager.Instance.player.GainGold(BattleManager.Instance.player.statHandler.CurrentLevel);
    }
}
