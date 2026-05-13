using CardWars.Core;
using CardWars.Interfaces;

namespace CardWars.GameManager;

public class GameLoop
{
    private readonly GameContext _context;
    private readonly ActionResolver _resolver;
    private readonly Queue<IGameAction> _queue;

    public GameLoop(GameContext context, ActionResolver resolver, Queue<IGameAction> queue)
    {
        _context = context;
        _resolver = resolver;
        _queue = queue;
    }

    public void Update()
    {
        Console.WriteLine($"[DEBUG] Actions in queue: {_queue.Count}");

        while (_queue.Count > 0)
        {
            var action = _queue.Dequeue();

            Console.WriteLine($"[DEBUG] Executing: {action.GetType().Name}");

            _resolver.Resolve(_context, action);
        }
    }
}