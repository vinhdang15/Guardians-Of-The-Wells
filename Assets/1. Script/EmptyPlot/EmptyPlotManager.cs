using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EmptyPlotManager : MonoBehaviour
{
    [SerializeField] EmptyPlot emptyPlotPrefab;
    public List<EmptyPlot> emptyPlotList = new List<EmptyPlot>();

    // private void Start()
    // {
    //     StartCoroutine(InitEmptyPlotCoroutine());
    // }

    // private IEnumerator InitEmptyPlotCoroutine()
    // {
    //     yield return new WaitUntil(() => CSVEmptyPlotDataReader.Instance.IsDataLoaded);
    //     InitEmptyPlot();
    // }

    private void InitEmptyPlot()
    {
        List<EmptyPlotData> emptyPlotDataList = CSVEmptyPlotDataReader.Instance.emptyPlotDataList.emptyPlotDataList;
        foreach(var emptyPlotData in emptyPlotDataList)
        {
            Vector2 pos = new Vector2(emptyPlotData.x,emptyPlotData.y);
            EmptyPlot emptyPlotScript = Instantiate(emptyPlotPrefab,pos, quaternion.identity, transform);
            emptyPlotList.Add(emptyPlotScript);
        }
    }
    public GameObject GetEmptyplot(GameObject emptyPlot)
    {
        return emptyPlot;
    }
}
