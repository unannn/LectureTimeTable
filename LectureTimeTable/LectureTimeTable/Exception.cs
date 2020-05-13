using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class Exception
    {
        private static Exception instance = null;

        public static Exception Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Exception();
                }
                return instance;
            }
        }

        public int InputNumber(int start, int end)
        {
            int inputNumber =   Constants.WRONG_INPUT;
            int number;
            string numberInString;

            numberInString = Console.ReadLine();

            if (!string.IsNullOrEmpty(numberInString) && numberInString.Length < 10)
            {
                for (number = 0; number < numberInString.Length; number++)
                {
                    if (numberInString[number] < '0' || numberInString[number] > '9') break;
                }

                if (number == numberInString.Length && number != 0)  //문자열을 다 조사할 때 까지 문자가 모두 숫자였고, 빈문자열이 아니면
                {
                    inputNumber = int.Parse(numberInString);
                }
            }

            if (inputNumber < start || inputNumber > end) inputNumber = Constants.WRONG_INPUT;

            return inputNumber;        
        }

    }
}
