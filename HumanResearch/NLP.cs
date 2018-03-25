using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HumanResearch
{
    public class NLP
    {
        //Guid == id | Word == wordtype, word, definition etc
        public static Dictionary<Guid, Word> dictionary = new Dictionary<Guid, Word>();

        private static char[] delimiters_keep_digits = new char[] {
            '{', '}', '(', ')', '[', ']', '>', '<','-', '_', '=', '+',
            '|', '\\', ':', ';', ' ', ',', '.', '/', '?', '~', '!',
            '@', '#', '$', '%', '^', '&', '*', ' ', '\r', '\n', '\t' };

        // This will discard digits 
        private static char[] delimiters_no_digits = new char[] {
            '{', '}', '(', ')', '[', ']', '>', '<','-', '_', '=', '+',
            '|', '\\', ':', ';', ' ', ',', '.', '/', '?', '~', '!',
            '@', '#', '$', '%', '^', '&', '*', ' ', '\r', '\n', '\t',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public string[] getSentences(string text) {
            char[] delim = new char[] { '.', '?', '!' };
            string[] newtext = text.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            return newtext;
        }

        public static string[] Tokenize(string text, bool keepDigits)
        {
            string[] tokens = null;

            if (keepDigits)
                tokens = text.Split(delimiters_keep_digits, StringSplitOptions.RemoveEmptyEntries);
            else
                tokens = text.Split(delimiters_no_digits, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];

                // Change token only when it starts and/or ends with "'" and the 
                // toekn has at least 2 characters. 
                if (token.Length > 1)
                {
                    if (token.StartsWith("'") && token.EndsWith("'"))
                        tokens[i] = token.Substring(1, token.Length - 2); // remove the starting and ending "'" 

                    else if (token.StartsWith("'"))
                        tokens[i] = token.Substring(1); // remove the starting "'" 

                    else if (token.EndsWith("'"))
                        tokens[i] = token.Substring(0, token.Length - 1); // remove the last "'" 
                }
            }

            return tokens;
        }

        public void addWordsToDictionary(Word word)
        {
            dictionary.Add(new Guid(), word);
        }
    }

    public struct Word
    {
        public string word { get; set; }
        public Wordtypes wordtype { get; set; }
        public Tag tag { get; set; }

        public Word(string word, Wordtypes wordtype, Tag tag)
        {
            this.word = word;
            this.wordtype = wordtype;
            this.tag = tag;
        }
    }

    public struct Wordtypes
    {
        public struct Nomen
        {
            public Artikel article;
            public List<string> materiell;
            public List<string> lebewesen;
            public List<string> immateriell;
        }
        public struct Artikel
        {
            public enum BestimmterArtikel
            {
                der, die, das, des, dem, den
            }

            public enum UnbestimmterArtikel
            {
                ein, eine, einer, eines, einem, einen
            }

            public enum VersteckterArtikel
            {
                zum, zur, im, ins, durchs, fürs, unterm
            }
        }
        public struct Pronomen
        {
            public struct Possessivpronomen
            {
                public enum ErstePersonSingular
                {
                    mein, meine, meiner, meines, meinen, meinem
                }

                public enum ZweitePersonSingular
                {
                    dein, deine, deiner, deines, deinen, deinem,
                }

                public enum DrittePersonSingularMännlich
                {
                    sein, seine, seiner, seines, seinen, seinem,
                }

                public enum ErstePersonPlural
                {
                    unser, unsere, unserer, unseres, unseren, unserem, 
                }

                public enum ZweitePersonPlural
                {
                    euer, eure, eurer, eures, euren, eurem
                }

                public enum DrittePersonNeutral
                {
                    ihr, ihre, ihrer, ihres, ihren, ihrem,
                }
            }
            public enum Interrogativpronomen
            {
                wer, wem, wen, was, wessen, wo, wohin, woher, wann, wie,
                warum, weshalb, wieso, wozu, welche, welcher, welches
            }
            public struct Relativpronomen
            {
                enum Männlich
                {
                    der, dessen, dem, den, die, deren, denen
                }

                enum Weiblich
                {
                    die, der, deren, denen
                }

                enum Sächlich
                {
                    das, dessen, dem, die, deren, denen
                }
            }
            public enum Indefinitpronomen
            {
                alle, allesamt, andere, beide, einer, einige, etliche, etwas, irgendetwas,
                irgendein, irgendwelche, irgendwas, irgendwer, jeder, jeglicher, jedermann,
                jemand, irgendjemand, kein, man, manch, mehrere, meinesgleichen, nichts, niemand,
                sämtlich, viel, welche, wenig, wenige, wer, was, solche
            }
            public struct Reflexivpronomen
            {
                public struct Singular
                {
                    public enum ErstePerson
                    {
                        meiner, mir, mich
                    }
                    public enum ZweitePerson
                    {
                        deiner, dir, dich
                    }
                    public enum DrittePersonMännlich
                    {
                        seiner, sich
                    }
                    public enum DrittePersonWeiblich
                    {
                        ihrer, sich
                    }
                    public enum DrittePersonSächlich
                    {
                        seiner, sich
                    }
                }

                public struct Plural
                {
                    public enum ErstePerson
                    {
                        unser, uns
                    }
                    public enum ZweitePerson
                    {
                        euer, euch
                    }
                    public enum DrittePerson
                    {
                        ihrer, sich
                    }
                }
            }
            public struct Personalpronomen
            {
                public struct Singular
                {
                    public enum ErstePerson
                    {
                        ich, meiner, mir, mich
                    }
                    public enum ZweitePerson
                    {
                        du, deiner, dir, dich
                    }
                    public enum DrittePersonMännlich
                    {
                        er, seiner, sich
                    }
                    public enum DrittePersonWeiblich
                    {
                        sie, ihrer, sich
                    }
                    public enum DrittePersonSächlich
                    {
                        es, seiner, sich
                    }
                }

                public struct Plural
                {
                    public enum ErstePerson
                    {
                        wir, unser, uns
                    }
                    public enum ZweitePerson
                    {
                        ihr, euer, euch
                    }
                    public enum DrittePerson
                    {
                        sie, ihrer, sich
                    }
                }
            }
            public struct Demonstrativpronomen
            {
                public struct DerDieDas
                {
                    public enum Männlich
                    {
                        der, dessen, dem, den
                    }

                    public enum Weiblich
                    {
                        die, deren, der
                    }

                    public enum Sächlich
                    {
                        das, dessen, dem
                    }

                    public enum Plural
                    {
                        die, deren, derer, denen
                    }
                }

                public struct DieserDiese
                {
                    public enum Männlich
                    {
                        dieser, dieses, diesem, diesen
                    }

                    public enum Weiblich
                    {
                        diese, dieser
                    }

                    public enum Sächlich
                    {
                        dieses, diesem
                    }

                    public enum Plural
                    {
                        diese, dieser, diesen
                    }
                }
            }
        }

        public class AdjektiveList<X, Y, Z>
        {
            private X baseWord;
            private Y komparativ;
            private Z superlativ;

            public X BaseWord
            {
                get { return baseWord; }
                set { baseWord = value; }
            }

            public Y Komparativ
            {
                get { return komparativ; }
                set { komparativ = value; }
            }

            public Z Superlativ
            {
                get { return superlativ; }
                set { superlativ = value; }
            }

            public AdjektiveList()
            {

            }

            public AdjektiveList(X baseWord, Y komparativ, Z superlativ)
            {
                this.BaseWord = baseWord;
                this.Komparativ = komparativ;
                this.Superlativ = superlativ;
            }
        }

        public struct Adjektive
        {
           public string positiv { get; set; }
           public string komparativ { get; set; }
           public string superlative { get; set; }
        }

        public struct Verb
        {
            public enum Tempus
            {
                Plusquamperfekt, Präteritum, Perfekt, Präsens, FuturI, FuturII
            }

            public enum Modus
            {
                Indikativ, Konjunktiv, Imperativ
            }

            public List<Pronomen.Personalpronomen> Persona;
            public string verb;
        }

        public struct Adverb
        {

        }

        public struct Konjunktion
        {

        }

        public struct Präposition
        {
            public enum position
            { 
                vor, hinter, auf, in, im, neben, durch, über, unter
            }
        }
    }

    public class Semantik
    {
        private string subjekt { get; set; }
        private string finites_verb { get; set; }
        private string indirektes_objekt { get; set; }
        private string direktes_objekt { get; set; }
        private string ort { get; set; }
        private string infinites_verb { get; set; }
        private string adjektiv { get; set; }
        private string präposition { get; set; }

        public static readonly string[] fragewoerter = new string[] {
            "wer", "wem", "wen", "was", "wessen", "wo", "wohin", "woher", "wann", "wie",
            "warum", "weshalb", "wieso", "wozu", "welche", "welcher", "welches"
        };

        public enum Fragewoerter
        {
            wer, wem, wen, was, wessen, wo, wohin, woher, wann, wie,
            warum, weshalb, wieso, wozu, welche, welcher, welches, 
        }

        /******************************************************
         *********************** HAUPTSATZ ********************
         ******************************************************/
        public List<string> createHauptsatz(string subjekt, string finites_verb, string indirektes_objekt, string direktes_objekt, string zeit, string ort, string infinites_verb)
        {
            List<string> hauptsatz_aufbau = new List<string>();
            hauptsatz_aufbau.Add(subjekt);
            hauptsatz_aufbau.Add(finites_verb);
            hauptsatz_aufbau.Add(indirektes_objekt);
            hauptsatz_aufbau.Add(direktes_objekt);
            hauptsatz_aufbau.Add(zeit);
            hauptsatz_aufbau.Add(ort);
            hauptsatz_aufbau.Add(infinites_verb);

            return hauptsatz_aufbau;
        }

        public List<string> createHauptsatz(string subjekt, string finites_verb, string direktes_objekt)
        {
            List<string> hauptsatz_aufbau = new List<string>();
            hauptsatz_aufbau.Add(subjekt);
            hauptsatz_aufbau.Add(finites_verb);
            hauptsatz_aufbau.Add(direktes_objekt);

            return hauptsatz_aufbau;
        }

        public List<string> createHauptsatz(string subjekt, string finites_verb, string direktes_objekt, string zeit)
        {
            List<string> hauptsatz_aufbau = new List<string>();
            hauptsatz_aufbau.Add(subjekt);
            hauptsatz_aufbau.Add(finites_verb);
            hauptsatz_aufbau.Add(direktes_objekt);
            hauptsatz_aufbau.Add(zeit);

            return hauptsatz_aufbau;
        }

        public List<string> createHauptsatz(string subjekt, string finites_verb, string direktes_objekt, string zeit, string ort)
        {
            List<string> hauptsatz_aufbau = new List<string>();
            hauptsatz_aufbau.Add(subjekt);
            hauptsatz_aufbau.Add(finites_verb);
            hauptsatz_aufbau.Add(direktes_objekt);
            hauptsatz_aufbau.Add(zeit);
            hauptsatz_aufbau.Add(ort);

            return hauptsatz_aufbau;
        }

        public List<string> createHauptsatz(string subjekt, string finites_verb, string direktes_objekt, string zeit, string ort, string indirektes_objekt)
        {
            List<string> hauptsatz_aufbau = new List<string>();
            hauptsatz_aufbau.Add(subjekt);
            hauptsatz_aufbau.Add(finites_verb);
            hauptsatz_aufbau.Add(direktes_objekt);
            hauptsatz_aufbau.Add(zeit);
            hauptsatz_aufbau.Add(ort);
            hauptsatz_aufbau.Add(indirektes_objekt);

            return hauptsatz_aufbau;
        }
        /*****************************************************
        ********************** FRAGESATZ *********************
        ******************************************************/
        public List<string> createFragesatz(Fragewoerter fragewort, string subjekt, string finites_verb)
        {
            List<string> fragesatz_aufbau = new List<string>();

            fragesatz_aufbau.Add(fragewort.ToString());
            fragesatz_aufbau.Add(finites_verb);
            fragesatz_aufbau.Add(subjekt);

            return fragesatz_aufbau;
        }

        public List<string> createFragesatz(bool hasFragewort, Fragewoerter fragewort, string subjekt, string finites_verb, string direktes_objekt)
        {
            List<string> fragesatz_aufbau = new List<string>();

            if (hasFragewort)
                fragesatz_aufbau.Add(fragewort.ToString());

            fragesatz_aufbau.Add(finites_verb);
            fragesatz_aufbau.Add(subjekt);
            fragesatz_aufbau.Add(direktes_objekt);

            return fragesatz_aufbau;
        }

        public List<string> createFragesatz(bool hasFragewort, Fragewoerter fragewort, string subjekt, string finites_verb, string direktes_objekt, string infinites_verb)
        {
            List<string> fragesatz_aufbau = new List<string>();

            if (hasFragewort)
                fragesatz_aufbau.Add(fragewort.ToString());

            fragesatz_aufbau.Add(finites_verb);
            fragesatz_aufbau.Add(subjekt);
            fragesatz_aufbau.Add(direktes_objekt);
            fragesatz_aufbau.Add(infinites_verb);

            return fragesatz_aufbau;
        }

        public List<string> createFragesatz(bool hasFragewort, Fragewoerter fragewort, string subjekt, string finites_verb, string direktes_objekt, string infinites_verb, string indirektes_objekt)
        {
            List<string> fragesatz_aufbau = new List<string>();

            if (hasFragewort)
                fragesatz_aufbau.Add(fragewort.ToString());

            fragesatz_aufbau.Add(finites_verb);
            fragesatz_aufbau.Add(subjekt);
            fragesatz_aufbau.Add(direktes_objekt);
            fragesatz_aufbau.Add(indirektes_objekt);
            fragesatz_aufbau.Add(infinites_verb);

            return fragesatz_aufbau;
        }

        public List<string> createFragesatz(bool hasFragewort, Fragewoerter fragewort, string subjekt, string finites_verb, string direktes_objekt, string infinites_verb, string indirektes_objekt, string ort)
        {
            List<string> fragesatz_aufbau = new List<string>();

            if (hasFragewort)
                fragesatz_aufbau.Add(fragewort.ToString());

            fragesatz_aufbau.Add(finites_verb);
            fragesatz_aufbau.Add(subjekt);
            fragesatz_aufbau.Add(indirektes_objekt);
            fragesatz_aufbau.Add(ort);
            fragesatz_aufbau.Add(direktes_objekt);
            fragesatz_aufbau.Add(infinites_verb);

            return fragesatz_aufbau;
        }

        public List<string> createFragesatz(bool hasFragewort, Fragewoerter fragewort, string subjekt, string finites_verb, string direktes_objekt, string infinites_verb, string indirektes_objekt, string ort, string zeit)
        {
            List<string> fragesatz_aufbau = new List<string>();

            if (hasFragewort)
                fragesatz_aufbau.Add(fragewort.ToString());

            fragesatz_aufbau.Add(finites_verb);
            fragesatz_aufbau.Add(subjekt);
            fragesatz_aufbau.Add(indirektes_objekt);
            fragesatz_aufbau.Add(zeit);
            fragesatz_aufbau.Add(ort);
            fragesatz_aufbau.Add(direktes_objekt);
            fragesatz_aufbau.Add(infinites_verb);

            return fragesatz_aufbau;
        }
    }
}
