
namespace ArenaFighter
{
    class Dice
    {
        private static Random r = new Random();

        public static int Roll()
        {
            return r.Next(1, 7);
        }
        public static int RollHealth()
        {
            return r.Next(1, 51);
        }

        internal static string RollName()
        {
            return "Bot X" + r.Next(1000, 10000);
        }

        internal static int RollStrength()
        {
            return r.Next(1, 21);
        }
    }
}