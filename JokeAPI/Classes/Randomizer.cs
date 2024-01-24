namespace JokeAPI.Classes
{
    public static class Randomizer
    {
        private static readonly Random randomizer = new Random();
        public static int RandomBetweenAndIncluding(int bottom, int top)
        {
            return randomizer.Next(bottom, top + 1);
        }
    }
}
