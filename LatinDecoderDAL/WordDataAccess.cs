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
            words = File.ReadAllLines("Dataset/forms.txt");
        }
        

        // Basic solution which matches single words
        public List<string> GetWordListWildcard(string WordFragment)
        {
            List<string> WordList = new List<string>(words);
            string pattern = WordFragment.Replace('-', '.');
            string patternRefined = $"^{pattern}$";
            List<string> filtered = WordList.Where(word => Regex.IsMatch(word, patternRefined)).ToList();
            return filtered;
        }

        // Intermediate solution which matches sentences in which words are separated with spaces
        public List<string> GetWordListSentence(string WordFragment)
        {
            // get dataset
            List<string> WordList = new List<string>(words);

            // take care of placeholders
            string pattern = WordFragment.Replace('-', '.');

            // word fragment turn into tokens (could be one only or multiple)
            List<string> SentenceTokens = pattern.Split(' ').ToList();

            List<string> Sentences = new List<string>();

            List<List<string>> ListOfTokenList = new List<List<string>>();

            // get a list for each token of the sentence 
            foreach (var Token in SentenceTokens)
            {
                List<string> ListForToken = new List<string>();
                string TokenRefined = $"^{Token}$";

                foreach (var Word in WordList)
                {
                    if (Regex.IsMatch(Word, TokenRefined)) {
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
                WordCombos = WordCombos.SelectMany(r => TokenList.Select(x => r + " " + x));
            }

            return WordCombos.ToList();
        }
    } 
}
