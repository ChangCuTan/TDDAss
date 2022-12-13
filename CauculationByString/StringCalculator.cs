using System.Security.Cryptography.X509Certificates;

namespace CauculationByString
{
    public class StringCalculator
    {
        private string input = "";

        private NewLineSeperator _newLineSeperator;
        private Delimiter _delimiter;

        public StringCalculator()
        {
            _newLineSeperator = new NewLineSeperator();
            _delimiter = new Delimiter();
        }

        private void setInput(string userInput)
        {
            input = userInput;
        }



        public int Add(string userInput)
        {
            setInput(userInput);


            List<int> listOfIntegerInString = new List<int>();
            int beforeNewlineNumber = 0;


            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            if (userInput.Contains("-"))
            {
                throw new ArgumentException("Parameter cannot have negetive");
            }

            (string beforeNewLine, string afterNewLine) = _newLineSeperator.SeperateByNewLine(input);

            if (!string.IsNullOrEmpty(beforeNewLine) && beforeNewLine.Contains("//"))
            {
                //handel any type of delimeters with [] or without []
                _delimiter.SetDelimiters(beforeNewLine);
            }

            if (int.TryParse(beforeNewLine, out beforeNewlineNumber))
            {
                listOfIntegerInString.Add(beforeNewlineNumber);
                listOfIntegerInString.AddRange(ProcessStringToListInteger(afterNewLine, _delimiter.GetDelimiters()));

            }
            else
            {
                listOfIntegerInString.AddRange(ProcessStringToListInteger(afterNewLine, _delimiter.GetDelimiters()));
            }

            listOfIntegerInString = RemoveIntMoreThan1000(listOfIntegerInString);

            return listOfIntegerInString.Sum();

        }


        private List<int> RemoveIntMoreThan1000(List<int> intlist)
        {

            return intlist.Where(x => x < 1000).ToList();
        }

        private List<int> ProcessStringToListInteger(string userInput, string[] Delimiter)
        {
            List<int> ints = new List<int>();
            var result = userInput.Split(Delimiter, StringSplitOptions.None);
            foreach (string str in result)
            {
                ints.Add(int.Parse(str));
            }

            return ints;
        }
    }
}