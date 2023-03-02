namespace FateCharacterGenerator.AL.Controller.CharacterPropertyLoader;

public class TxtCharacterPropertiesLoader : ICharacterPropertiesLoader
{
    /// <summary>
    ///     Получение информации из ".txt" файла.
    /// </summary>
    /// <param name="filePath"> Полнуй путь до ".txt" файла, из которого будет построчно составлен список.  </param>
    /// <returns> Список всех строк, которые были в файле с путем "filePath"</returns>
    public List<string> LoadFile(string filePath)
    {
        var sr = new StreamReader(filePath);

        var propertyList = new List<string>();

        while (sr.Peek() >= 0) propertyList.Add(sr.ReadLine() ?? throw new ArgumentNullException("Не найден фаил или фаил является пустым.", nameof(filePath)));

        return propertyList;
    }

    /// <summary>
    ///     Загрузка названий всех папок, находящихся в папке с путем "directoryPath".
    /// </summary>
    /// <param name="directoryPath"> Полный путь до папки, из которой будут выгружены названия находящихся в ней папок.</param>
    /// <returns> Список названий всех папок, находящихся в папке с путем "directoryPath". </returns>
    public List<string> LoadDirectory(List<string> directoryPath)
    {
        return directoryPath.Select(t => new DirectoryInfo(t).Name).ToList();
    }
}