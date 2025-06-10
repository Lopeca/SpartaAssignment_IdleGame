using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectPanel : MonoBehaviour
{
    [SerializeField] private GameObject stageSelectButtonPrefab;
    [SerializeField] private GameObject contentContainer;
    
    private void Start()
    {
        contentContainer.EmptyChildren();
        
        for (int i = 0; i < GameManager.AllStageCount; i++)
        {
            StageSelectButton stageSelectButton = Instantiate(stageSelectButtonPrefab, contentContainer.transform).GetComponent<StageSelectButton>();
            stageSelectButton.Init(i+1);
        }
    }
}
