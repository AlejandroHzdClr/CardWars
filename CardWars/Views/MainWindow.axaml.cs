using Avalonia.Controls;
using CardWars.ViewModels;

namespace CardWars.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new CardViewModel(
            "Monkey D. Luffy",
            5,
            "El futuro Rey de los Piratas.",
            ""
        );
    }
}