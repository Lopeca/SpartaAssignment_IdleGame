using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[System.Serializable]
public class ConsumableItem : Item
{
    public ConsumableItemScriptable ConsumableItemData => ItemData as ConsumableItemScriptable;

    public void Use()
    {
        switch (ConsumableItemData.ConsumeType)
        {
            case ConsumeType.Recover:
                BattleManager.Instance.player.Recover(ConsumableItemData.Value);
                break;
            case ConsumeType.Buff:
                
                break;
        }
    }
}
