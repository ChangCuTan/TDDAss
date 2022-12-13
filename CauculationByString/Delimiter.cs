using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CauculationByString
{
    public class Delimiter
    {
        private string userInput;

        public List<string> Delimiters = new List<string>() { "," };//default


        public List<string> GetDelimiters()
        {
            return Delimiters;
        }

        private void RemoveDoubleSlash(string input)
        {
            string result = input.Substring(2, input.Length - 2);
            userInput = result;
        }

        public List<string> SetDelimiters(string delimitersInputs)
        {
            List<string> substringsInBrackets = new List<string>();

            if (delimitersInputs == null)
            {
                return Delimiters;
            }
            else
            {
                RemoveDoubleSlash(delimitersInputs);
            }

            if (userInput.Contains("[") || userInput.Contains("]"))
            {

                MatchCollection matches = Regex.Matches(delimitersInputs, @"\[(.*?)\]");

                foreach (Match match in matches)
                {
                    substringsInBrackets.Add(match.Value.Trim(new char[] {'[',']'}));
                }

                Delimiters = substringsInBrackets;
                return Delimiters;

            }
            else
            {
                Delimiters = new List<string>() { userInput };
                return Delimiters;
            }
        }


    }
}
