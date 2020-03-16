using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_3
{
    class Words
    {
        private List<char[]> words;
        private int consonant = 0;

        public Words(string[] strings)
        {
            words = new List<char[]>(strings.Length);
            for(int i = 0; i < strings.Length; i++)
            {
                words.Add(strings[i].ToCharArray());
            }
        }

        public string this[int index]
        {
            get
            {
                string result = new string(words[index]);
               
                return result;
            }

            private set
            {
                words[index] = value.ToCharArray();
            }
        }

        internal int Consonant
        {
            get
            {
                char[] cons = { 'q', 'w', 'r', 't', 'p', 's', 'd',
                'f', 'g', 'h','j', 'k', 'l', 'z', 'x', 'c', 'v', 'b',
                'n', 'm', 'Q', 'W', 'R', 'T', 'P', 'S', 'D', 'F', 'G',
                'H','J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M'};

                foreach (char[] item in words)
                {
                    foreach (char item2 in item)
                    {
                        foreach(char letter in cons)
                        {
                            if(letter == item2)
                            {
                                consonant++;
                            }
                        }
                    }
                }

                return consonant;
            }

            private set
            {
                consonant = value;
            }
        }
    }
}
