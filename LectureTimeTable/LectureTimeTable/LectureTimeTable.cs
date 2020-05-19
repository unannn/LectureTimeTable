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
            Console.Title = "LectureTimeTable";

            List<LectureTable> interestTable = new List<LectureTable>();         //관심과목에 쓸 강의 리스트
            List<LectureTable> enrollmentTable = new List<LectureTable>();              //수강신청할 때 쓸 강의 리스트
            LectureView lectureView = new LectureView();
            InterestLectureView interestView = new InterestLectureView();
            EnrollmentView enrollmentView = new EnrollmentView();
            MyLecture  myLecture = new MyLecture();
           
            LectureController lectureController = new LectureController();
            bool isRunning = true;

            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, 24);
            Console.WriteLine("               EN# 화이팅!!!!!!!!!");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, 26);
            Console.WriteLine("Loading... (Window 키 + 방향키↑로 전체화면)");        //엑셀을 불러오는동안 로딩
            lectureController.intializeTable(interestTable, enrollmentTable); //lectureTable 에 엑셀에서 불러온 테이블 저장
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
                        lectureController.RunInterestLeactureEnrollment(interestTable, myLecture, lectureView, interestView);
                        break;

                    case Constants.ENROLLMENT:          //수강 신청
                        lectureController.RunLeactureEnrollment(interestTable, enrollmentTable, myLecture, lectureView, enrollmentView);
                        break;

                    case Constants.CURRENT_TIMETABLE:      //수강 신청한 시간표
                        lectureController.RunCurrentTimetable(myLecture, lectureView);
                        break;

                    case Constants.PROGRAM_END:           //프로그램 종료
                        isRunning = false;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
