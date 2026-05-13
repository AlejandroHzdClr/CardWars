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
        // ENGINE
        // ---------------------------
        GameLogic  logic    = new GameLogic(context);
        ActionResolver resolver = new ActionResolver();
        GameLoop   loop     = new GameLoop(context, resolver, logic.ActionQueue);
        GameManager gameManager = new GameManager(logic, loop);

        // ---------------------------
        // RENDERER
        // ---------------------------
        GameRenderer renderer = new GameRenderer(context, logic);

        // ---------------------------
        // INPUT (necesita renderer para los rects)
        // ---------------------------
        InputSystem input = new InputSystem(logic, context, renderer);

        // ---------------------------
        // LOAD CARDS  →  al DECK, no al Field
        // ---------------------------
        string json = File.ReadAllText("../../../CardData/Agressive.json");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new JsonStringEnumConverter());

        var data = JsonSerializer.Deserialize<List<CardData>>(json, options);

        Console.WriteLine($"[DEBUG] Cards loaded: {data?.Count ?? 0}");

        foreach (var d in data)
        {
            // FIX: las cartas van al Deck, no directamente al Field
            var c1 = CardFactory.Create(d, context.Player1, context.Player1.Deck);
            var c2 = CardFactory.Create(d, context.Player2, context.Player2.Deck);

            context.Player1.Deck.Add(c1);
            context.Player2.Deck.Add(c2);
        }

        // Barajar y repartir 5 cartas a la mano de cada jugador
        context.Player1.Deck.Shuffle();
        context.Player2.Deck.Shuffle();

        for (int i = 0; i < 5; i++)
        {
            var card1 = context.Player1.Deck.Draw();
            if (card1 != null) context.MoveCard(card1, context.Player1.Hand);

            var card2 = context.Player2.Deck.Draw();
            if (card2 != null) context.MoveCard(card2, context.Player2.Hand);
        }

        // ---------------------------
        // WINDOW
        // ---------------------------
        Raylib.InitWindow(1500, 900, "CardWars");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            // FIX: loop.Update() ya se llama dentro de gameManager.Update()
            // Llamarlo dos veces ejecutaba cada acción dos veces
            input.Update();
            input.HandleKeys();
            gameManager.Update();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(new Color(20, 50, 30, 255));

            renderer.Draw();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
