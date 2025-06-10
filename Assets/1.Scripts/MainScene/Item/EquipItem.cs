using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[System.Serializable]
public class EquipItem : Item
{
    public EquipItemScriptable EquipItemData => ItemData as EquipItemScriptable;
    [SerializeField] List<Stat> stats;
    public List<Stat> Stats => stats;
    
    [SerializeField] int upgradeCount;
    
    public int UpgradeCount => upgradeCount;
    public int Cost => (int)(EquipItemData.Cost * (1 + (float)upgradeCount / 2));
    public bool equipped;

    public void Init(EquipItemScriptable equipItemScriptable)
    {
        // 역할 : 데이터로부터 변동될 속성(강화로 스탯 증가 등등) 카피
        // 최적화에는 메모리 파편화 관점에서 애초에 스탯 클래스가 struct인 쪽이 좋겠다고 생각하지만 
        // 나중에 강화 시 값복사 후 다뤄야하는 어색함도 있어서 일단 클래스로 진행했습니다 
        
        itemData = equipItemScriptable;
        stats = new List<Stat>();
        upgradeCount = 0;

        foreach (Stat stat in equipItemScriptable.Stats)
        {
            Stat tempStat = new Stat();
            tempStat.statType = stat.statType;
            tempStat.value = stat.value;
            tempStat.upgradeValue = stat.upgradeValue;

            stats.Add(tempStat);
        }

        equipped = false;
    }
    public void Upgrade()
    {
        foreach (Stat stat in stats)
        {
            stat.value += stat.upgradeValue;
        }
        upgradeCount++;
    }

    public override string GetItemInfoString()
    {
        // 아이템 슬롯 누르면 뜨는 창
        StringBuilder sb = new StringBuilder();

        foreach (Stat stat in stats)
        {
            sb.AppendLine(stat.StatToString());
        }

        sb.AppendLine();
        sb.Append("Upgrade Count: ");
        sb.Append(upgradeCount);

        return sb.ToString();
    }
}
