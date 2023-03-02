namespace FateCharacterGenerator.AL.Model;

public struct Character
{
    public string Name { get; set; }

    public string LastName { get; set; }

    public string Race { get; set; }

    public string Gender { get; set; }

    public string BackGround { get; set; }

    public string Trait { get; set; }

    public string Ideal { get; set; }

    public string Devotion { get; set; }

    public string Weakness { get; set; }

    public override string ToString()
    {
        return $"Имя: {Name} {LastName}\n" +
               $"Раса: {Race}\n" +
               $"Пол: {Gender}\n" +
               $"Предистория: {BackGround}\n" +
               $"Черта характера: {Trait}\n" +
               $"Привязанность: {Devotion}\n" +
               $"Идеал: {Ideal}\n" +
               $"Слабость: {Weakness}\n" +
               "___________________________________________________";
    }
}