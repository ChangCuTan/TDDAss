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

        private List<string> delimiters = new List<string>() { "," };


        public string[] GetDelimiters()
        {
            return delimiters.ToArray();
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
                return delimiters;
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

                delimiters = substringsInBrackets;
                return delimiters;

            }
            else
            {
                delimiters = new List<string>() { userInput };
                return delimiters;
            }
        }


    }
}
