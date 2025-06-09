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

    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private GameObject itemSlotContainer;

    public const int MaxSlotCount = 15;
    
    private void Start()
    {
        foreach (Transform child in itemSlotContainer.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < MaxSlotCount; i++)
        {
            ItemSlot slot = Instantiate(itemSlotPrefab, itemSlotContainer.transform).GetComponent<ItemSlot>();
            slot.SetId(i);
            BattleManager.Instance.player.playerInventory.AppendSlot(slot, i);
        }
    }

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
