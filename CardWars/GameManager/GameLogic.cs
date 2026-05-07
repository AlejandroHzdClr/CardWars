using System.Numerics;
using CardWars.Cards;
using CardWars.Game;
using Raylib_cs;

namespace CardWars.GameManager;

public class GameLogic
{
    public List<CardMain> Cards = new();

    public GameState State = GameState.Idle;

    public CardMain SelectedCard;
    public CardMain HoveredCard;

    public void Update()
    {
        Vector2 mouse = Raylib.GetMousePosition();

        HoveredCard = null;

        // Detect hover
        for (int i = 0; i < Cards.Count; i++)
        {
            var rect = GetCardRect(i);

            if (Raylib.CheckCollisionPointRec(mouse, rect))
            {
                HoveredCard = Cards[i];
            }
        }

        // Click logic
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            HandleClick(mouse);
        }
    }

    private void HandleClick(Vector2 mouse)
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            var rect = GetCardRect(i);

            if (!Raylib.CheckCollisionPointRec(mouse, rect))
                continue;

            var clicked = Cards[i];

            if (State == GameState.Idle)
            {
                SelectedCard = clicked;
                State = GameState.SelectingTarget;

                Console.WriteLine($"Selected source: {clicked.Name}");
                return;
            }

            if (State == GameState.SelectingTarget)
            {
                Console.WriteLine($"Target: {clicked.Name}");

                SelectedCard.Activate(clicked);

                SelectedCard = null;
                State = GameState.Idle;

                return;
            }
        }
    }

    public Rectangle GetCardRect(int i)
    {
        int screenWidth = 1500;
        int centerX = screenWidth / 2;

        float offset = i - (Cards.Count - 1) / 2f;

        int x = centerX + (int)(offset * 80);
        int y = 650 + (int)(Math.Abs(offset) * 10);

        return new Rectangle(x, y, 140, 200);
    }
}