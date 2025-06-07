
public abstract class PlayerState : IState
{
    protected Player player;
    protected PlayerFSM fsm;

    protected PlayerState(Player _player, PlayerFSM _fsm)
    {
        player = _player;
        fsm = _fsm;
    }
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();

}
