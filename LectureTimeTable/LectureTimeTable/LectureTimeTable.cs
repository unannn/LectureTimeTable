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

            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Console.WriteLine("Loding...");        //엑셀을 불러오는동안 로딩
            lectureController.intializeTable(lectureTable); //lectureTable 에 엑셀에서 불러온 테이블 저장
            Console.SetCursorPosition(0,0);


            while (isRunning)
            {
                Console.Clear();
                switch (lectureController.Currentstate)
                {
                    case Constants.START_MENU:           //초기화면
                        lectureController.RunInitailScene(lectureView);
                        break;

                    case Constants.INTEREST_COURSE:      //관심과목 담기
                        lectureController.RunInterestLeactureEnrollment(lectureTable, myLecture, lectureView);
                        break;

                    case Constants.ENROLLMENT:          //수강 신청
                        lectureController.RunLeactureEnrollment(lectureTable, myLecture, lectureView);
                        break;

                    case Constants.CURRENT_TIMETABLE:      //수강 신청한 시간표
                        lectureController.RunCurrentTimetable(lectureTable, myLecture, lectureView);
                        break;

                    case Constants.PROGRAM_END:
                        isRunning = false;
                        break;

                    default:
                        break;
                }
            }
           

        }
    }
}
