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

            Console.Clear();

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

        public int SeruchLectureTypes()
        {
            List<string> serchingItem = new List<string>()
            {
                "1. 개설학과전공",
                "2. 학수번호",
                "3. 교과목명",
                "4. 학년",
                "5, 교수명",
                "6. 검색 종료"
            };
            int inputNumber;
            Console.SetCursorPosition(0, Constants.UNDER_TABLE_Y);
            PrintBlankTable(10);
            Console.SetCursorPosition(0, Constants.UNDER_TABLE_Y);
            PrintMenu(serchingItem, 0);
            Console.Write("메뉴 선택 : ");

            inputNumber = Exception.Instance.InputNumber(Constants.START_NUMBER, serchingItem.Count);

            return inputNumber;
        }
    }
        
}
