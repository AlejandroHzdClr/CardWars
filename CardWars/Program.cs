using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Program
{
    static void Main()
    {
        var window = new RenderWindow(
            new VideoMode(new Vector2u(800, 600)),
            "SFML en C#"
        );

        window.Closed += (_, __) => window.Close();

        while (window.IsOpen)
        {
            window.DispatchEvents();
            window.Clear(Color.Black);
            window.Display();
        }
    }
}