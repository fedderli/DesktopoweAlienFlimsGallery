using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using AlienFilms.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;


namespace AlienFilms.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<AlienFilmsModel> AlienFilms { get; } = [];

    
    private AlienFilmsModel _selectedAlienFilm = null;

    public AlienFilmsModel SelectedAlienFilm
    {
        get => _selectedAlienFilm;
        set => this.RaiseAndSetIfChanged(ref _selectedAlienFilm, value);
    }
    
    
    [Reactive] public string NewOrginalTitle { get; set; } = string.Empty;
    [Reactive] public string NewPolishTitle { get; set; } = string.Empty;
    [Reactive] public string NewReleseYear { get; set; } = string.Empty;
    [Reactive] public string NewDirector { get; set; } = string.Empty;
    [Reactive] public string NewScenario { get; set; } = string.Empty;
    [Reactive] public string NewGenre { get; set; } = string.Empty;
    [Reactive] public string NewMovieDuration { get; set; } = string.Empty;
    [Reactive] public string NewRating { get; set; } = string.Empty;
    [Reactive] public string NewMainCharacters { get; set; } = string.Empty;
    [Reactive] public string NewShip { get; set; } = string.Empty;
    [Reactive] public string NewPlotDescription { get; set; } = string.Empty;
    [Reactive] public string NewFunFact { get; set; } = string.Empty;
    
    
    public ReactiveCommand<Unit, Unit> AddFilmCommand { get; }
    public ReactiveCommand<AlienFilmsModel?, Unit> RemoveFilmCommand { get; }
    
    
    
    
    public MainWindowViewModel()
    {
        var lines = File.ReadAllLines("AlienFilmsData.txt");
        for (int i = 0; i < lines.Length; i += 13)
        {
            AlienFilms.Add(new AlienFilmsModel()
            {
                OriginalTitle = lines[i],
                PolishTitle = lines[i + 1],
                ReleseYear = int.Parse(lines[i + 2]),
                Director = lines[i + 3],
                Scenario = lines[i + 4],
                Genre = lines[i + 5],
                MovieDuration = lines[i + 6],
                Rating = float.Parse(lines[i + 7]),
                MainCharacters = lines[i + 8],
                Ship =  lines[i + 9],
                PlotDescription = lines[i + 10],
                FunFact = lines[i + 11],
            });
        }

        AddFilmCommand = ReactiveCommand.Create(() =>
        {
            if (string.IsNullOrEmpty(NewOrginalTitle)) return;
            AlienFilms.Add(new AlienFilmsModel()
            {
                OriginalTitle = NewOrginalTitle,
                PolishTitle = NewPolishTitle,
                ReleseYear = int.Parse(NewReleseYear.ToString()),
                Director = NewDirector,
                Scenario = NewScenario,
                Genre = NewGenre,
                MovieDuration = NewMovieDuration.ToString() + " min",
                Rating = float.Parse(NewRating.ToString()),
                MainCharacters = NewMainCharacters,
                Ship =  NewShip,
                PlotDescription = NewPlotDescription,
                FunFact = NewFunFact
                
                
            });
        });
        
        RemoveFilmCommand = ReactiveCommand.Create<AlienFilmsModel?>( item =>
        {
            if (item != null && AlienFilms.Contains(item))
            {
                AlienFilms.Remove(item);
            }
        });

    }
}