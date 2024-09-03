using ArenaFighter;

namespace ArenaFighter
{
    class Character
    {
        public string Name { get; internal set; }
        public int Strength { get; internal set; }
        public int Health { get; internal set; }
        public CharacterType CharacterType { get; internal set; }

        public Character(CharacterType type) : this(type, Dice.RollName())
        { }
        public Character(CharacterType characterType, string name)
        {
            CharacterType = characterType;
            Name = name;
            Strength = Dice.RollStrength();
            Health = Dice.RollHealth();
        }

        public void ShowInfo()
        {
            if (CharacterType == CharacterType.Player)
                Console.WriteLine($"\nPlayer name: {Name}");
            else
                Console.WriteLine($"\nOpponent name: {Name}");

            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Health: {Health}");
        }
    }
    enum CharacterType { Player, Opponent }
}