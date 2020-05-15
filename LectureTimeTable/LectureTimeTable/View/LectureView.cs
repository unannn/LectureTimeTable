using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable
{
    class LectureView : ViewTool
    {
        public int initialView()
        {
            int selectedItem = 0;
            List<string> initialMenu = new List<string>()
            {
                "1. 관심과목 담기",
                "2. 수강 신청",
                "3, 현재 시간표",
                "4. 수강신청 종료"
            };
            PrintTitle(Constants.INITIAL_TITLE_BOARDER, "  HELLO STUDENT");

            Console.WriteLine("\n\n\n");
            PrintMenu(initialMenu, Constants.INITIAL_TITLE_BOARDER);

            Console.WriteLine("\n\n\n");
            PrintLeftGap(Constants.INITIAL_TITLE_BOARDER);
            Console.Write("메뉴 선택 : ");
            selectedItem = Exception.Instance.InputNumber(Constants.START_NUMBER, initialMenu.Count);

            if (selectedItem == Constants.WRONG_INPUT)
            {
                PrintFailMessage("다시 입력해 주세요.", Constants.INITIAL_TITLE_BOARDER);
            }
            

            return selectedItem;
        }

        public void PrintinitialLeactureTable()   //초기 빈 테이블 출력
        {
            PrintLectureItemName();
            PrintBlankTable(23);
        }


        public void PrintInputGuide(List<string> guideList)
        {
            foreach (string guide in guideList)
            {
                Console.Write("  " + guide);
            }
        }
        public void PrintTimeTable(List<LectureTable> enrollmentTable)
        {

            for (int time = 0; time < 24; time++)
            {
                Console.SetCursorPosition(0, time * 3 + 10);  //시간 출력
                if (time / 4 == 0) Console.Write("0");
                Console.Write((time+16)/2 + ":");
                if (time % 2 == 1) Console.Write("30");
                else Console.Write("00");

                for (int day = 0; day < 5; day++)
                {
                    Console.SetCursorPosition(day * 20 + 30,Constants.UNDER_TITLE_Y-2);

                    switch (day)
                    {
                        case Constants.MONDAY:
                            Console.Write("  월");
                            break;
                        case Constants.TUESNDAY:
                            Console.Write("  화");
                            break;
                        case Constants.WEDNESDAY:
                            Console.Write("  수");
                            break;
                        case Constants.THURSDAY:
                            Console.Write("  목");
                            break;
                        case Constants.FRIDAY:
                            Console.Write("  금");
                            break;
                    }

                    for (int lectureCount = 0; lectureCount < enrollmentTable.Count; lectureCount++)
                    {
                        if(enrollmentTable[lectureCount].timeTable[time,day] == 1)
                        {
                            Console.SetCursorPosition(day * 20 + 30, time * 3 + 10);
                            Console.WriteLine(enrollmentTable[lectureCount].CourseTitle);
                            Console.SetCursorPosition(day * 20 + 30, time * 3 + 1 + 10);
                            Console.Write(enrollmentTable[lectureCount].LectureRoom);
                        }
                    }
                }
            }

            PrintFailMessage("", 160);

        }

    }
        
}
