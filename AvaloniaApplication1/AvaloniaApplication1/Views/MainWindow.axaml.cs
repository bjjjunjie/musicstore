﻿using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaApplication1.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
       // DataContext = new MainWindowViewModel();
        this.WhenActivated(action =>
               action(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
    }
    private async Task DoShowDialogAsync(InteractionContext<MusicStoreViewModel,AlbumViewModel?> interaction)
    {
        var dialog = new MusicStoreWindow();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<AlbumViewModel?>(this);
        interaction.SetOutput(result);
    }
}
