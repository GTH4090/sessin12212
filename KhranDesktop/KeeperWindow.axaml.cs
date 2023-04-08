using Avalonia.Controls;
using Avalonia.Interactivity;
using KhranDesktop.Pages;
using static KhranDesktop.Classes.Helper;

namespace KhranDesktop;

public partial class KeeperWindow : Window
{
    public KeeperWindow()
    {
        InitializeComponent();

        Navigationn = MainFrame;
        Win = this;
        Navigationn.Content = new Auth();
    }

    private void ExitBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigationn.Content = new Auth();
    }
}