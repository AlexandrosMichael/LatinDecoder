using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LatinDecoderDAL
{
    public class WordDataAccess
    {
        // Attribute holding the words as loaded from the text file
        private string[] words;

        public WordDataAccess()
        {
            words = File.ReadAllLines("wwwroot/Dataset/forms.txt");
        }

        public WordDataAccess(string path)
        {
            words = File.ReadAllLines(path);
        }

        // Solution which matches sentences in which words are separated with spaces
        public List<string> GetWordListSentence(string WordFragment)
        {
            // make word fragment into lower case
            WordFragment = WordFragment.ToLower();

            // replace long dash with two single dashes
            WordFragment = WordFragment.Replace("\u2014", "--");
            // get dataset
            List<string> WordList = new List<string>(words);

            // take care of placeholders
            string pattern = WordFragment.Replace('-', '.');

            // word fragment turn into tokens (could be one only or multiple)
            List<string> SentenceTokens = pattern.Split(' ').ToList();

            List<List<string>> ListOfTokenList = new List<List<string>>();

            // get a list for each token of the sentence 
            foreach (var Token in SentenceTokens)
            {
                List<string> ListForToken = new List<string>();
                string TokenRefined = $"^{Token}$";

                foreach (var Word in WordList)
                {
                    if (Regex.IsMatch(Word, TokenRefined, RegexOptions.IgnoreCase))
                    {
                        ListForToken.Add(Word);
                    }
                }
                ListOfTokenList.Add(ListForToken);
            }

            // Iterate the list of lists and create word combinations
            return GetAllPossibleCombos(ListOfTokenList);
        }

        // Method for creating the combination of words from the list of matched tokens
        // https://stackoverflow.com/questions/32571057/generate-all-combinations-from-multiple-n-lists/32571653
        public static List<string> GetAllPossibleCombos(List<List<string>> ListOfTokenList)
        {
            IEnumerable<string> WordCombos = new[] { "" };

            foreach (var TokenList in ListOfTokenList)
            {
                WordCombos = WordCombos.SelectMany(r => TokenList.Select(x => !string.IsNullOrEmpty(r) ? r.Trim(' ') + " " + x.Trim(' ') : x.Trim(' ')));
            }

            return WordCombos.ToList();
        }

    }
}
