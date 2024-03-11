public class ChestStateMachine : GenericStateMachine<ChestController>
{
    public ChestStateMachine(ChestController Owner) : base(Owner)
    {
        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        States.Add(ChestState.Empty, new EmptyState<ChestController>());
        States.Add(ChestState.Locked, new LockedState<ChestController>());
        States.Add(ChestState.Progress, new ProgressState<ChestController>());
        States.Add(ChestState.Open, new OpenState<ChestController>());
    }
}