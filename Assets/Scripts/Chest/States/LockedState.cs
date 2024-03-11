using UnityEngine;

public class LockedState<T> : IState where T : ChestController
{
    public ChestController Owner { get; set; }

    public void OnStateEnter()
    {
        const string msg = "Tap to StartUnlock";
        Owner.SetInfo(msg);
        Owner.SetPrice(Owner.GetTotalTime());
        Owner.PurchaseButtonToggle(true);
    }

    public void OnStateExit()
    {
        Debug.Log("Curr state locked was changed");
    }

    public void Update()
    {
        return;
        throw new System.NotImplementedException();
    }
}
