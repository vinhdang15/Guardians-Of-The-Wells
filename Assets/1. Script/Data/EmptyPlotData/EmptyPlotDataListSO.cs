using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmptyPlotDataList", menuName = "Data Config/EmptyPlotDataList", order = 2)]
public class EmptyPlotDataListSO : ScriptableObject
{
    public List<EmptyPlotSerializableData> emptyPlotDataList = new List<EmptyPlotSerializableData>();
}
