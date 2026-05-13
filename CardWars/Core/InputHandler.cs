using Raylib_cs;
using CardWars.Cards;
using CardWars.Core;
using CardWars.GameManager;
using CardWars.Zones;

public class InputSystem
{
    private GameLogic game;
    private GameContext context;

    public InputSystem(GameLogic game, GameContext context)
    {
        this.game = game;
        this.context = context;
    }

    public void Update()
    {
        var mouse = Raylib.GetMousePosition();

        game.SetHoveredCard(null);

        foreach (var player in new[] { context.Player1, context.Player2 })
        {
            int i = 0;

            foreach (var card in player.Field.Cards)
            {
                var rect = GetRect(i, player);

                if (Raylib.CheckCollisionPointRec(mouse, rect))
                {
                    game.SetHoveredCard(card);
                    return;
                }

                i++;
            }
        }
    }

    private Rectangle GetRect(int i, PlayerState player)
    {
        int centerX = 800;
        float offset = i - 2;

        return new Rectangle(
            centerX + offset * 80,
            player == context.Player1 ? 600 : 100,
            120,
            160
        );
    }
}