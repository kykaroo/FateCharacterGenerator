using FateCharacterGenerator.AL.Controller;
using FateCharacterGenerator.AL.Controller.CharacterSaver;

namespace FateCharacterGenerator.CMD;

internal static class Program
{
    private static string options = "";
    private static int userInput;
    private static readonly List<string> mainMenuOptions = new();
    private static readonly List<string> afterGenerationOptions = new();
    private static readonly IDataSaver manager = new TxtDataSaver();


    private static void Main()
    {
        InitializeMenu();
        MainMenu();
    }

    private static void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            var controller = new CharacterController();
            userInput = CharacterController.UserInputCheck(1, mainMenuOptions.Count, CreateOptionString(mainMenuOptions));
            switch (userInput)
            {
                case 1:
                    controller.Character = controller.GenerateCharacter(controller.Character);
                    Console.WriteLine(controller.Character.ToString());
                    userInput = CharacterController.UserInputCheck(1, afterGenerationOptions.Count, CreateOptionString(afterGenerationOptions));
                    switch (userInput)
                    {
                        case 1:
                            manager.Save(controller.Character);
                            continue;
                        case 2:
                            controller.GenerateCharacter(controller.Character);
                            break;
                        case 3:
                            continue;
                        case 4:
                            Quit();
                            break;
                    }

                    break;
                case 2:
                    Quit();
                    break;
            }

            break;
        }
    }

    private static void InitializeMenu()
    {
        mainMenuOptions.Add("1. Создать персонажа");
        mainMenuOptions.Add("2. Выйти");

        afterGenerationOptions.Add("1. Сохранить персонажа");
        afterGenerationOptions.Add("2. Сгенерировать еще одного");
        afterGenerationOptions.Add("3. В меню");
        afterGenerationOptions.Add("4. Выйти");
    }

    private static string CreateOptionString(List<string> optionsList)
    {
        options = "";
        foreach (string str in optionsList) options = options + str + "\n";

        return options.Trim();
    }

    private static void Quit()
    {
        Environment.Exit(0);
    }
}