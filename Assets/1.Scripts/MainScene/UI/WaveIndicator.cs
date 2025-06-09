using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveIndicator : MonoBehaviour
{
    
    [SerializeField] List<WaveIndicatorIcon> waveIndicatorIcons;

    public void Init()
    {
        foreach (WaveIndicatorIcon icon in waveIndicatorIcons)
        {
            icon.TurnOff();
        }
    }

    public void LitIndicator(int index)
    {
        waveIndicatorIcons[index].TurnOn();
    }
}
