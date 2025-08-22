public class XUiC_CraftingInfoWindowSCore : XUiC_CraftingInfoWindow
{
    public enum SCoreTabTypes
    {
        AdditionalOutput,
        None
    }
    public SCoreTabTypes SCoreTabType;
    public XUiController additionalOutputButton;

    public override void Init()
    {
        base.Init();
        additionalOutputButton = GetChildById("showadditionalOutput");
        additionalOutputButton.OnPress += AdditionalButton_OnPress;
    }

    public override bool GetBindingValue(ref string value, string bindingName)
    {
        if (bindingName == "showadditionalOutput")
        {
            value = (SCoreTabType == SCoreTabTypes.AdditionalOutput).ToString();
            return true;
        }

        return base.GetBindingValue(ref value, bindingName);
    }

    public void AdditionalButton_OnPress(XUiController _sender, int _mouseButton)
    {
       SCoreTabType = SCoreTabTypes.AdditionalOutput;
        SetSelectedButtonByType(SCoreTabType);
        IsDirty = true;
    }

    public void SetSelectedButtonByType(XUiC_CraftingInfoWindow.TabTypes tabType)
    {
        ((XUiV_Button)additionalOutputButton.ViewComponent).Selected = false;
        base.SetSelectedButtonByType(tabType);
    }

    public void SetSelectedButtonByType(SCoreTabTypes tabType)
    {
        ((XUiV_Button)ingredientsButton.ViewComponent).Selected = false;
        ((XUiV_Button)descriptionButton.ViewComponent).Selected = false;
        ((XUiV_Button)unlockedByButton.ViewComponent).Selected = false;
        ((XUiV_Button)additionalOutputButton.ViewComponent).Selected = true;

    }
}
