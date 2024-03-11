
public class EmptyState<T> : IState where T : ChestController
{
    public ChestController Owner { get; set; }

    public void OnStateEnter()
    {
        Owner.SetEmpty();
    }

    public void OnStateExit()
    {
        Owner.SetChestVisualActive();
    }

    public void Update()
    {
        return;
        throw new System.NotImplementedException();
    }
}