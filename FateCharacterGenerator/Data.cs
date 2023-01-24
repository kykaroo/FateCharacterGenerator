using FateCharacterGenerator;

public class MainCharacterInfo
{
    public MainCharacterInfo()
    {
        List<string> racePath =  Directory
            .GetDirectories(Path.Combine(Directory.GetCurrentDirectory(), "CharacterTemplates", "Race Info"), "*",
                SearchOption.TopDirectoryOnly).ToList();
        for (var index = 0; index < racePath.Count; index++)
        {
            RaceList.Add(new DirectoryInfo(racePath[index]).Name);
        }

        List<string> genderPath = Directory
            .GetDirectories(Path.Combine(Directory.GetCurrentDirectory(), "CharacterTemplates", "Gender"), "*",
                SearchOption.TopDirectoryOnly).ToList();
        for (var index = 0; index < genderPath.Count; index++)
        {
            GenderList.Add(new DirectoryInfo(genderPath[index]).Name);
        }
        
        List<string> backgroundPath = Directory
            .GetDirectories(Path.Combine(Directory.GetCurrentDirectory(), "CharacterTemplates", "Background"), "*",
                SearchOption.TopDirectoryOnly).ToList();
        for (var index = 0; index < backgroundPath.Count; index++)
        {
            BackgroundList.Add(new DirectoryInfo(backgroundPath[index]).Name);
        }
    }

    public List<string> RaceList = new();
    public List<string> GenderList = new();
    public List<string> BackgroundList = new();
}

public class Names
{
    public Names(Character character)
    {
        var rnd = new Random();
        string racePath = Path.Combine(Directory.GetCurrentDirectory(), "CharacterTemplates", "Race Info",
            character.Race);
        if (character.Gender == "Женский")
            Name = File.ReadAllLines(Path.Combine(racePath, "FirstNameW.txt"))[
                rnd.Next(File.ReadAllLines(Path.Combine(racePath, "FirstNameW.txt")).Length)];
        else
            Name = File.ReadAllLines(Path.Combine(racePath, "FirstNameM.txt"))[
                rnd.Next(File.ReadAllLines(Path.Combine(racePath, "FirstNameM.txt")).Length)];

        LastName =
            File.ReadAllLines(Path.Combine(racePath, "LastName.txt"))[
                rnd.Next(File.ReadAllLines(Path.Combine(racePath, "LastName.txt")).Length)];
    }

    public string Name { get; }

    public string LastName { get; }
}

public class DeepCharacterInfo
{
    public DeepCharacterInfo(Character character)
    {
        var rnd = new Random();
        string backgroundPath = Path.Combine(Directory.GetCurrentDirectory(), "CharacterTemplates", "Background",
            character.BackGround);

        Trait = File.ReadAllLines(Path.Combine(backgroundPath, "Черты характера.txt"))[
            rnd.Next(File.ReadAllLines(Path.Combine(backgroundPath, "Черты характера.txt")).Length)];
        Devotion = File.ReadAllLines(Path.Combine(backgroundPath, "Привязанность.txt"))[
            rnd.Next(File.ReadAllLines(Path.Combine(backgroundPath, "Привязанность.txt")).Length)];
        Ideal = File.ReadAllLines(Path.Combine(backgroundPath, "Идеал.txt"))[
            rnd.Next(File.ReadAllLines(Path.Combine(backgroundPath, "Идеал.txt")).Length)];
        Weakness = File.ReadAllLines(Path.Combine(backgroundPath, "Слабость.txt"))[
            rnd.Next(File.ReadAllLines(Path.Combine(backgroundPath, "Слабость.txt")).Length)];
    }

    public string Trait { get; }
    public string Devotion { get; }
    public string Ideal { get; }
    public string Weakness { get; }
}