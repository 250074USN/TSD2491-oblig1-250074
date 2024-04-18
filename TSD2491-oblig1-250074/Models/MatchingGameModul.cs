using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TSD2491_OBLIG1_250074.Models
{
    public class MatchingGameModul
    {

        public int MatchesFound = 0;

        public MatchingGameModul()
        {
            SetupGame();
        }

        static List<string> animalEmoji = new List<string>()
        {
            "🐶", "🐶", // dog
			"🐴", "🐴", // horse
			"🐮", "🐮", // cow
			"🦊", "🦊", // fox 
			"😺", "😺", // cat
			"🦁", "🦁", // lion
			"🐯", "🐯", // tiger
			"🐭", "🐭", // mouse
		};

        static List<string> signEmoji = new List<string>()
        {
            "👈", "👈", // backhand
			"✌️", "✌️",	// vicroty
			"🖖", "🖖", // vulkan slaute 
			"🤞", "🤞", // crossed fingers 
			"👎", "👎", // thumb down
			"🤌", "🤌", // pinched fingers
			"👍", "👍", // thumb up 
			"🤝", "🤝", // handshake
		};

        static List<string> randomEmoji = new List<string>()
        {
            "🎃", "🎃", // gresskar
			"❌", "❌", // X emoji
			"⚡", "⚡", // lightning emoji
			"🚀", "🚀", // rocket
			"🚁", "🚁", // helicopter
			"📸", "📸", // camera
			"🧲", "🧲", // magnet
			"✂️", "✂️",	// scissors 

		};

        static List<string> fruktEmoji = new List<string>()
        {
            "🍒", "🍒", // cherry
            "🍑", "🍑", // peach
            "🍉", "🍉", // watermelon
            "🥝", "🥝", // kiwi
            "🍌", "🍌", // banana
            "🍎", "🍎", // red apple
            "🥥", "🥥", // coconut
            "🍇", "🍇", // grapes
        };

        // starten av commit 4
        static Random random = new Random();
        public List<string> shuffledEmoji = pickRandomEmoji();
        static List<string> pickRandomEmoji()
        {
            // genererer radnom tall mellom 0 og 4, for a velge mellom ett av listene
            int randomIndeks = random.Next(0, 4);


            // lager en switch-case for a returnere emojies ut ifra randomIndex
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


        // commit 5 - behandling av museklikk pa ikoner(Button)
        string lastAnimalFound = string.Empty;
        string lastDescription = string.Empty;

        public void ButtonClick(string animal, string AnimalDescription)
        {
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
                    SetupGame();
                }
            }

            else
            {
                // resetting lastAnimalFound
                lastAnimalFound = string.Empty;
            }
        }
    }
    }