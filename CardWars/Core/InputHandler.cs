using Raylib_cs;
using CardWars.Cards;
using CardWars.Core;
using CardWars.GameManager;

public class InputSystem
{
    private GameLogic game;
    private GameContext context;
    private GameRenderer renderer;

    public InputSystem(GameLogic game, GameContext context, GameRenderer renderer)
    {
        this.game     = game;
        this.context  = context;
        this.renderer = renderer;
    }

    public void Update()
    {
        var mouse   = Raylib.GetMousePosition();
        bool clicked = Raylib.IsMouseButtonPressed(MouseButton.Left);

        // --- HOVER ---
        game.SetHoveredCard(null);

        CardMain hovered = null;

        // Hover campo P1
        int i = 0;
        foreach (var card in context.Player1.Field.Cards)
        {
            var rect = renderer.GetFieldRect(i, renderer.P1FieldY);
            if (Raylib.CheckCollisionPointRec(mouse, rect))
            {
                hovered = card;
                break;
            }
            i++;
        }

        // Hover campo P2
        if (hovered == null)
        {
            i = 0;
            foreach (var card in context.Player2.Field.Cards)
            {
                var rect = renderer.GetFieldRect(i, renderer.P2FieldY);
                if (Raylib.CheckCollisionPointRec(mouse, rect))
                {
                    hovered = card;
                    break;
                }
                i++;
            }
        }

        // Hover mano P1
        if (hovered == null)
        {
            i = 0;
            foreach (var card in context.Player1.Hand.Cards)
            {
                var rect = renderer.GetHandRect(i);
                if (Raylib.CheckCollisionPointRec(mouse, rect))
                {
                    hovered = card;
                    break;
                }
                i++;
            }
        }

        game.SetHoveredCard(hovered);

        // --- CLICK ---
        if (!clicked) return;

        var selected = game.SelectedCard;

        if (hovered == null)
        {
            // Click en vacío: deseleccionar
            game.SetSelectedCard(null);
            return;
        }

        // Sin carta seleccionada todavía
        if (selected == null)
        {
            // Solo puedes seleccionar cartas tuyas (P1)
            if (hovered.Owner == context.Player1)
                game.SetSelectedCard(hovered);
            return;
        }

        // Ya hay carta seleccionada
        if (hovered == selected)
        {
            // Click en la misma: deseleccionar
            game.SetSelectedCard(null);
            return;
        }

        if (hovered.Owner == context.Player1)
        {
            // Click en otra carta propia: cambiar selección
            game.SetSelectedCard(hovered);
            return;
        }

        // Click en carta enemiga: atacar
        if (selected.CurrentZone == selected.Owner.Field
            && hovered.CurrentZone == hovered.Owner.Field)
        {
            game.Attack(selected, hovered);
            return;
        }

        game.SetSelectedCard(null);
    }

    // -------------------------------------------------
    // Teclas de acceso rápido
    //   P   = jugar carta seleccionada de la mano
    //   E   = terminar turno
    // -------------------------------------------------
    public void HandleKeys()
    {
        // Jugar carta (P)
        if (Raylib.IsKeyPressed(KeyboardKey.P))
        {
            var sel = game.SelectedCard;
            if (sel != null && sel.Owner == context.Player1
                && sel.CurrentZone == sel.Owner.Hand)
            {
                game.PlayCard(sel);
            }
        }

        // Terminar turno (E)
        if (Raylib.IsKeyPressed(KeyboardKey.E))
        {
            game.EndTurn();
        }
    }
}
