using CardWars.GameManager;
using CardWars.Zones;
using Raylib_cs;
using CardWars.Cards;

namespace CardWars.Core;

public class GameRenderer
{
    private GameContext context;
    private GameLogic input;

    // Layout constants
    // Window: 1500 x 900
    // Left   (Deck):      x=20,   w=120
    // Center (Field):     x=200 - x=1280,  w=1080
    // Right  (Graveyard): x=1300, w=120
    // Bottom (Hand):      y=720,  h=160

    private const int CardW = 120;
    private const int CardH = 160;

    // --- DECK ---
    private const int DeckX = 20;

    // --- GRAVEYARD ---
    private const int GraveyardX = 1360;

    // --- FIELD ---
    private const int FieldStartX = 200;
    private const int FieldSlotW  = 140;   // card + gap
    private const int FieldP2Y    = 80;
    private const int FieldP1Y    = 500;

    // --- HAND ---
    private const int HandY       = 720;
    private const int HandSlotW   = 130;

    public GameRenderer(GameContext context, GameLogic input)
    {
        this.context = context;
        this.input = input;
    }

    public void Draw()
    {
        DrawBackground();
        DrawDeck(context.Player1, 750);
        DrawDeck(context.Player2, 100);
        DrawGraveyard(context.Player1, 750);
        DrawGraveyard(context.Player2, 100);
        DrawField(context.Player1, FieldP1Y);
        DrawField(context.Player2, FieldP2Y);
        DrawHand(context.Player1);
        DrawZoneLabels();
        DrawTurnInfo();
        DrawHover();
    }

    // -------------------------------------------------
    // BACKGROUND
    // -------------------------------------------------
    private void DrawBackground()
    {
        // Board split line
        Raylib.DrawLine(0, 450, 1500, 450, new Color(255, 255, 255, 40));

        // Zone backgrounds
        // Deck area
        Raylib.DrawRectangle(10, 10, 140, 880, new Color(0, 0, 0, 60));
        // Graveyard area
        Raylib.DrawRectangle(1350, 10, 140, 880, new Color(0, 0, 0, 60));
        // Hand area
        Raylib.DrawRectangle(150, 710, 1190, 180, new Color(0, 0, 0, 60));
    }

    // -------------------------------------------------
    // DECK  — apilado en la izquierda
    // -------------------------------------------------
    private void DrawDeck(PlayerState player, int y)
    {
        int count = player.Deck.CardCount;

        // Sombra de pila (máx 5 capas)
        int layers = Math.Min(count, 5);
        for (int i = layers - 1; i >= 0; i--)
        {
            Raylib.DrawRectangle(DeckX + i * 2, y + i * 2, CardW, CardH,
                new Color(20, 40, 80, 220));
            Raylib.DrawRectangleLines(DeckX + i * 2, y + i * 2, CardW, CardH,
                new Color(100, 140, 200, 180));
        }

        // Cara frontal
        if (count > 0)
        {
            Raylib.DrawRectangle(DeckX, y, CardW, CardH, new Color(30, 60, 120, 255));
            Raylib.DrawRectangleLines(DeckX, y, CardW, CardH, Color.SkyBlue);
            Raylib.DrawText("DECK", DeckX + 28, y + 60, 16, Color.SkyBlue);
            Raylib.DrawText($"{count}", DeckX + 48, y + 85, 20, Color.White);
        }
        else
        {
            Raylib.DrawRectangleLines(DeckX, y, CardW, CardH, new Color(100, 100, 100, 120));
            Raylib.DrawText("EMPTY", DeckX + 20, y + 70, 14, new Color(120, 120, 120, 200));
        }
    }

    // -------------------------------------------------
    // GRAVEYARD — columna derecha
    // -------------------------------------------------
    private void DrawGraveyard(PlayerState player, int y)
    {
        int count = player.Graveyard.CardCount;

        Raylib.DrawRectangle(GraveyardX, y, CardW, CardH, new Color(60, 20, 20, 220));
        Raylib.DrawRectangleLines(GraveyardX, y, CardW, CardH,
            count > 0 ? new Color(200, 60, 60, 200) : new Color(80, 40, 40, 150));

        Raylib.DrawText("GY", GraveyardX + 38, y + 60, 16,
            count > 0 ? Color.Red : new Color(100, 60, 60, 200));
        Raylib.DrawText($"{count}", GraveyardX + 48, y + 85, 20, Color.White);

        // Nombre de la carta de encima
        if (count > 0)
        {
            var top = player.Graveyard.Cards[^1];
            string name = top.Name.Length > 10 ? top.Name[..10] + "." : top.Name;
            Raylib.DrawText(name, GraveyardX + 5, y + 115, 10, new Color(220, 150, 150, 200));
        }
    }

    // -------------------------------------------------
    // FIELD — zona central
    // -------------------------------------------------
    private void DrawField(PlayerState player, int y)
    {
        int i = 0;
        foreach (var card in player.Field.Cards)
        {
            var rect = GetFieldRect(i, y);
            DrawCard(card, (int)rect.X, (int)rect.Y, card == input.HoveredCard, card == input.SelectedCard);
            i++;
        }
    }

    // -------------------------------------------------
    // HAND — fila inferior (solo P1)
    // -------------------------------------------------
    private void DrawHand(PlayerState player)
    {
        int i = 0;
        foreach (var card in player.Hand.Cards)
        {
            var rect = GetHandRect(i);
            DrawCard(card, (int)rect.X, (int)rect.Y, card == input.HoveredCard, card == input.SelectedCard);
            i++;
        }
    }

    // -------------------------------------------------
    // CARD DRAWING
    // -------------------------------------------------
    private void DrawCard(CardMain card, int x, int y, bool hovered, bool selected)
    {
        Color bg    = new Color(25, 35, 60, 240);
        Color border = new Color(80, 100, 160, 200);

        if (selected)
        {
            bg     = new Color(180, 100, 0, 240);
            border = Color.Orange;
        }
        else if (hovered)
        {
            bg     = new Color(40, 55, 100, 240);
            border = Color.Yellow;
        }

        // Shadow
        Raylib.DrawRectangle(x + 4, y + 4, CardW, CardH, new Color(0, 0, 0, 100));

        // Body
        Raylib.DrawRectangle(x, y, CardW, CardH, bg);
        Raylib.DrawRectangleLines(x, y, CardW, CardH, border);

        // Can't attack tint
        if (!card.CanAttack)
            Raylib.DrawRectangle(x, y, CardW, CardH, new Color(0, 0, 0, 80));

        // Name
        string name = card.Name.Length > 12 ? card.Name[..12] : card.Name;
        Raylib.DrawText(name, x + 6, y + 8, 11, Color.White);

        // Separator
        Raylib.DrawLine(x + 4, y + 24, x + CardW - 4, y + 24, border);

        // Cost
        Raylib.DrawText($"Cost: {card.Cost}", x + 6, y + 30, 11, new Color(120, 200, 255, 255));

        // Damage
        Raylib.DrawText($"ATK:  {card.Damage}", x + 6, y + 48, 11, new Color(255, 120, 120, 255));

        // Effects (hasta 3)
        int ey = y + 70;
        int shown = 0;
        foreach (var effect in card.Effects)
        {
            if (shown >= 3) break;
            string desc = effect.GetDescription();
            if (desc.Length > 14) desc = desc[..14];
            Raylib.DrawText(desc, x + 4, ey, 9, new Color(120, 220, 150, 200));
            ey += 14;
            shown++;
        }

        // Tapped indicator
        if (!card.CanAttack)
            Raylib.DrawText("TAPPED", x + 22, y + CardH - 18, 10, new Color(255, 200, 0, 200));
    }

    // -------------------------------------------------
    // LABELS & HUD
    // -------------------------------------------------
    private void DrawZoneLabels()
    {
        // Deck labels
        Raylib.DrawText("P2 DECK", DeckX + 8, 68, 10, new Color(150, 180, 255, 180));
        Raylib.DrawText("P1 DECK", DeckX + 8, 818, 10, new Color(150, 180, 255, 180));

        // Graveyard labels
        Raylib.DrawText("P2 GY",  GraveyardX + 15, 68, 10, new Color(255, 150, 150, 180));
        Raylib.DrawText("P1 GY",  GraveyardX + 15, 818, 10, new Color(255, 150, 150, 180));

        // Field labels
        Raylib.DrawText("ENEMY FIELD", FieldStartX, 60, 14, new Color(255, 100, 100, 180));
        Raylib.DrawText("YOUR FIELD",  FieldStartX, 480, 14, new Color(100, 200, 100, 180));
        Raylib.DrawText("YOUR HAND",   FieldStartX, 700, 14, new Color(200, 200, 100, 180));
    }

    private void DrawTurnInfo()
    {
        string phase  = context.Turns.CurrentPhase.ToString();
        string player = context.Turns.CurrentPlayer == context.Player1 ? "Player 1" : "Player 2";
        int    turn   = context.Turns.TurnNumber;

        Raylib.DrawText($"Turn {turn}  |  {player}  |  Phase: {phase}",
            200, 870, 16, Color.White);

        // Selected card hint
        if (input.SelectedCard != null)
        {
            Raylib.DrawText($"Selected: {input.SelectedCard.Name}  (click target to attack / click field to play)",
                200, 850, 13, Color.Orange);
        }
    }

    // -------------------------------------------------
    // HOVER OUTLINE
    // -------------------------------------------------
    private void DrawHover()
    {
        if (input.HoveredCard == null) return;

        var rect = GetCardRect(input.HoveredCard);
        Raylib.DrawRectangleLines(
            (int)rect.X - 2, (int)rect.Y - 2,
            CardW + 4, CardH + 4,
            Color.Yellow);
    }

    // -------------------------------------------------
    // LAYOUT HELPERS  (shared with InputSystem)
    // -------------------------------------------------
    public Rectangle GetFieldRect(int i, int y)
    {
        return new Rectangle(FieldStartX + i * FieldSlotW, y, CardW, CardH);
    }

    public Rectangle GetHandRect(int i)
    {
        return new Rectangle(FieldStartX + i * HandSlotW, HandY, CardW, CardH);
    }

    public Rectangle GetCardRect(CardMain card)
    {
        var player = card.Owner;

        // Field P1
        int idx = player.Field.Cards.ToList().IndexOf(card);
        if (idx >= 0)
            return GetFieldRect(idx, player == context.Player1 ? FieldP1Y : FieldP2Y);

        // Hand P1
        idx = player.Hand.Cards.ToList().IndexOf(card);
        if (idx >= 0)
            return GetHandRect(idx);

        return new Rectangle(0, 0, CardW, CardH);
    }

    // Exposed for InputSystem
    public int P1FieldY => FieldP1Y;
    public int P2FieldY => FieldP2Y;
    public int HandY_   => HandY;
}
