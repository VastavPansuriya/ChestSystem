using System.Collections.Generic;

public class GenericStateMachine<T> where T : ChestController
{
    protected T Owner;
    protected IState currentStateDtaa;
    protected ChestState currState;
    protected Dictionary<ChestState, IState> States = new Dictionary<ChestState, IState>();

    public GenericStateMachine(T Owner) => this.Owner = Owner;

    public void Update() => currentStateDtaa?.Update();

    protected void ChangeState(IState newState)
    {
        currentStateDtaa?.OnStateExit();
        currentStateDtaa = newState;
        currentStateDtaa?.OnStateEnter();
    }

    public void ChangeState(ChestState newState)
    {
        currState = newState;
        ChangeState(States[newState]);
    }
    protected void SetOwner()
    {
        foreach (IState state in States.Values)
        {
            state.Owner = Owner;
        }
    }

    public ChestState GetCurrState() => currState;
}
