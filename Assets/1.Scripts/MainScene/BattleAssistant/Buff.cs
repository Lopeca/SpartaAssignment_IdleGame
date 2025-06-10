using System;
using UnityEngine;

public class Buff : MonoBehaviour
{
    private ConsumableItemScriptable data;
    public ConsumableItemScriptable Data => data;
    float duration;
    private float elapsedTime;
    private Action RemoveBuff;

    public void Init(ConsumableItemScriptable data, Action RemoveBuff)
    {
        this.data = data;
        duration = data.Duration;
        elapsedTime = 0;
        this.RemoveBuff += RemoveBuff;
    }

    void Update()
    {
        if (elapsedTime >= duration)
        {
            RemoveBuff?.Invoke();
            Destroy(this);
        }

        elapsedTime += Time.deltaTime;
    }

    public float GetProgressPercent()
    {
        return elapsedTime / duration;
    }
}