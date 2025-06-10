using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BuffProperty
{
    public StatType statType;
    public float value;
}
public class Buff : MonoBehaviour
{
    List<BuffProperty> properties = new List<BuffProperty>();
    float duration;
    private float elapsedTime;

    public void Init(StatType _statType, float _duration)
    {
        statType = _statType;
        duration = _duration;
        elapsedTime = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (elapsedTime >= duration)
        {
            
            Destroy(this);
        }
        elapsedTime += Time.deltaTime;
    }
}
