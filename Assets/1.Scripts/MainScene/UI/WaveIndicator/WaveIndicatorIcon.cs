using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveIndicatorIcon : MonoBehaviour
{
    [SerializeField] GameObject progressLight;

    public void TurnOff()
    {
        progressLight.SetActive(false);
    }

    public void TurnOn()
    {
        progressLight.SetActive(true);
    }
}
