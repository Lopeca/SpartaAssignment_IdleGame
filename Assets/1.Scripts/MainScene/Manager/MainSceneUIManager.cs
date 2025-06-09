using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUIManager : MonoBehaviour
{
    public static MainSceneUIManager Instance { get; private set; }
    public Image battleFadeSquare;
    const float fadeDuration = 0.5f;

    public bool fadeComplete;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        battleFadeSquare.color = new Color(0, 0, 0, 0);
        fadeComplete = false;
    }

    public void BattleFadeIn()
    {
        fadeComplete = false;
        battleFadeSquare.DOFade(0f, fadeDuration).OnComplete(() => fadeComplete = true);
    }
    public void BattleFadeOut()
    {
        fadeComplete = false;
        battleFadeSquare.DOFade(1f, fadeDuration).OnComplete(() => fadeComplete = true);
    }

    private void OnDestroy()
    {
        battleFadeSquare.DOKill();
    }
}
