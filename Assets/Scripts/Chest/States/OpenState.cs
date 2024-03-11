public class OpenState<T> : IState where T : ChestController
{
    public ChestController Owner { get; set ; }

    public void OnStateEnter()
    {
        Owner.PurchaseButtonToggle(false);
        Owner.SetInfo("Tap To Open");
    }

    public void OnStateExit()
    {
        return;
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        return;
        throw new System.NotImplementedException();
    }
}