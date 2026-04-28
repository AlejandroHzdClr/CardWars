namespace CardWars.ViewModels;

public class CardViewModel
{
    public string Name { get; }
    public int Cost { get; }
    public string Description { get; }
    public string ImagePath { get; }

    public CardViewModel(string name, int cost, string description, string imagePath)
    {
        Name = name;
        Cost = cost;
        Description = description;
        ImagePath = imagePath;
    }
}