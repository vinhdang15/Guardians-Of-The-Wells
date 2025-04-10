using UnityEngine;

public class ResumingGameBtn : BtnBase
{
    protected override void Start() 
    {
        base.Start();
    }

    protected override void OnButtonClick()
    {
        PlayClickSound();
        PanelManager.Instance.HidePauseMenu();
        ResumingGame();
    }

    private void ResumingGame()
    {
        Time.timeScale = 1;
    }
}
