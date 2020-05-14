﻿using System;
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
                "2. 수강신청",
                "3, 현재 시간표",
                "4. 수강신청 종료"
            };
            PrintTitle(Constants.INITIAL_TITLE_BOARDER,"  HELLO STUDENT");

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

        public void PrintLeactureTable(List<LectureTable> lectureTable)   //매개변수로 들어온 강의 리스트를 출력해줌
        {
            Console.Clear();
            PrintTitle(Constants.INITIAL_TITLE_BOARDER, " 관심과목 담기 ");   //타이틀 출력

            PrintLectureItemName();
            Console.SetCursorPosition(0, Constants.UNDER_TITLE_Y);
            PrintBlankTable(23);

            //Console.SetCursorPosition(0, 11);
            //for (int line = 0; line < 10; line++)
            //{
            //    PrintOneRowLecture(lectureTable[line]);
            //}
        }

        public int PrintInterestLeactureMenu()
        {
            int selectedItem = 0;
            //List<string> inputGuide = new List<string>
            //{
            //    "[Esc - 뒤로가기]"
            //};
            List<string> menu = new List<string>()
            {
                "1. 내 관심과목",
                "2. 관심과목 검색",
                "3, 관심과목 삭제",
                "4. 관심과목 담기 종료"
            };
            Console.SetCursorPosition(0, Constants.UNDER_TABLE_Y);
            PrintBlankTable(14);
            Console.SetCursorPosition(0, Constants.UNDER_TABLE_Y);
            Console.WriteLine();
            //PrintInputGuide(inputGuide);

            PrintMenu(menu,0);

            Console.Write(" 메뉴 선택 : ");

            selectedItem = Exception.Instance.InputNumber(Constants.START_NUMBER, menu.Count);

            if (selectedItem == Constants.WRONG_INPUT)
            {
                PrintFailMessage("다시 입력해 주세요.", Constants.INITIAL_TITLE_BOARDER);
            }

            //Console.Clear();
            Console.SetCursorPosition(0, Constants.UNDER_TABLE_Y);
            PrintBlankTable(10);
            Console.SetCursorPosition(0, Constants.UNDER_TABLE_Y);

            return selectedItem;
        }
        
        public void PrintInputGuide(List<string> guideList)
        {
            foreach(string guide in guideList)
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

            inputNumber = Exception.Instance.InputNumber(Constants.START_NUMBER,serchingItem.Count);

            return inputNumber;
        }

        public void PrintMyInterestLeactures(MyLecture myLecture)   //내가 관심과목으로 담은 강의들 리스트 출력
        {
            Console.SetCursorPosition(0, Constants.UNDER_TITLE_Y);

            if (myLecture.myInterestCourse.Count != 0)
            {
                foreach(LectureTable row in myLecture.myInterestCourse)
                {
                    PrintOneRowLecture(row);
                }
                PrintFailMessage("", 0);
            }
            else
            {
                PrintFailMessage("관심과목으로 담은 강의가 없습니다", 0);
                Console.SetCursorPosition(0, Constants.UNDER_TITLE_Y);
                PrintBlankTable(2);
            }
        }
        public void StartSelectedItem(int selectedItem, List<LectureTable> lectureTable, MyLecture myLecture)
        {
            string searchWord = null;
            int searchNumber;
            int addLectureNumber;
            int rowNumber = 0;
            switch (selectedItem)
            {
                case 1:     //개설학과전공
                    Console.Write("개설학과전공 검색 : ");
                    searchWord = Exception.Instance.InputString(1, 10);
                    rowNumber = SearchLecture(lectureTable, searchWord, Constants.DEPARTMENT);                    
                    break;

                case 2:     //학수번호
                    Console.Write("학수번호 검색 : ");
                    searchNumber = Exception.Instance.InputNumber(1, 100000);
                    rowNumber = SearchLecture(lectureTable, searchNumber, Constants.COURSE_NUMBER);
                    break;

                case 3:     //교과목명
                    Console.Write("교과목명 검색 : ");
                    searchWord = Exception.Instance.InputString(1, 10);
                    rowNumber = SearchLecture(lectureTable, searchWord, Constants.COURSE_TITLE);
                    break;

                case 4:    //학년
                    Console.Write("이수학년 검색 : ");
                    searchNumber = Exception.Instance.InputNumber(1, 4);
                    rowNumber = SearchLecture(lectureTable, searchNumber, Constants.YEAR);
                    break;

                case 5:    //교수명
                    Console.Write("교수명 검색 : ");
                    searchWord = Exception.Instance.InputString(1, 10);
                    rowNumber = SearchLecture(lectureTable, searchWord, Constants.PROFESSOR_NAME);
                    break;

                case 6:    //종료
                    return;
            }

            if(rowNumber == 0)
            {
                PrintFailMessage("검색한 강의를 찾을 수 없습니다.", 0);
                return;
            }

            if (selectedItem != 6)
            {
                Console.Write("관심과목에 담을 NO. 입력 : ");
                addLectureNumber = Exception.Instance.InputNumber(Constants.START_NUMBER, lectureTable.Count);

                if(addLectureNumber != Constants.WRONG_INPUT)
                {
                    if(myLecture.MyCurrentCredits + lectureTable[addLectureNumber - 1].Credit <= 24)   //현재 관심과목에담은 학점이 24 이하일 때만
                    {
                        for(int row = 0;row < myLecture.myInterestCourse.Count; row++)
                        {
                            if(myLecture.myInterestCourse[row].CourseNumber == lectureTable[addLectureNumber - 1].CourseNumber)   //학수번호가 같을 경우
                            {
                                PrintFailMessage("이미 추가된 강의입니다.", 0);
                                return;
                            }
                        }

                        myLecture.myInterestCourse.Add(lectureTable[addLectureNumber - 1]);
                        myLecture.MyCurrentCredits += lectureTable[addLectureNumber - 1].Credit;
                        PrintFailMessage("관심과목에 추가되었습니다.", 0);
                    }
                    else
                    {
                        PrintFailMessage("더이상 담을 수 없습니다.", 0);
                    }
                }
                else
                {
                    PrintFailMessage("잘못된 입력입니다.", 0);
                }
            }

        }
    }
}
