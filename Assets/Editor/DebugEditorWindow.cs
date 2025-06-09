using UnityEditor;
using UnityEngine;

public class DebugEditorWindow : EditorWindow
{
    [MenuItem("Tools/디버그 윈도우")]
    public static void ShowWindow()
    {
        GetWindow<DebugEditorWindow>("디버그 툴");
    }

    void OnGUI()
    {
        GUILayout.Label("테스트 기능", EditorStyles.boldLabel);
        
        if (GUILayout.Button("배틀씬 초기화"))
        {
            InitBattle();
        }
        
        if (GUILayout.Button("아이템 랜덤 획득"))
        {
            AddRandomItem();
        }
    }

    void InitBattle()
    {
        BattleManager.Instance.InitBattle();
    }

    void AddRandomItem()
    {
        BattleManager.Instance.player.ObtainItem();
    }
}