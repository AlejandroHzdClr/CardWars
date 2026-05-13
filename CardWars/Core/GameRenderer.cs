using CardWars.GameManager;
using CardWars.Zones;
using Raylib_cs;
using CardWars.Cards;

namespace CardWars.Core;

public class GameRenderer
{
    private GameContext context;
    private GameLogic input;

    public GameRenderer(GameContext context, GameLogic input)
    {
        this.context = context;
        this.input = input;
    }

    public void Draw()
    {
        DrawZone(context.Player1);
        DrawZone(context.Player2);

        DrawHover();
    }

    private void DrawHover()
    {
        if (input.HoveredCard == null)
            return;

        var rect = GetCardRectFromCard(input.HoveredCard);

        Raylib.DrawRectangleLines(
            (int)rect.X,
            (int)rect.Y,
            (int)rect.Width,
            (int)rect.Height,
            Color.Yellow
        );
    }

    private void DrawZone(PlayerState player)
    {
        int i = 0;

        foreach (var card in player.Field.Cards)
        {
            var rect = GetRect(i, player);

            Raylib.DrawRectangleRec(rect, Color.DarkBlue);
            Raylib.DrawText(card.Name,
                (int)rect.X + 10,
                (int)rect.Y + 10,
                10,
                Color.White);

            i++;
        }

        i = 0;

        foreach (var card in player.Hand.Cards)
        {
            var rect = GetHandRect(i, player);

            Raylib.DrawRectangleRec(rect, Color.Gray);
            Raylib.DrawText(card.Name,
                (int)rect.X + 10,
                (int)rect.Y + 10,
                10,
                Color.White);

            i++;
        }
    }

    // -----------------------------
    // SAME LAYOUT AS INPUT SHOULD USE
    // -----------------------------

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

    private Rectangle GetHandRect(int i, PlayerState player)
    {
        int centerX = 800;
        float offset = i - 2;

        return new Rectangle(
            centerX + offset * 60,
            850,
            120,
            160
        );
    }

    // 🔥 IMPORTANTE: mismo layout para hover
    private Rectangle GetCardRectFromCard(CardMain card)
    {
        var player = card.Owner;

        int i = 0;

        foreach (var c in player.Field.Cards)
        {
            if (c == card)
                break;

            i++;
        }

        return GetRect(i, player);
    }
}