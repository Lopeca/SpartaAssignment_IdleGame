using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class ConsumableItem : Item
{
    public ConsumableItemScriptable ConsumableItemData => ItemData as ConsumableItemScriptable;
    public int Cost => (int)(ConsumableItemData.Cost * 0.75f);

    public void Init(ConsumableItemScriptable _consumableItemData)
    {
        itemData = _consumableItemData;
    }
    public void Use(Player player)
    {
        switch (ConsumableItemData.ConsumeType)
        {
            case ConsumeType.Recover:
                BattleManager.Instance.player.Recover(ConsumableItemData.Value);
                break;
            case ConsumeType.Buff:
                Buff buff = player.AddComponent<Buff>();
                buff.Init(ConsumableItemData, () => player.statHandler.RemoveBuff(buff));
                player.statHandler.AppendBuff(buff);
                
                break;
        }
    }

    public override string GetItemInfoString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (BuffProperty property in ConsumableItemData.BuffOptions)
        {
            sb.AppendLine(property.ToString());
        }
        sb.AppendLine();
        sb.AppendLine($"Duration: {ConsumableItemData.Duration} s");

        return sb.ToString();
    }
}
