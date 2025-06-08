using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LopecaExtension
{
    public static T GetRandom<T>(this List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            Debug.LogWarning("리스트가 null이거나 비어있습니다. 확인해주세요");
            return default;
        }
        
        int index = Random.Range(0, list.Count);
        return list[index];
    }

    public static void EmptyChildren(this GameObject go)
    {
        foreach (Transform child in go.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
