    using FateCharacterGenerator;

    CharacterGenerator characterGenerator = new CharacterGenerator();
    Character character = new Character();
    character = characterGenerator.CreateCharacter();
    Console.WriteLine("Имя:" + character.Name + " " + character.LastName);
    Console.WriteLine("Раса:" + character.Race);
    Console.WriteLine("Пол:" + character.Gender);
    Console.WriteLine("Предистория:" + character.BackGround);
    Console.WriteLine("Черта характера:" + character.Trait);
    Console.WriteLine("Привязанность:" + character.Devotion);
    Console.WriteLine("Идеал:" + character.Ideal);
    Console.WriteLine("Слабость:" + character.Weakness);
    Console.ReadLine();
    
    //TODO Сделать возможность генерировать другого персонажа
    //TODO Сделать возможность сохранения результата в директорию