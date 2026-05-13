using CardWars.GameManager;

namespace CardWars.Core;

public class GameManager
{
    private readonly GameLogic input;
    private readonly GameLoop loop;

    public GameManager(GameLogic input, GameLoop loop)
    {
        this.input = input;
        this.loop = loop;
    }

    public void Update()
    {
        input.Update();
        loop.Update(); // 🔥 FIX
    }
}