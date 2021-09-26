using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccertiveChallange
{
   public class TextJustification
    {
        public static string Justify(string text,int length)
        {
            if (text.Length == 0)
                throw new ArgumentException("text is empty");
            if (length < 1)
                throw new ArgumentException("invalid width must be 1 or more");
            string[] words = text.Split(' ');
            return Justify(words, length);
        }
        private static string Justify(string[]words,int maxWidth)
        {
            StringBuilder sb = new StringBuilder();
            int widthSoFar = words[0].Length;
            int startingWord = 0;
            for (int i = 1; i < words.Length; i++)
            {
                string word = words[i];
                if (word.Length > maxWidth)
                    throw new ArgumentException($"word is bigger than margin : {word}");
                if (widthSoFar + word.Length + 1 > maxWidth)
                {
                    // justify words from startingWord to i-1;
                    string justified = Justify(words, startingWord, i - 1, widthSoFar, maxWidth);

                    sb.Append(justified);
                    sb.Append("\n");
                    widthSoFar = word.Length;
                    startingWord = i;
                }
                else
                {
                    widthSoFar += word.Length + 1;
                }
            }
            string lastJustified = Justify(words, startingWord, words.Length - 1, widthSoFar, maxWidth);
            sb.Append(lastJustified);
           return sb.ToString();

        }
        private static string Justify(string[] words, int start, int end, int lineWidth, int maxWidth)
        {
            int diff = maxWidth - lineWidth;
            if (end - start == 0 || end == words.Length - 1)
            {
                return LeftJustify(words, start, end, diff);
            }
            else
            {
                return MiddleJustify(words, start, end, diff);
            }
        }
        private static string LeftJustify(string[] words, int start, int end, int spacesNeeded)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = start; i <= end; i++)
            {
                string word = words[i];
                sb.Append(word);
                if (i != end)
                    sb.Append("-");
            }
            while (spacesNeeded > 0)
            {
                sb.Append("-");
                spacesNeeded--;
            }
            return sb.ToString();
        }
        private static string MiddleJustify(string[] words, int start, int end, int spacesNeeded)
        {
            int appliedSpaces = (spacesNeeded / (end - start)) + 1;
            int leftOverSpaces = spacesNeeded % (end - start);
            StringBuilder sb = new StringBuilder();
            for (int i = start; i <= end; i++)
            {
                string word = words[i];
                sb.Append(word);
                if (i != end)
                {
                    int j = 0;
                    int extraSpace = (leftOverSpaces-- > 0) ? 1 : 0;
                    int spaces = appliedSpaces + extraSpace;
                    while (j < spaces)
                    {
                        sb.Append("-");
                        j++;
                    }
                }
            }
            return sb.ToString();
        }

       
        static void Main(string[] args)
        {
            Console.WriteLine(Justify("The quick brown fox jumps over the lazy dog.", 52));
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine(Justify("The quick brown fox jumps over the lazy dog.", 30));
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine(Justify("The quick brown fox jumps over the lazy dog.", 7));

            Console.ReadLine();
        }
    }
}
