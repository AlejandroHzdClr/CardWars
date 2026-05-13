using System.Text.Json;
using System.Text.Json.Serialization;
using CardWars.Cards;
using CardWars.Core;
using CardWars.GameManager;
using CardWars.Zones;
using Raylib_cs;

class Program
{
    static void Main()
    {
        // ---------------------------
        // CONTEXT
        // ---------------------------
        PlayerState p1 = new PlayerState();
        PlayerState p2 = new PlayerState();

        GameContext context = new GameContext(p1, p2);

        // ---------------------------
        // INPUT + ENGINE
        // ---------------------------
        GameLogic input = new GameLogic(context);
        ActionResolver resolver = new ActionResolver();
        GameLoop loop = new GameLoop(context, resolver, input.ActionQueue);

        GameManager gameManager = new GameManager(input, loop);

        // ---------------------------
        // RENDERER (🔥 IMPORTANTE)
        // ---------------------------
        GameRenderer renderer = new GameRenderer(context, input);

        // ---------------------------
        // LOAD CARDS
        // ---------------------------
        string json = File.ReadAllText("../../../CardData/Agressive.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        options.Converters.Add(new JsonStringEnumConverter());

        var data = JsonSerializer.Deserialize<List<CardData>>(json, options);

        Console.WriteLine($"[DEBUG] Cards loaded: {data?.Count ?? 0}");

        foreach (var d in data)
        {
            context.Player1.Field.Add(CardFactory.Create(d, context.Player1, context.Player1.Field));
            context.Player2.Field.Add(CardFactory.Create(d, context.Player2, context.Player2.Field));
        }

        // ---------------------------
        // WINDOW
        // ---------------------------
        Raylib.InitWindow(1500, 900, "CardWars DEBUG");

        while (!Raylib.WindowShouldClose())
        {
            // 🔥 INPUT + ENGINE
            gameManager.Update();
            loop.Update();

            // ---------------------------
            // RENDER
            // ---------------------------
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.DarkGreen);

            renderer.Draw();

            // DEBUG INFO
            Raylib.DrawText($"P1: {context.Player1.Field.CardCount}", 20, 20, 20, Color.White);
            Raylib.DrawText($"P2: {context.Player2.Field.CardCount}", 20, 50, 20, Color.White);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}