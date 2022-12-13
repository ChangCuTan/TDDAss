using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CauculationByString
{
    public class NewLineSeperator
    {
        private string beforeNewLine = "";
        private string afterNewLine = "";

        public (string, string) SeperateByNewLine(string input)
        {

            List<string> list = new List<string>();

            string newlineCaseses = "\n";
            if (input.Contains(newlineCaseses))
            {
                list = input.Split(newlineCaseses, StringSplitOptions.None).ToList();

                beforeNewLine = list.First();
                afterNewLine = list.Last();

            }
            else
            {
                return (beforeNewLine, input);//no new line in this case
            }

            return (beforeNewLine, afterNewLine);
        }
    }
}
