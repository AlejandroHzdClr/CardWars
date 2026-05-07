using CardWars.Cards;
using Raylib_cs;

namespace CardWars.Rendering;

public static class CardRenderer
{
    public static void Draw(CardMain card, int x, int y, bool hovered, bool selected)
    {
        Color color = Color.Beige;

        if (selected)
            color = Color.Orange;

        if (hovered)
            color = Color.Yellow;

        Raylib.DrawRectangle(x, y, 140, 200, color);
        Raylib.DrawRectangleLines(x, y, 140, 200, Color.Black);

        Raylib.DrawText(card.Name, x + 10, y + 10, 20, Color.Black);
        Raylib.DrawText($"C:{card.Cost}", x + 10, y + 50, 20, Color.DarkBlue);
        Raylib.DrawText($"D:{card.Damage}", x + 10, y + 80, 20, Color.Red);
        Raylib.DrawText(card.EventType.ToString(), x + 10, y + 120, 15, Color.DarkGreen);
    }
}