using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectDataList", menuName = "Data Config/EffectDataList", order = 1)]
public class EffectDataListSO : ScriptableObject
{
    public List<EffectData> effectDataList = new List<EffectData>();
    public EffectData GetEffectData(string effectType)
    {  
        string normalizedEffectTypee = effectType.Trim().ToLower();
        // Debug.Log(effectType);
        // Debug.Log(effectDataList[0].effectType);
        // Debug.Log(effectType == effectDataList[0].effectType);
        return effectDataList.Find(data => data.effectType == effectType);
    }
}