namespace CardWars.Effects;

public class EffectData
{
    public string Type { get; set; }
    public int Amount { get; set; }
    public int Cost { get; set; } // FIX: era MaxCost, no matcheaba el JSON ("cost")
}
