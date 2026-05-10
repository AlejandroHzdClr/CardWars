namespace CardWars.GameManager;

public class GameTurns
{
    private Random rng = new Random();

    public int WhoStart()
    {
        return rng.Next(2);;
    }

    public int PassTurn(int player)
    {
        if (player == 1)
        {
            return 0;
        }

        return 1;
    }
}