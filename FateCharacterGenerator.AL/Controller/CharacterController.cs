using FateCharacterGenerator.AL.Model;

namespace FateCharacterGenerator.AL.Controller;

public class CharacterController
{
    public CharacterController()
    {
        Data = new PropertiesData();
        Character = new Character();
        RaceList = Data.RaceList;
        GenderList = Data.GenderList;
        BackgroundList = Data.BackgroundList;
        Rnd = new Random();
    }

    /// <summary>
    /// Персонаж.
    /// </summary>
    public Character Character { get; set; }
    private Random Rnd { get; }

    /// <summary>
    /// Лист со всеми доступными расами.
    /// </summary>
    private List<string> RaceList { get; }

    /// <summary>
    /// Лист со всеми доступными гендерами.
    /// </summary>
    private List<string> GenderList { get; }

    /// <summary>
    /// Лист со всеми доступными предисториями.
    /// </summary>
    private List<string> BackgroundList { get; }
    
    private PropertiesData Data { get; }

/// <summary>
/// Генератор случайных персонажей.
/// </summary>
/// <param name="character"> Персонаж. </param>
/// <returns></returns>
    private Character GenerateRandomCharacter(Character character)
    {
        character.Race = RaceList[Rnd.Next(RaceList.Count)];

        character.Gender = GenderList[Rnd.Next(GenderList.Count)];

        character.BackGround = BackgroundList[Rnd.Next(BackgroundList.Count)];

        List<string> characterNameList;
        if (character.Gender == "Мужской")
            characterNameList = PropertiesData.PropertyList("Race Info", character.Race, "FirstNameM");
        else
            characterNameList = PropertiesData.PropertyList("Race Info", character.Race, "FirstNameW");
        character.Name = characterNameList[Rnd.Next(characterNameList.Count)];

        var characterLastNameList = PropertiesData.PropertyList("Race Info", character.Race, "LastName");
        character.LastName = characterLastNameList[Rnd.Next(characterLastNameList.Count)];

        var characterTraitList = PropertiesData.PropertyList("Background", character.BackGround, "Черты характера");
        character.Trait = characterTraitList[Rnd.Next(characterTraitList.Count)];

        var characterDevotionList = PropertiesData.PropertyList("Background", character.BackGround, "Привязанность");
        character.Devotion = characterDevotionList[Rnd.Next(characterDevotionList.Count)];

        var characterIdealList = PropertiesData.PropertyList("Background", character.BackGround, "Идеал");
        character.Ideal = characterIdealList[Rnd.Next(characterIdealList.Count)];

        var characterWeaknessList = PropertiesData.PropertyList("Background", character.BackGround, "Слабость");
        character.Weakness = characterWeaknessList[Rnd.Next(characterWeaknessList.Count)];

        return character;
    }

/// <summary>
/// Выбор расы персонажа
/// </summary>
/// <param name="character"> Персонаж. </param>
/// <param name="message"> Сообщение для вывода на консоль для пользователя. </param>
/// <returns></returns>
    private string ChooseRace(Character character, string message)
    {
        var userInput = 0;

        message += "\n" + "0. Случайная";
        for (var index = 0; index < Data.RaceList.Count; index++)
            message = message + "\n" + $"{index + 1}" + ". " + Data.RaceList[index];
        userInput = UserInputCheck(0, Data.RaceList.Count, message);
        character.Race = userInput == 0
            ? Data.RaceList[Rnd.Next(0, Data.RaceList.Count)]
            : Data.RaceList[userInput - 1];

        return character.Race;
    }

/// <summary>
/// Выбор пола персонажа
/// </summary>
/// <param name="character"> Персонаж. </param>
/// <param name="message"> Сообщение для вывода на консоль для пользователя. </param>
/// <returns></returns>
    private string ChooseGender(Character character, string message)
    {
        var userInput = 0;

        message += "\n0. Случайный";
        for (var index = 0; index < Data.GenderList.Count; index++)
            message = message + "\n" + $"{index + 1}" + ". " + Data.GenderList[index];
        userInput = UserInputCheck(0, Data.GenderList.Count, message);
        character.Gender = userInput == 0
            ? Data.GenderList[Rnd.Next(0, Data.GenderList.Count)]
            : Data.GenderList[userInput - 1];

        return character.Gender;
    }

/// <summary>
/// Выбор предистории персонажа
/// </summary>
/// <param name="character"> Персонаж. </param>
/// <param name="message"> Сообщение для вывода на консоль для пользователя. </param>
/// <returns></returns>
    private string ChooseBackGround(Character character, string message)
    {
        var userInput = 0;

        message += "\n0. Случайная";
        for (var index = 0; index < Data.BackgroundList.Count; index++)
            message = message + "\n" + $"{index + 1}" + ". " + Data.BackgroundList[index];
        userInput = UserInputCheck(0, Data.BackgroundList.Count, message);
        character.BackGround = userInput == 0
            ? Data.BackgroundList[Rnd.Next(0, Data.BackgroundList.Count)]
            : Data.BackgroundList[userInput - 1];

        return character.BackGround;
    }

/// <summary>
/// Проверка консольного ввода пользователя
/// </summary>
/// <param name="min"> Минимальное допустимое значение ввода пользователя </param>
/// <param name="max"> Максимальное допустимое значение ввода пользователя </param>
/// <param name="message"> Сообщение для вывода на консоль для пользователя. </param>
/// <returns></returns>
    public static int UserInputCheck(int min, int max, string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            var userInput = 0;
            try
            {
                userInput = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine(@"Неверное значение");
                continue;
            }

            if (userInput >= min && userInput <= max)
            {
                Console.Clear();
                return userInput;
            }

            Console.Clear();
            Console.WriteLine(@"Неверное значение");
        }
    }

/// <summary>
/// Генератор нового персонажа
/// </summary>
/// <param name="character"> Персонаж. </param>
/// <returns></returns>
    public Character GenerateCharacter(Character character)
    {
        if (UserInputCheck(1, 2, "1. Создать персонажа вручную\n2. Cгенерировать случайно?") == 2)
        {
            character = GenerateRandomCharacter(character);
            return character;
        }

        Console.Clear();
        character.Race = ChooseRace(character, "Выбери расу:");
        Console.Clear();
        character.Gender = ChooseGender(character, "Выбери пол персонажа:");
        Console.Clear();
        character.BackGround = ChooseBackGround(character, "Выбери предисторию персонажа:");
        Console.Clear();

        var characterTraitList = PropertiesData.PropertyList("Background", character.BackGround, "Черты характера");
        character.Trait = characterTraitList[Rnd.Next(characterTraitList.Count)];

        var characterDevotionList = PropertiesData.PropertyList("Background", character.BackGround, "Привязанность");
        character.Devotion = characterDevotionList[Rnd.Next(characterDevotionList.Count)];

        var characterIdealList = PropertiesData.PropertyList("Background", character.BackGround, "Идеал");
        character.Ideal = characterIdealList[Rnd.Next(characterIdealList.Count)];

        var characterWeaknessList = PropertiesData.PropertyList("Background", character.BackGround, "Слабость");
        character.Weakness = characterWeaknessList[Rnd.Next(characterWeaknessList.Count)];

        return character;
    }
}