using System;
using System.Collections.Generic;
using System.Linq;

namespace TSD2491_OBLIG1_250074.Models
{
    public class MatchingGameModul
    {
       
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
        public List<string> ShuffledEmoji { get; private set; }

        public MatchingGameModul()
        {
            ShuffledEmoji = ShuffleEmoji(animalEmoji);
        }

        private List<string> ShuffleEmoji(List<string> emojis)
        {
            return emojis.OrderBy(e => random.Next()).ToList();
        }
    }
}