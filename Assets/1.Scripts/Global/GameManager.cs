using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance) return _instance;
            
            GameObject gameManager = new GameObject("GameManager");
            DontDestroyOnLoad(gameManager);
            _instance = gameManager.GetComponent<GameManager>();
            return _instance;
        }
    }
    
    [SerializeField] List<StageData> stages = new List<StageData>();
    
    public const int AllStageCount = 2;
    private int _selectedStageId = 1;
    
    public StageData CurrentStage => stages[_selectedStageId - 1];
    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void LoadStage(int id)
    {
        _selectedStageId = id;
        SceneManager.LoadScene("MainScene");
    }
}
