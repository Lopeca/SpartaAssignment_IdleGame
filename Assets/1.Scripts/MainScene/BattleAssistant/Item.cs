using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[System.Serializable]
public class Item
{
    public ItemData itemData;
    [SerializeField] List<Stat> stats;
    
    [SerializeField] int upgradeCount;
    
    public int UpgradeCount => upgradeCount;
    public int Cost => (int)(itemData.Cost * (1 + (float)upgradeCount / 2));

    public void Init(ItemData itemData)
    {
        this.itemData = itemData;
        this.stats = new List<Stat>();
        this.upgradeCount = 0;

        foreach (Stat stat in itemData.Stats)
        {
            Stat tempStat = new Stat();
            tempStat.statType = stat.statType;
            tempStat.value = stat.value;
            tempStat.upgradeValue = stat.upgradeValue;

            stats.Add(tempStat);
        }
    }
    public void Upgrade()
    {
        foreach (Stat stat in stats)
        {
            stat.value += stat.upgradeValue;
        }
        upgradeCount++;
    }

    public string GetItemInfoString()
    {
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
