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

        public MatchingGameModul()
        {
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

        static List<string> coolEmoji = new List<string>()
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

        static List<string> fruitEmoji = new List<string>()
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
                    return coolEmoji = coolEmoji.OrderBy(items => random.Next()).ToList();

                case 3:
                    return fruitEmoji = fruitEmoji.OrderBy(items => random.Next()).ToList();

                default:
                    throw new Exception("Invalig Index");
            }
        }

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

                }
            }

            else
            {
                lastAnimalFound = string.Empty;
            }
        }
    }
}