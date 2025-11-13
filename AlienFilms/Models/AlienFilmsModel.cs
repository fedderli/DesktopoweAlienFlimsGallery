namespace AlienFilms.Models;

public class AlienFilmsModel
{
    public string OriginalTitle{ get; set; } = "";
    public string PolishTitle{ get; set; } = "";
    public int ReleseYear { get; set; } = 0;
    public string Director { get; set; } = "";
    public string Scenario { get; set; } = "";
    public string Genre { get; set; } = "";
    public string MovieDuration { get; set; } = "";
    public float Rating { get; set; } = 0;
    public string[] MainCharacters { get; set; } = [];
    public string Ship {get; set;} = "";
    public string PlotDescription {get; set;} = "";
    public string FunFact {get; set;} = "";
}