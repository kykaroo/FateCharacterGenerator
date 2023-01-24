using FateCharacterGenerator;

var characterGenerator = new CharacterGenerator();
var character = new Character();
var options = "";
var userInput = 0;

var mainMenuOptions = new List<string>();
mainMenuOptions.Add("1. Создать персонажа");
mainMenuOptions.Add("2. Выйти");

var afterGenerationOptions = new List<string>();
afterGenerationOptions.Add("1. Сохранить персонажа");
afterGenerationOptions.Add("2. Сгенерировать еще одного");
afterGenerationOptions.Add("3. В меню");
afterGenerationOptions.Add("4. Выйти");

MainMenu();

void MainMenu()
{
    Console.Clear();
    userInput = characterGenerator.UserInputCheck(1, mainMenuOptions.Count, CreateOptionString(mainMenuOptions));
    switch (userInput)
    {
        case 1:
            GenerateCharacter();
            break;
        case 2:
            Quit();
            break;
    }
}

void GenerateCharacter()
{
    character = characterGenerator.CreateCharacter();
    Console.Clear();
    Console.WriteLine("Имя:" + character.Name + " " + character.LastName);
    Console.WriteLine("Раса:" + character.Race);
    Console.WriteLine("Пол:" + character.Gender);
    Console.WriteLine("Предистория:" + character.BackGround);
    Console.WriteLine("Черта характера:" + character.Trait);
    Console.WriteLine("Привязанность:" + character.Devotion);
    Console.WriteLine("Идеал:" + character.Ideal);
    Console.WriteLine("Слабость:" + character.Weakness);
    Console.WriteLine("\n___________________________________________________\n");
    userInput = characterGenerator.UserInputCheck(1, afterGenerationOptions.Count,
        CreateOptionString(afterGenerationOptions));
    switch (userInput)
    {
        case 1:
            SaveCharacter();
            MainMenu();
            break;
        case 2:
            GenerateCharacter();
            break;
        case 3:
            MainMenu();
            break;
        case 4:
            Quit();
            break;
    }
}

string CreateOptionString(List<string> optionsList)
{
    options = "";
    foreach (string str in optionsList) options = options + str + "\n";

    return options.Trim();
}

void SaveCharacter()
{
    //TODO Сделать возможность сохранения результата в директорию
}

void Quit()
{
    Environment.Exit(0);
}