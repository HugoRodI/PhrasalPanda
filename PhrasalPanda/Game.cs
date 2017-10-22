using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace PhrasalPanda
{
    public class Game
    {
        private const int PUNCTUATION_STEP = 10;
        private const int NUMBER_OF_OPTIONS = 4;
        private const int NUMBER_OF_LIVES = 3;
        private int Lives { get; set; }
        private int Punctuation { get; set; }
        private int Level { get; set; }
        private Random random = new Random();
        private List<PhrasalVerb> PhrasalVerbs { get; set; }

        public Game()
        {
            Lives = NUMBER_OF_LIVES;
            PhrasalVerbs = new List<PhrasalVerb>();
            PopulatePhrasalVerbList();
            ShufflePhrasalVerbList();
        }
        
        private void PopulatePhrasalVerbList()
        {
            using (var reader = new StreamReader(@"../Verbs/PhrasalVerbs.txt"))
            {
                while (!reader.EndOfStream)
                {
                    PhrasalVerb phrasalVerb = new PhrasalVerb();
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    phrasalVerb.VerbName = values[0];
                    phrasalVerb.VerbMeaning = values[1];

                    PhrasalVerbs.Add(phrasalVerb);
                }
            }
        }

        private void ShufflePhrasalVerbList()
        {
            PhrasalVerbs.Shuffle();
        }

        public bool GameOver()
        {
            if (Lives == 0)
                return true;

            return false;
        }
        
        internal List<string> GetVerbMeaningOptions()
        {
            List<string> verbMeaningOptions = new List<string>();

            verbMeaningOptions.Add(PhrasalVerbs[Level].VerbMeaning);

            for (int i = 0; i < NUMBER_OF_OPTIONS - 1; i++)
            {
                PhrasalVerb possiblePhrasalVerb = new PhrasalVerb();

                do
                {
                    possiblePhrasalVerb = PhrasalVerbs[random.Next(0, PhrasalVerbs.Count)];
                } while (VerbIsInList(possiblePhrasalVerb, verbMeaningOptions));
                
                verbMeaningOptions.Add(possiblePhrasalVerb.VerbMeaning);
            }
            
            verbMeaningOptions.Shuffle();

            return verbMeaningOptions;
        }

        private bool VerbIsInList(PhrasalVerb possiblePhrasalVerb, List<string> verbMeaningOptions)
        {
            if(verbMeaningOptions.Any(verb => verb == possiblePhrasalVerb.VerbMeaning))
                return true;

            return false;
        }

        internal PhrasalVerb GetPhrasalVerb()
        {
            return PhrasalVerbs[Level];
        }

        internal string GetPunctuation()
        {
            return Punctuation.ToString();
        }

        internal void IncreasePunctuation()
        {
            Punctuation += PUNCTUATION_STEP;
        }

        public void RemoveLive()
        {
            Lives--;
        }

        internal void IncreaseLevel()
        {
            Level += 1;
        }
    }

   
}
