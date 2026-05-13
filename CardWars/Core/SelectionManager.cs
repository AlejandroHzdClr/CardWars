using CardWars.Cards;

namespace CardWars.GameManager;

public class SelectionManager
{
    public CardMain Source { get; set; }
    public CardMain Target { get; set; }

    public bool HasSource => Source != null;

    public bool HasTarget => Target != null;

    public void Reset()
    {
        Source = null;
        Target = null;
    }
}