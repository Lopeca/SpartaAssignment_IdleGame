using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageSelectButton : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] TextMeshProUGUI text;

    public void Init(int id)
    {
        this.id = id;
        text.text = "Stage " + id;
    }

    public void OnClick()
    {
        GameManager.Instance.LoadStage(id);
    }
}
