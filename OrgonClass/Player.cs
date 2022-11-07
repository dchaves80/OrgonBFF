using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgonClass
{
    public class Player{

        string name;
        string guid;
        int level;

        public Player(string name) 
        {
            this.name = name;
            this.guid = Guid.NewGuid().ToString();
            this.level = 1;
        }


        public static string GetRandomSyllable() 
        {
            List<String> vowels  = new List<string>() { "a", "e", "i", "o", "u" };
            List<String> consonants = new List<string>() { "b", "c", "d", "f", "g", "h", "j", "l", "m", "n", "p",  "r", "s", "t", "v", "w" };

            string syllable = "";


            syllable += consonants[new Random().Next(0, consonants.Count)];
            syllable += vowels[new Random().Next(0, vowels.Count)];

            //get a random number if greater than 5 add a random consonant to the syllable
            if (new Random().Next(0, 10) > 5)
            {
                syllable += consonants[new Random().Next(0, consonants.Count)];
            }

            return syllable;


        }

        public static List<string> nameGenerator()
        {

            Random r = new Random();
            List<string> NamesList = new List<string>();

            for (int a = 0; a < 10; a++)
            {
                int lengthName = r.Next(2, 5);
                int lengthLastName = r.Next(1, 5);

                string name = "";
                string lastName = "";

                for (int i = 0; i < lengthName; i++)
                {
                    name += GetRandomSyllable();
                }

                for (int i = 0; i < lengthLastName; i++)
                {
                    lastName += GetRandomSyllable();
                }

                //return both camel Case
                string completeName = name.Substring(0, 1).ToUpper() + name.Substring(1) + " " + lastName.Substring(0, 1).ToUpper() + lastName.Substring(1);
                NamesList.Add(completeName);
            }
            return NamesList;

        }
        
    }
}
