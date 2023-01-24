using FateCharacterGenerator;

var characterGenerator = new CharacterGenerator();
var character = new Character();
var options = "";
var userInput = 0;
string savePath = Path.Combine(Directory.GetCurrentDirectory(), "Save");
int savesCount = new DirectoryInfo(savePath).GetFiles().Length;


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
    DisplayCharacter();
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
    string filePath = Path.Combine(savePath, $"{savesCount + 1}. " + $"{character.Name} {character.LastName}" + ".txt");
    var file = new FileInfo(filePath);

    using (var streamWriter = file.CreateText())
    {
        streamWriter.WriteLine("Имя: " + character.Name + " " + character.LastName);
        streamWriter.WriteLine("Раса: " + character.Race);
        streamWriter.WriteLine("Пол: " + character.Gender);
        streamWriter.WriteLine("Предистория: " + character.BackGround);
        streamWriter.WriteLine("Черта характера: " + character.Trait);
        streamWriter.WriteLine("Привязанность: " + character.Devotion);
        streamWriter.WriteLine("Идеал: " + character.Ideal);
        streamWriter.WriteLine("Слабость: " + character.Weakness);
    }

    savesCount++;
    DisplayCharacter();
    Console.WriteLine("Сохранение успешно\nНажмите Enter для продолжения");
    Console.ReadLine();
}

void Quit()
{
    Environment.Exit(0);
}

void DisplayCharacter()
{
    Console.WriteLine("Имя: " + character.Name + " " + character.LastName);
    Console.WriteLine("Раса: " + character.Race);
    Console.WriteLine("Пол: " + character.Gender);
    Console.WriteLine("Предистория: " + character.BackGround);
    Console.WriteLine("Черта характера: " + character.Trait);
    Console.WriteLine("Привязанность: " + character.Devotion);
    Console.WriteLine("Идеал: " + character.Ideal);
    Console.WriteLine("Слабость: " + character.Weakness);
    Console.WriteLine("___________________________________________________");
}