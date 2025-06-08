using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Progress
{
    List<StageData> stages = new List<StageData>();
}

[System.Serializable]
public class StageData
{
    public string name;
}