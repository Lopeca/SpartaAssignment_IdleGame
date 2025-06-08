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


        if (GUILayout.Button("적 생성 테스트"))
        {
            SpawnEnemy();
        }

        if (GUILayout.Button("플레이어 위치 초기화"))
        {
            ResetPlayerPosition();
        }
    }

    void InitBattle()
    {
        BattleManager.Instance.InitBattle();
    }
    void SpawnEnemy()
    {
        Debug.Log("에디터에서 적 생성 실행");
        // 에디터 내에서만 가능한 작업 or Scene에 영향 주는 코드 작성 가능
    }

    void ResetPlayerPosition()
    {
        var player = GameObject.FindWithTag("Player");
        if (player)
        {
            player.transform.position = Vector3.zero;
            Debug.Log("플레이어 위치 초기화 완료");
        }
    }
}