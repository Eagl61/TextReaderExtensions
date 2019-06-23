using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace TextReaderExtensions
{
    public static class ReaderExtension
    {
        /// <summary>
        /// Returns value indicating whether the end of line has been reached.
        /// </summary>
        public static bool EOLN(this TextReader reader) => reader.Peek() == '\n';

        /// <summary>
        /// Returns a value indicating whether no more characters are available.
        /// </summary>
        public static bool EOF(this TextReader reader) => reader.Peek() == -1;

        /// <summary>
        /// Reads next integer value from input sequence.
        /// </summary>
        public static long ReadInteger(this TextReader reader)
        {
            SkipWhiteSpaces(reader);
            long resultValue = 0;
            bool isNegative = false;
            char ch = Convert.ToChar(reader.Read());
            if (ch == '-')
            {
                isNegative = true;
                ch = Convert.ToChar(reader.Read());
            }

            if (!char.IsDigit(ch))
            {
                throw new Exception("Unable to read number.");
            }

            do
            {
                resultValue = (resultValue * 10) + (long)char.GetNumericValue(ch);
                ch = Convert.ToChar(reader.Read());
                if (!char.IsDigit(ch))
                {
                    break;
                }
            } while (!char.IsWhiteSpace(ch));

            return isNegative ? -resultValue : resultValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SkipWhiteSpaces(TextReader reader)
        {
            while (char.IsWhiteSpace(Convert.ToChar(reader.Peek())))
            {
                reader.Read();
                if (reader.Peek() == -1)
                {
                    break;
                }
            }
        }
    }
}
