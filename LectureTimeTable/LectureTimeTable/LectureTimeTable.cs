using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class LTT
    {
        public void StartProgram()
        {
            List<LectureTable> lectureTable = new List<LectureTable>();
            LectureView lectureView = new LectureView();
            MyLecture  myLecture = new MyLecture();
            LectureController lectureController = new LectureController();
            bool isRunning = true;

            lectureController.intializeTable(lectureTable); //lectureTable 에 엑셀에서 불러온 테이블 저장
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            

            while (isRunning)
            {
                switch (lectureController.Currentstate)
                {
                    case Constants.START_MENU:
                        lectureController.RunInitailScene(lectureView);
                        break;
                    case Constants.INTEREST_COURSE:
                        lectureController.RunEnrollment(lectureTable, myLecture, lectureView);
                        break;
                    case Constants.ENROLLMENT:
                        break;
                    case Constants.CURRENT_TIMETABLE:
                        break;
                    case Constants.PRGRAM_END:
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
           

        }
    }
}
