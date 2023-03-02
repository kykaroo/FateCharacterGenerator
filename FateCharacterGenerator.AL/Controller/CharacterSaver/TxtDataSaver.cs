using FateCharacterGenerator.AL.Model;

namespace FateCharacterGenerator.AL.Controller.CharacterSaver;

public class TxtDataSaver : IDataSaver
{
    /// <summary>
    /// Сохранение персонажа в отдельный текстовый фаил.
    /// </summary>
    /// <param name="character"> Персонаж. </param>
    /// <param name="savePath"> Полный путь до файла сохранения. </param>
    public void Save(Character character)
    {
        string SavePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Save");
        var SaveCounter = 1;
        
        if (Directory.Exists(SavePathDirectory) == false)
            Directory.CreateDirectory(SavePathDirectory);
        else
            SaveCounter = new DirectoryInfo(SavePathDirectory).GetFiles().Length + 1;

        var file = new FileInfo($"{SavePathDirectory}\\{SaveCounter}. {character.Name} {character.LastName}.txt");

        using var streamWriter = file.CreateText();
        streamWriter.WriteLine(character.ToString());
    }

    /// <summary>
    /// Загрузка персонажа и вывод его на консоль.
    /// </summary>
    /// <param name="filePath"> Полный путь до файла сохранения. </param>
    public void Load(string filePath)
    {
        var sr = new StreamReader(filePath);
        Console.WriteLine(sr.ReadToEnd());
    }
}