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

        // PLAYER
        for (int i = 0; i < Zone.PlayerZones.Field.Count; i++)
        {
            var rect = GetCardRect(
                i,
                Zone.PlayerZones.Field.Count,
                Side.Player
            );

            if (Raylib.CheckCollisionPointRec(mouse, rect))
            {
                HoveredCard = Zone.PlayerZones.Field[i];
            }
        }
        
        for (int i = 0; i < Zone.PlayerZones.Hand.Count; i++)
        {
            var rect = GetHandRect(
                i,
                Zone.PlayerZones.Hand.Count
            );

            if (Raylib.CheckCollisionPointRec(mouse, rect))
            {
                HoveredCard = Zone.PlayerZones.Hand[i];
            }
        }

        // ENEMY
        for (int i = 0; i < Zone.EnemyZones.Field.Count; i++)
        {
            var rect = GetCardRect(
                i,
                Zone.EnemyZones.Field.Count,
                Side.Enemy
            );

            if (Raylib.CheckCollisionPointRec(mouse, rect))
            {
                HoveredCard = Zone.EnemyZones.Field[i];
            }
        }

        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            HandleClick(mouse);
        }
    }

    private void HandleClick(Vector2 mouse)
    {
        // PLAYER HAND
        for (int i = 0; i < Zone.PlayerZones.Hand.Count; i++)
        {
            var rect = GetHandRect(
                i,
                Zone.PlayerZones.Hand.Count
            );

            if (Raylib.CheckCollisionPointRec(mouse, rect))
            {
                PlayCard(Zone.PlayerZones.Hand[i]);
                return;
            }
        }
        
        // PLAYER
        for (int i = 0; i < Zone.PlayerZones.Field.Count; i++)
        {
            var rect = GetCardRect(
                i,
                Zone.PlayerZones.Field.Count,
                Side.Player
            );

            if (Raylib.CheckCollisionPointRec(mouse, rect))
            {
                ProcessCardClick(Zone.PlayerZones.Field[i]);
                return;
            }
        }

        // ENEMY
        for (int i = 0; i < Zone.EnemyZones.Field.Count; i++)
        {
            var rect = GetCardRect(
                i,
                Zone.EnemyZones.Field.Count,
                Side.Enemy
            );

            if (Raylib.CheckCollisionPointRec(mouse, rect))
            {
                ProcessCardClick(Zone.EnemyZones.Field[i]);
                return;
            }
        }
    }
    
    private void ProcessCardClick(CardMain clicked)
    {
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
                Console.WriteLine("Se lanzó");
                launchedEffect = true;
            }

            Console.WriteLine(clicked.Damage);

            SelectedCard = null;
            LauncherCard = null;
            State = GameState.Idle;
        }
    }

    public Rectangle GetCardRect(int i, int totalCards, Side side)
    {
        int screenWidth = 1500;
        int centerX = screenWidth / 2;

        float offset = i - (totalCards - 1) / 2f;

        int x = centerX + (int)(offset * 80);
        int y;

        if (side == Side.Player)
        {
            y = 650 + (int)(Math.Abs(offset) * 10);
        }
        else
        {
            y = 100 + (int)(Math.Abs(offset) * 10);
        }

        return new Rectangle(x, y, 140, 200);
    }
    
    public Rectangle GetHandRect(int i, int totalCards)
    {
        int screenWidth = 1500;
        int centerX = screenWidth / 2;

        float offset = i - (totalCards - 1) / 2f;

        int x = centerX + (int)(offset * 60);
        int y = 850;

        return new Rectangle(x, y, 140, 200);
    }

    private Zones CheckOwnerField(CardMain card)
    {
        if (card.Owner == Side.Player)
        {
            return Zone.PlayerZones;
        }
    
        return Zone.EnemyZones;
    }

    public void PlayCard(CardMain card)
    {
        Zones ownerZone =  CheckOwnerField(card);

        if (!ownerZone.Hand.Contains(card))
        {
            return;
        }

        if (ownerZone.Field.Count >= 5)
        {
            return;
        }
        
        ownerZone.Hand.Remove(card);
        ownerZone.Field.Add(card);
    }
}