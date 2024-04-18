using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TSD2491_OBLIG1_250074.Models
{
    public class MatchingGameModul
    {

        public int MatchesFound = 0;
        public string gameStatus { get; private set; }

        // legger til en List<User> for a lagre brukerinformasjon
        public List<User> Users { get; private set; } = new List<User>();

        public string CurrentUsername { get; private set; }

        public MatchingGameModul()
        {
            // initialiserer Users-listen i konstruktoren 
            Users = new List<User>();
            SetupGame();
        }

        static List<string> animalEmoji = new List<string>()
        {
            "🐶", "🐶", 
			"🐴", "🐴", 
			"🐮", "🐮", 
			"🦊", "🦊",  
			"😺", "😺", 
			"🦁", "🦁", 
			"🐯", "🐯", 
			"🐭", "🐭", 
		};

        static List<string> signEmoji = new List<string>()
        {
            "👈", "👈", 
			"✌️", "✌️",	
			"🖖", "🖖",  
			"🤞", "🤞",  
			"👎", "👎", 
			"🤌", "🤌", 
			"👍", "👍",  
			"🤝", "🤝", 
		};
 
        static List<string> randomEmoji = new List<string>()
        {
            "🎃", "🎃", 
			"❌", "❌", 
			"⚡", "⚡", 
			"🚀", "🚀",
			"🚁", "🚁",
			"📸", "📸", 
			"🧲", "🧲",  
			"✂️", "✂️",	 

		};

        static List<string> fruktEmoji = new List<string>()
        {
            "🍒", "🍒", 
            "🍑", "🍑",  
            "🍉", "🍉", 
            "🥝", "🥝", 
            "🍌", "🍌", 
            "🍎", "🍎", 
            "🥥", "🥥",  
            "🍇", "🍇", 
        };


        static Random random = new Random();
        public List<string> shuffledEmoji = pickRandomEmoji();
        static List<string> pickRandomEmoji()
        {
 
            int randomIndeks = random.Next(0, 4);

            switch (randomIndeks)
            {
                case 0:
                    return animalEmoji = animalEmoji.OrderBy(items => random.Next()).ToList();

                case 1:
                    return signEmoji = signEmoji.OrderBy(items => random.Next()).ToList();

                case 2:
                    return randomEmoji = randomEmoji.OrderBy(items => random.Next()).ToList();

                case 3:
                    return fruktEmoji = fruktEmoji.OrderBy(items => random.Next()).ToList();

                default:
                    throw new Exception("Invalig Index");
            }
        }

        // commit 4
        private void SetupGame()
        {
            Random random = new Random();
            shuffledEmoji = pickRandomEmoji();

            MatchesFound = 0;
        }

        string lastAnimalFound = string.Empty;
        string lastDescription = string.Empty;

        public void ButtonClick(string animal, string AnimalDescription)
        {

            if (CurrentUsername == null)
                return;

            if (MatchesFound == 0)
            {
                gameStatus = "Game Running";
            }

            if (lastAnimalFound == string.Empty)
            {
                lastAnimalFound = animal;
                lastDescription = AnimalDescription;
            }


            else if ((lastAnimalFound == animal) && (AnimalDescription != lastDescription))
            {
                lastAnimalFound = string.Empty;

                shuffledEmoji = shuffledEmoji
                    .Select(a => a.Replace(animal, string.Empty))
                    .ToList();


                MatchesFound++;
                if (MatchesFound == 8)
                {
                    gameStatus = "Game Complete";
                    SetupGame();

                    if (CurrentUsername != null)
                    {
                        UpdateGamesPlayed(CurrentUsername);
                    }

                    SetupGame();
                }
            }

            else
            {
                // resetting lastAnimalFound
                lastAnimalFound = string.Empty;
            }
        }

        public void RegisterUser(string username)
        {
            if (!Users.Any(u => u.Username == username))
            {
                Users.Add(new User { Username = username, GamesPlayed = 0 });
            }

            CurrentUsername = username;

        }

        public void UpdateGamesPlayed(string username)
        {
            var user = Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.GamesPlayed++;
            }
        }
    }

    public class User
    {
        public string Username { get; set; }
        public int GamesPlayed { get; set; }
    }
}