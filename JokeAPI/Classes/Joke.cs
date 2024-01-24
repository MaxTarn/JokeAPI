namespace JokeAPI.Classes
{
    public class Joke
    {
        public int Id { get; set; }
        public string? JokeBody { get; set; }
        public bool IsDadJoke { get; set; }










        public static bool DadJokeExists(int DadJokeId)
        {
            return DadJokes.Any(joke => joke.Id == DadJokeId);
        }
        public static bool MomJokeExists(int MomJokeId)
        {
            return MomJokes.Any(joke => joke.Id == MomJokeId);
        }

        public static int GetNewDadJokeId()
        {
            return DadJokes.Max(joke => joke.Id) + 1;
        }

        public static int GetNewMomJokeId()
        {
            return MomJokes.Max(joke => joke.Id) + 1;
        }

        public static bool UpdateExistingDadJoke(int JokeId, string NewJoke)
        {
            if (!DadJokeExists(JokeId)) return false;
            int JokeIndex = DadJokes.FindIndex(Joke => Joke.Id == JokeId);
            if (JokeIndex == -1) return false;

            DadJokes[JokeIndex].JokeBody = NewJoke;
            return true;

        }
        public static bool UpdateExistingMomJoke(int JokeId, string NewJoke)
        {
            if (!MomJokeExists(JokeId)) return false;
            int JokeIndex = MomJokes.FindIndex(Joke => Joke.Id == JokeId);
            if (JokeIndex == -1) return false;

            MomJokes[JokeIndex].JokeBody = NewJoke;
            return true;

        }
        public static bool AddNewDadJoke(Joke NewJoke)
        {
            if (NewJoke == null) return false;
            if (NewJoke.Id != GetNewDadJokeId()) NewJoke.Id = GetNewDadJokeId();
            if (NewJoke.JokeBody == null) return false;

            DadJokes.Add(NewJoke);
            return true;
        }

        public static bool AddNewMomJoke(Joke NewJoke)
        {
            if (NewJoke == null) return false;
            if (NewJoke.Id != GetNewMomJokeId()) NewJoke.Id = GetNewMomJokeId();
            if (NewJoke.JokeBody == null) return false;

            MomJokes.Add(NewJoke);
            return true;
        }

        public static bool DeleteDadJoke(int JokeId)
        {
            if (!DadJokeExists(JokeId)) return false;
            Joke JokeToDelete = DadJokes.First(joke => joke.Id == JokeId);
            DadJokes.Remove(JokeToDelete);
            return true;

        }

        public static bool DeleteMomJoke(int JokeId)
        {
            if (!MomJokeExists(JokeId)) return false;
            Joke JokeToDelete = MomJokes.First(joke => joke.Id == JokeId);
            MomJokes.Remove(JokeToDelete);
            return true;

        }
















        public static List<Joke> DadJokes { get; set; } = new List<Joke>()
        {
            new Joke{Id = 1, JokeBody = "\"What do you call a factory that makes okay products?\" \"A satisfactory.\"", IsDadJoke = true},
            new Joke{Id = 2, JokeBody = "What’s brown and sticky? A stick.", IsDadJoke = true},
            new Joke{Id = 3, JokeBody = "Two guys walked into a bar. The third guy ducked", IsDadJoke = true},
            new Joke{Id = 4, JokeBody = "What do you call a pudgy psychic? A four-chin teller.", IsDadJoke = true},
            new Joke{Id = 5, JokeBody = "What did the police officer say to his belly-button? You’re under a vest.", IsDadJoke = true}


        };
        public static List<Joke> MomJokes { get; set; } = new List<Joke>()
        {
            new Joke{Id = 1, JokeBody="momjoke1", IsDadJoke = false},
            new Joke{Id = 2, JokeBody="momjoke2", IsDadJoke = false},
            new Joke{Id = 3, JokeBody="momjoke3", IsDadJoke = false},
            new Joke{Id = 4, JokeBody="momjoke4", IsDadJoke = false},
            new Joke{Id = 5, JokeBody="momjoke5", IsDadJoke = false}
        };
    }
}
