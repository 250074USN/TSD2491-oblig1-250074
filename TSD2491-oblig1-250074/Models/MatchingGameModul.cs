using System;
using System.Collections.Generic;
using System.Linq;

namespace TSD2491_OBLIG1_250074.Models
{
    public class MatchingGameModul
    {
        public int MatchesFound = 0;
        public List<string> ShuffledEmoji { get; private set; } = new List<string>();

        public MatchingGameModul()
        {
            SetupGame();
        }

        private void SetupGame()
        {
            ShuffledEmoji = ShuffleEmoji(animalEmoji);
            MatchesFound = 0;
        }

        static Random random = new Random();
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

        public List<string> AnimalEmoji { get { return animalEmoji; } }

        private List<string> ShuffleEmoji(List<string> emojis)
        {
            return emojis.OrderBy(e => random.Next()).ToList();
        }

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
                ShuffledEmoji = ShuffledEmoji.Select(a => a.Replace(animal, string.Empty)).ToList();
                MatchesFound++;
            }
            else
            {
                // resetting lastAnimalFound
                lastAnimalFound = string.Empty;
            }
        }
    }
}