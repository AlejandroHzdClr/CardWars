using CardWars.Cards;

namespace CardWars.GameManager;

public class Zones
{
    public List<CardMain> Deck = new();

    public List<CardMain> Hand = new();

    public List<CardMain> Field = new();

    public List<CardMain> Graveyard = new();

    // =========================
    // ENERGY
    // =========================

    public int CurrentEnergy = 0;

    public int MaxEnergy = 0;
}