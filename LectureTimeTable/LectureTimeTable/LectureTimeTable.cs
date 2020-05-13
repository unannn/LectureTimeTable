using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT
{
    class LectureTimeTable
    {
        public void StartProgram()
        {
            List<LectureTable> lectureTable = new List<LectureTable>();
            LectureController lectureController = new LectureController();
            lectureController.intializeTable(lectureTable);

            Console.WriteLine();
        }
    }
}
