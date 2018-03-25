using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HumanResearch.Semantik;

namespace HumanResearch
{
    public class AI : Human
    {
        private string[] fem_prenames = { "Lisa", "Vanessa", "Jessica", "Jessy", "Kim", "Yuki", "Jasmin", "Yasmin" };
        private string[] mal_prenames = { "Leon", "Jordan", "Max", "Zian", "Alex", "Markus", "Thomas", "Daniel" };
        
        public Dictionary<Guid, Word> vocabulary = NLP.dictionary;

        Semantik german = new Semantik();

        int fitness = 0;
        int geneLength = 5;
        int[] genes = new int[5];


        public AI()
        {
            Random rnd = new Random();
            int name = rnd.Next(0, 8);
            double sex = rnd.NextDouble();

            if(sex > 0.5)
            {
                this.gender = Geschlecht.Male;
                this.firstname = mal_prenames[name];
            }
            else
            {
                this.gender = Geschlecht.Female;
                this.firstname = fem_prenames[name];
            }
            this.familyname = "Müller";
        }

        public void interpretPhrase(string text)
        {
            string[] tokenized_text = NLP.Tokenize(text, false);
            foreach (string fragewort in Enum.GetNames(typeof(Fragewoerter)))
            {
                if (tokenized_text.Contains(fragewort))
                {
                    string newText = string.Empty;
                    foreach (string i in tokenized_text)
                    {
                        newText += i;
                    }

                    Console.WriteLine(newText);
                    german.createFragesatz(Enum.GetValues(typeof(Fragewoerter)).Cast<Fragewoerter>().ToList().Find(x => x.ToString().Contains(fragewort)), tokenized_text[1], tokenized_text[2]);
                    break;
                }
                else
                {
                    Console.WriteLine("ERROR");
                }
            }

            
        }

        public void increaseVocabulary()
        {

        }
    }
}
