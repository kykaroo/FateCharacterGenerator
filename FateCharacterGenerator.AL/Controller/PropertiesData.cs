using FateCharacterGenerator.AL.Controller.CharacterPropertyLoader;

namespace FateCharacterGenerator.AL.Controller;

public class PropertiesData
{
    public PropertiesData()
    {
        GenderList = PropertyDirectory("Gender");
        RaceList = PropertyDirectory("Race Info");
        BackgroundList = PropertyDirectory("Background");
    }

    public List<string> GenderList { get; }

    public List<string> RaceList { get; }

    public List<string> BackgroundList { get; }
    
    private static List<string> PropertyDirectory(string property)
    {
        return new TxtCharacterPropertiesLoader().LoadDirectory(Directory
            .GetDirectories(Path.Combine(Directory.GetCurrentDirectory(), "CharacterTemplates", property)).ToList());
    }
    
    public static List<string> PropertyList(string directory, string directory2, string property)
    {
        return new TxtCharacterPropertiesLoader().LoadFile(Path.Combine(Directory.GetCurrentDirectory(),
            "CharacterTemplates", directory, directory2, property + ".txt")).ToList();
    }
}