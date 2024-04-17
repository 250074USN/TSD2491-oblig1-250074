using System;
using System.Collections.Generic;

namespace TSD2491_OBLIG1_250074.Models
{
    public class MatchingGameModul
    {
        public MatchingGameModul()
        {
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

        public List<string> AnimalEmoji { get { return animalEmoji; } }
    }
}