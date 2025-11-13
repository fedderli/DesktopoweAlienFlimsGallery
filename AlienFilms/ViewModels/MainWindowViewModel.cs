using System.Collections.ObjectModel;
using System.IO;
using AlienFilms.Models;

namespace AlienFilms.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<AlienFilmsModel> AlienFilms { get; } = [];

    public MainWindowViewModel()
    {
        var lines = File.ReadAllLines("AliendFilmsData.txt");
        for (int i = 0; i < lines.Length; i += 13)
        {
            AlienFilms.Add(new AlienFilmsModel()
            {
                OriginalTitle = lines[i],
                PolishTitle = lines[i + 1],
                ReleseYear = int.Parse(lines[i + 2]),
                Director =  lines[i + 3],
                Scenario =  lines[i + 4],
                Genre =   lines[i + 5],
                MovieDuration =  lines[i + 6],
                Rating = float.Parse( lines[i + 7]),
                
                
            });
        }
    }
}