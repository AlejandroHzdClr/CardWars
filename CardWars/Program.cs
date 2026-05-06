using Raylib_cs;

class Program
{
    static void Main()
    {
        Raylib.InitWindow(1500, 900, "CardWars");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.DarkGreen);
            Raylib.EndDrawing();
        }
    }
}