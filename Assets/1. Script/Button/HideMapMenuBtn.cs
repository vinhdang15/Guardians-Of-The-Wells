using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMapMenuBtn : BtnBase
{
    protected override void Start() 
    {
        base.Start();
    }

    protected override void OnButtonClick()
    {
        PlayClickSound();
        PanelManager.Instance.HideMapMenu();

    }
}
