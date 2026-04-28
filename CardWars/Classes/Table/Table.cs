using CardWars.Classes.Interfaces;

namespace CardWars.Table;

public class Table
{
    protected List<IPlayer> Players { get; private set; } = new List<IPlayer>();
    
}