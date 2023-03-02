using FateCharacterGenerator.AL.Model;

namespace FateCharacterGenerator.AL.Controller.CharacterSaver;

public interface IDataSaver
{
    void Save(Character character);

    void Load(string filePath);
}