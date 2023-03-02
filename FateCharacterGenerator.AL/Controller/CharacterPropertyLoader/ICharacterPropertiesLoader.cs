namespace FateCharacterGenerator.AL.Controller.CharacterPropertyLoader;

public interface ICharacterPropertiesLoader
{
    List<string> LoadFile(string filePath);

    List<string> LoadDirectory(List<string> directoryPath);
}