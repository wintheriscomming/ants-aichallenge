namespace Ants;

public abstract class Bot
{
    public abstract void DoTurn(IGameState state);

    protected static void IssueOrder(Location loc, Direction direction)
    {
        Console.Out.WriteLine("o {0} {1} {2}", loc.Row, loc.Col, direction.ToChar());
    }
}