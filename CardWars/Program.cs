using System.Diagnostics.Tracing;
using Raylib_cs;
using System.Text.Json;
using System.Text.Json.Serialization;
using CardWars.Cards;
using CardWars.GameManager;
using CardWars.Interfaces;
using CardWars.Rendering;

class Program
{
    GameLogic game = new();
    static void Main()
    {
        string json = File.ReadAllText("../../../CardData/Agressive.json");

        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };
        options.Converters.Add(new JsonStringEnumConverter());

        var data = JsonSerializer.Deserialize<List<CardData>>(json, options);

        GameLogic game = new();
        CardListener listener = new(game.Zone);

        foreach (var d in data)
        {
            game.Zone.PlayerZones.Field.Add(CardFactory.Create(d));
            game.Zone.EnemyZones.Field.Add(CardFactory.Create(d));
            
        }
        
        foreach (CardMain main in game.Zone.PlayerZones.Field)
        {
            listener.Listener(main);
        }

        Raylib.InitWindow(1500, 900, "CardWars - TCG Core");

        while (!Raylib.WindowShouldClose())
        {
            game.Update();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.DarkGreen);

            int screenWidth = 1500;
            int centerX = screenWidth / 2;

            // DRAW HAND
            for (int i = 0; i < game.Zone.PlayerZones.Field.Count; i++)
            {
                var card = game.Zone.PlayerZones.Field[i];

                float offset = i - (game.Zone.PlayerZones.Field.Count - 1) / 2f;

                int x = centerX + (int)(offset * 80);
                int y = 650 + (int)(Math.Abs(offset) * 10);

                bool hovered = card == game.HoveredCard;
                bool selected = card == game.SelectedCard;

                CardRenderer.Draw(card, x, y, hovered, selected);
            }
            
            // DRAW Enemy hand
            for (int i = 0; i < game.Zone.EnemyZones.Field.Count; i++)
            {
                var card = game.Zone.EnemyZones.Field[i];

                float offset = i - (game.Zone.EnemyZones.Field.Count - 1) / 2f;

                int x = centerX + (int)(offset * 80);
                int y = 0 + (int)(Math.Abs(offset) * 10);

                bool hovered = card == game.HoveredCard;
                bool selected = card == game.SelectedCard;

                CardRenderer.Draw(card, x, y, hovered, selected);
            }

            // PREVIEW
            if (game.HoveredCard != null)
            {
                var c = game.HoveredCard;

                int px = 1100;
                int py = 200;

                Raylib.DrawRectangle(px, py, 300, 400, Color.Beige);
                Raylib.DrawRectangleLines(px, py, 300, 400, Color.Black);

                Raylib.DrawText(c.Name, px + 10, py + 10, 30, Color.Black);
                Raylib.DrawText($"Cost: {c.Cost}", px + 10, py + 70, 25, Color.DarkBlue);
                Raylib.DrawText($"Damage: {c.Damage}", px + 10, py + 110, 25, Color.Red);
                foreach (ICardEffect effect in c.Effects)
                {
                    Raylib.DrawText(effect.GetDescription(), px + 10, py + 150, 25, Color.DarkGreen);
                    py += 40;
                }
            }

            // STATE DEBUG
            Raylib.DrawText($"State: {game.State}", 20, 20, 20, Color.White);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}