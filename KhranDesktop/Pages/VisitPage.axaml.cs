using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using KhranDesktop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static KhranDesktop.Classes.Helper;

namespace KhranDesktop.Pages;

public partial class VisitPage : UserControl
{
    private void LoadCbx()
    {
        try
        {
            DivisionCbx.Items = Db.Divisions.ToList();
            TargetCbx.Items = Db.Targets.ToList();

            
        }
        catch (Exception e)
        {
            Error();
        }
        
    }
    public VisitPage()
    {
        InitializeComponent();
        LoadCbx();
        VisitGrid.DataContext = new Visit();
        VisitorGrid.DataContext = new Visitor();
        StartDp.DisplayDateStart = DateTime.Now.AddDays(1);
        StartDp.DisplayDateEnd = DateTime.Now.AddDays(15);
        FinishDp.DisplayDateEnd = DateTime.Now.AddDays(15);
        BirthDp.DisplayDateEnd = DateTime.Now.AddYears(-16);
        TargetCbx.SelectedIndex = 0;
        DivisionCbx.SelectedIndex = 0;
        NameCbx.SelectedIndex = 0;
        try
        {
            (VisitGrid.DataContext as Visit).UserId = Log.Id;
            
        }
        catch (Exception e)
        {
            Error();
        }
        
        

    }

    

    private async void DocsBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filters.Add(new FileDialogFilter(){Name = "pdf", Extensions = new List<string>(){"pdf"}});
            open.AllowMultiple = false;
            var item = await open.ShowAsync(Win);
            if (item != null)
            {
                (VisitorGrid.DataContext as Visitor).PassportScan = File.ReadAllBytes(item[0]);
            }
        }
        catch (Exception exception)
        {
            Error();
        }
    }

    private void ClearBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigationn.Content = new VisitPage();
    }

    private async void ImgBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filters.Add(new FileDialogFilter(){Name = "jpg", Extensions = new List<string>(){"jpg"}});
            open.AllowMultiple = false;
            var item = await open.ShowAsync(Win);
            
            
            if (item != null)
            {
                MemoryStream stream = new MemoryStream(File.ReadAllBytes(item[0]));
                Avalonia.Media.Imaging.Bitmap bit = new Bitmap(stream);
                if (bit.Size.Height * 4 == bit.Size.Width * 3 && stream.Length <= 1024 * 1024 * 4)
                {
                    (VisitorGrid.DataContext as Visitor).Photo = File.ReadAllBytes(item[0]);
                    UserImg.Source = bit;
                }
                
            }
        }
        catch (Exception exception)
        {
            Error();
        }
    }

    private void DivisionCbx_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        try
        {
            var item = DivisionCbx.SelectedItem as Division;
            NameCbx.Items = Db.Employees.Where(el => el.DivisionId == item.Id);
        }
        catch (Exception exception)
        {
            Error();
        }
    }

    private void StartDp_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        FinishDp.DisplayDateStart = StartDp.SelectedDate;
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            Db.Visits.Add(VisitGrid.DataContext as Visit);
            Db.SaveChanges();
            (VisitorGrid.DataContext as Visitor).VisitId = (VisitGrid.DataContext as Visit).Id;
            Db.Visitors.Add(VisitorGrid.DataContext as Visitor);
            Db.SaveChanges();
            Navigationn.Content = new MainMenu();
        }
        catch (Exception exception)
        {
            Error();
        }
    }
}