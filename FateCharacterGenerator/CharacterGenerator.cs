using FateCharacterGenerator;

internal class CharacterGenerator
{
    private readonly MainCharacterInfo mainCharacterInfo = new();
    private Character Character;
    private readonly Random rnd = new();
    private int userInput;
    private int userInputMax;
    private int userInputMin;

    public Character CreateCharacter()
    {
        userInputMax = 2;
        userInputMin = 1;
        if (UserInputCheck(userInputMin, userInputMax, "1. Создать персонажа вручную\n2. Cгенерировать случайно?") == 2)
            return RandomGenerator();

        string message = "Выбери расу: \n" + "0. Случайная";
        for (var index = 0; index < mainCharacterInfo.RaceList.Count; index++)
            message = message + "\n" + $"{index + 1}" + ". " + mainCharacterInfo.RaceList[index];
        userInput = UserInputCheck(0, mainCharacterInfo.RaceList.Count, message);
        Character.Race = userInput == 0
            ? mainCharacterInfo.RaceList[rnd.Next(0, mainCharacterInfo.RaceList.Count)]
            : mainCharacterInfo.RaceList[userInput - 1];

        message = "Выбери пол персонажа:\n0. Случайный";
        for (var index = 0; index < mainCharacterInfo.GenderList.Count; index++)
            message = message + "\n" + $"{index + 1}" + ". " + mainCharacterInfo.GenderList[index];
        userInput = UserInputCheck(0, mainCharacterInfo.GenderList.Count, message);
        Character.Gender = userInput == 0
            ? mainCharacterInfo.GenderList[rnd.Next(0, mainCharacterInfo.GenderList.Count)]
            : mainCharacterInfo.GenderList[userInput - 1];

        message = "Выбери предисторию персонажа:\n0. Случайная";
        for (var index = 0; index < mainCharacterInfo.BackgroundList.Count; index++)
            message = message + "\n" + $"{index + 1}" + ". " + mainCharacterInfo.BackgroundList[index];
        userInput = UserInputCheck(0, mainCharacterInfo.BackgroundList.Count, message);
        Character.BackGround = userInput == 0
            ? mainCharacterInfo.BackgroundList[rnd.Next(0, mainCharacterInfo.BackgroundList.Count)]
            : mainCharacterInfo.BackgroundList[userInput - 1];
        //TODO Сделать возможность выбора нескольких предисторий

        var deepCharacterInfo = new DeepCharacterInfo(Character);
        var characterName = new Names(Character);
        Character.Name = characterName.Name;
        Character.LastName = characterName.LastName;
        Character.Trait = deepCharacterInfo.Trait;
        Character.Devotion = deepCharacterInfo.Devotion;
        Character.Ideal = deepCharacterInfo.Ideal;
        Character.Weakness = deepCharacterInfo.Weakness;
        return Character;
    }

    private int UserInputCheck(int min, int max, string message)
    {
        while (true)
        {
            Console.WriteLine(message);
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

    private Character RandomGenerator()
    {
        var character = new Character();
        character.Race = new DirectoryInfo(mainCharacterInfo.RaceList[rnd.Next(mainCharacterInfo.RaceList.Count)])
            .Name;
        character.Gender =
            new DirectoryInfo(mainCharacterInfo.GenderList[rnd.Next(1, mainCharacterInfo.GenderList.Count)]).Name;
        character.BackGround =
            new DirectoryInfo(mainCharacterInfo.BackgroundList[rnd.Next(1, mainCharacterInfo.BackgroundList.Count)])
                .Name;
        var deepCharacterInfo = new DeepCharacterInfo(character);
        var characterName = new Names(character);
        character.Name = characterName.Name;
        character.LastName = characterName.LastName;
        character.Trait = deepCharacterInfo.Trait;
        character.Devotion = deepCharacterInfo.Devotion;
        character.Ideal = deepCharacterInfo.Ideal;
        character.Weakness = deepCharacterInfo.Weakness;
        return character;
    }

    void ShowResult(Character character)
    {
        //TODO Сделать вывод на консоль персонажа по мере выборов
    }
}