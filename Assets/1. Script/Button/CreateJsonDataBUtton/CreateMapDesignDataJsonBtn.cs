public class CreateMapDesignDataJsonBtn : BtnBase
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void OnButtonClick()
    {
        JSONCreator.Instance.CreateMapDesignDataJson();
        base.OnButtonClick();
    }
}
