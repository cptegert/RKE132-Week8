string folderPath = @"C:\Users\Egert\source\repos\Week8";
string heroesFile = "heroes.txt";
string villainsFile = "villains.txt";
    
string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroesFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainsFile));

string[] weapon = { "magic wand", "plastic fork", " banana", "wooden sword", "Lego brick" };
string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapon);
string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
int villainStrikeStrength = villainHP;

Console.WriteLine($"Today {hero} with {heroWeapon} <{heroHP} HP> saves the day!");
Console.WriteLine($"Today {villain} with {villainWeapon} <{villainHP} HP> tries to take over the world!");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}

if(heroHP > 0)
{
    Console.WriteLine($"{hero} won!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"{villain} won!");
}
else
{
    Console.WriteLine("Draw!");
}
static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if(characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}
static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed!");

    }
    else if(strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} got hit! {strike}!");
    }

    return strike;
}