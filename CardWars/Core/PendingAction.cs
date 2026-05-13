using CardWars.Cards;
using CardWars.Interfaces;

namespace CardWars.Core;

public class PendingAction
{
    public IGameAction? Action { get; set; }
    
    public CardMain? Source { get; set; }
    
    public CardMain? Target { get; set; }
    
    public bool IsComplete => 
        Action != null 
        && Source != null
        && Target != null;

    public void Clear()
    {
        Action = null;
        Source = null;
        Target = null;
    }
}