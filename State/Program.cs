

//O padrão de design de estado é um padrão comportamental que permite que um objeto altere seu comportamento quando seu estado interno é alterado.
//Isso pode ser útil quando um objeto deve alterar seu comportamento em tempo de execução dependendo de algum estado, e quando você quer evitar grandes condicionais.

//Cada estado pode ser considerado como sendo uma estratégia independente. O padrão de estado encapsula os estados em classes separadas,
//e delega a comportamentos para essas classes de estado.
//A classe original simplesmente mantém uma referência para o objeto de estado atual e delega todo o trabalho relacionado ao estado para ele.

//O padrão de estado é útil quando:

//O comportamento de um objeto deve mudar dependendo de seu estado, e quando complexas condições de comando dependem desse estado.
//Quando um objeto precisa mudar seu comportamento em tempo de execução dependendo de seu estado.
//Quando o código tem muitos comandos condicionais que dependem da implementação do objeto.


class Player
{
    private IAnimationStates _states = new IdleState();
    public void ChangeState(IAnimationStates state)
    {
        _states = state;
    }

    public void PressingLeft()
    {
        _states.WalkingLeft(this);
    }

    public void PressingRight()
    {
        _states.WalkingRight(this);
    }

    public void ReturnToIdle()
    {
        _states.Idle(this);
    }

    public void PressingUpAndRight()
    {
        _states.JumpRight(this);
    }

    public void PressingUpAndLeft()
    {
        _states.JumpLeft(this);
    }
}

interface IAnimationStates
{
    void WalkingLeft(Player player);
    void WalkingRight(Player player);
    void Idle(Player player);
    void JumpLeft(Player player);
    void JumpRight(Player player);
}

class WalkingRightState : IAnimationStates
{
    public void Idle(Player player)
    {
        throw new NotImplementedException();
    }

    public void JumpLeft(Player player)
    {
        throw new NotImplementedException();
    }

    public void JumpRight(Player player)
    {
        throw new NotImplementedException();
    }

    public void WalkingLeft(Player player)
    {
        throw new NotImplementedException();
    }

    public void WalkingRight(Player player)
    {
        throw new NotImplementedException();
    }
}

class IdleState : IAnimationStates
{
    public void Idle(Player player)
    {
        throw new NotImplementedException();
    }

    public void JumpLeft(Player player)
    {
        throw new NotImplementedException();
    }

    public void JumpRight(Player player)
    {
        throw new NotImplementedException();
    }

    public void WalkingLeft(Player player)
    {
        throw new NotImplementedException();
    }

    public void WalkingRight(Player player)
    {
        throw new NotImplementedException();
    }
}

class JumpRightState : IAnimationStates
{
    public void Idle(Player player)
    {
        throw new NotImplementedException();
    }

    public void JumpLeft(Player player)
    {
        throw new NotImplementedException();
    }

    public void JumpRight(Player player)
    {
        throw new NotImplementedException();
    }

    public void WalkingLeft(Player player)
    {
        throw new NotImplementedException();
    }

    public void WalkingRight(Player player)
    {
        throw new NotImplementedException();
    }
}

class JumpLeftState : IAnimationStates
{
    public void Idle(Player player)
    {
        //do nothing
    }

    public void JumpLeft(Player player)
    {
        //do nothing
    }

    public void JumpRight(Player player)
    {
        //do nothing
    }

    public void WalkingLeft(Player player)
    {
        //do nothing
    }

    public void WalkingRight(Player player)
    {
        //do nothing
    }
}

class WalkingLeftState : IAnimationStates
{
    public void Idle(Player player)
    {
        player.ChangeState(new IdleState());
    }

    public void JumpLeft(Player player)
    {
        player.ChangeState(new JumpLeftState());
    }

    public void JumpRight(Player player)
    {
        player.ChangeState(new JumpRightState());
    }

    public void WalkingLeft(Player player)
    {
       //do nothing
    }

    public void WalkingRight(Player player)
    {
        player.ChangeState(new WalkingRightState());
    }
}