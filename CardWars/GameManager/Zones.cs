using CardWars.Cards;

namespace CardWars.GameManager;

public class Zones
{
    public List<CardMain> Cards = new();
    public List<CardMain> Hand = new();
    public List<CardMain> Field = new();
    public List<CardMain> Graveyard = new();
    public int Energy=0;
}