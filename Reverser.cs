using System;
using System.Linq;

namespace Reverser
{
    public class Reverser
    {
        private char[] _separatorList;
        private readonly int _separatorCount;

        public Reverser(char[] separators)
        {
            _separatorList = separators;
            _separatorCount = _separatorList.Count();
        }

        private string WordReverse(string sentence)
        {
            var arraySentence = sentence.ToArray();
            
            var length = arraySentence.Count();
            var result = new char[length];

            for (var k = 0; k < length; k++)
            {
                result[k] = arraySentence[length - k - 1];
            }

            return new string(result);
        }

        /// <summary>
        /// Given a sentence and a pre-defined set of word separator characters, 
        /// reverses all the words without altering their ordinal position in the sentence.
        /// </summary>
        public string Reverse(string sentence, int separatorIteration = 0)
        {
            Console.WriteLine("Call with sentence '{0}', separator iteration {1}", sentence, separatorIteration);
            if (separatorIteration == _separatorCount)
            {
                Console.WriteLine("Base case reached.");
                return WordReverse(sentence);
            }

            var separator = new char[1] { _separatorList[separatorIteration] };
            var parts = sentence.Split(separator);
            var count = parts.Count();

            separatorIteration++;
            string result = Reverse(parts[0], separatorIteration);
            for (var i = 1; i < count; result += new string(separator) + Reverse(parts[i++], separatorIteration));
            return result;
        }

        /// <summary>
        /// Given a sentence and a pre-defined set of word separator characters, 
        /// reverses the order of the words in the sentence without reversing each word.
        /// </summary>
        public string ReverseSentence(string sentence, int separatorIteration = 0)
        {
            Console.WriteLine("Call with sentence '{0}', separator iteration {1}", sentence, separatorIteration);
            if (separatorIteration == _separatorCount)
            {
                Console.WriteLine("Base case reached.");
                return sentence;
            }

            var separator = new char[1] { _separatorList[separatorIteration] };
            var parts = sentence.Split(separator);
            var count = parts.Count();

            separatorIteration++;
            string result = ReverseSentence(parts[0], separatorIteration);
            for (var i = 1; i < count; result = ReverseSentence(parts[i++], separatorIteration) + new string(separator) + result) ;
            return result;
        }
    }
}
