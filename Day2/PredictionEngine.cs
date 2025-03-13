

namespace PredictionEngine
{
    public class PredictionEngine
    {
        ILanguageModelAlgo languageModelAlgo;
        public PredictionEngine(ILanguageModelAlgo languageModelAlgo)
        {
            this.languageModelAlgo = languageModelAlgo;
        }
        public string predict(string inputPhrase)
        {
            string lastWord = GetLastWord(inputPhrase);
            if (inputPhrase.EndsWith(" "))
            {
                return languageModelAlgo.predictUsingBigram(lastWord);
            }
            else
            {
                return languageModelAlgo.predictUsingMonogram(lastWord);
            }
        }
        private static string GetLastWord(string inputPhrase)
        {
            string[] words = inputPhrase.Trim().Split(" ");
            return words[words.Length - 1];
        }
    }
}
