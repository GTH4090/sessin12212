using System;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using KhranDesktop.Models;
using static KhranDesktop.Classes.Helper;

namespace KhranDesktop.Pages;

public partial class Auth : UserControl
{
    public Auth()
    {
        InitializeComponent();
        
    }


    private void PasswCb_OnChecked(object? sender, RoutedEventArgs e)
    {
        PasswordTbx.PasswordChar = '\0';
        
    }

    private void PasswCb_OnUnchecked(object? sender, RoutedEventArgs e)
    {
        PasswordTbx.PasswordChar = '*';
    }

    private void LoginBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (Db.Users.FirstOrDefault(el => el.Login == LoginTbx.Text) != null)
            {
                var item = Db.Users.FirstOrDefault(el => el.Login == LoginTbx.Text) as User;
                if (BCrypt.Net.BCrypt.Verify(PasswordTbx.Text, item.Password))
                {
                    Log = item;
                    Navigationn.Content = new MainMenu();
                }
                else
                {
                    Info("Неверный пароль");
                }
            }
            else
            {
                Info("Неверный логин");
            }
        }
        catch (Exception exception)
        {
            Error();
        }
    }

    private void RegBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigationn.Content = new Registration();
    }
}