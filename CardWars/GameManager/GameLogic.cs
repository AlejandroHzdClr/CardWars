using System.Numerics;
using CardWars.Cards;
using CardWars.Game;
using Raylib_cs;

namespace CardWars.GameManager;

public class GameLogic
{

    public GameState State = GameState.Idle;
    public GameManager Zone = new();
    public CardMain LauncherCard;
    public CardMain SelectedCard;
    public CardMain HoveredCard;
    public CardListener EventListener;
    public bool launchedEffect = false;

    public void Update()
    {
        Vector2 mouse = Raylib.GetMousePosition();

        HoveredCard = null;

        // Detect hover
        for (int i = 0; i < Zone.PlayerZones.Field.Count; i++)
        {
            var rect = GetCardRect(i);

            if (Raylib.CheckCollisionPointRec(mouse, rect))
            {
                HoveredCard = Zone.PlayerZones.Field[i];
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
        for (int i = 0; i < Zone.PlayerZones.Field.Count; i++)
        {
            var rect = GetCardRect(i);

            if (!Raylib.CheckCollisionPointRec(mouse, rect))
                continue;

            var clicked = Zone.PlayerZones.Field[i];

            if (State == GameState.Idle)
            {
                launchedEffect = false;
                LauncherCard = clicked;
                State = GameState.SelectingSource;

                Console.WriteLine($"Selected Launcher: {clicked.Name}");
                return;
            }

            if (State == GameState.SelectingSource)
            {
                SelectedCard = clicked;
                State = GameState.SelectingTarget;

                Console.WriteLine($"Selected source: {clicked.Name}");
                return;
            }

            if (State == GameState.SelectingTarget)
            {
                Console.WriteLine($"Target: {clicked.Name}");
                if (!launchedEffect)
                {
                    LauncherCard.Activate(clicked);
                    Console.WriteLine("Se lanzo");
                    launchedEffect = true;
                }
                else
                {
                    Console.WriteLine("Ya fue lanzado");
                }
               

                Console.WriteLine(clicked.Damage);
                SelectedCard = null;
                LauncherCard = null;
                State = GameState.Idle;

                return;
            }
        }
    }

    public Rectangle GetCardRect(int i)
    {
        int screenWidth = 1500;
        int centerX = screenWidth / 2;

        float offset = i - (Zone.PlayerZones.Field.Count - 1) / 2f;

        int x = centerX + (int)(offset * 80);
        int y = 650 + (int)(Math.Abs(offset) * 10);

        return new Rectangle(x, y, 140, 200);
    }
}