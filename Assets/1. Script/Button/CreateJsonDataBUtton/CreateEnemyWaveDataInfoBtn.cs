using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemyWaveDataBtn : BtnBase
{
     protected override void Start()
    {
        base.Start();
    }
    protected override void OnButtonClick()
    {
        JSONCreator.Instance.CreateEnemyWaveDataInfoJson();
        base.OnButtonClick();
    }
}
